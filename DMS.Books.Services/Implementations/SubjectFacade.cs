using System.Linq;
using DMS.Books.Repositories;
using DMS.Books.Services.Interfaces;
using DMS.Books.Services.Messaging;
using DMS.Books.Services.Viewmodels;

namespace DMS.Books.Services.Implementations
{
    public class SubjectFacade:ISubjectFacade
    {

        private readonly ICategoryRepository _repository;

        public SubjectFacade(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public SubjectsResponse GetAllSubjects(SubjectRequest request)
        {
            SubjectsResponse response = new SubjectsResponse
            {
                Subjects =
                    _repository.GetAll()
                        .Where(x => x.IsActive == 1)
                       .Select(b => new BookCategoryView
                        {
                            Id = b.Id,
                            CategoryNameBengali = b.NameB,
                            CategoryNameEnglish = b.NameE
                        })
            };


            var bookCategoryViews = response.Subjects as BookCategoryView[] ?? response.Subjects.ToArray();

            response.Initials =
                bookCategoryViews.Select(summary => summary.CategoryNameBengali.ToArray()[0].ToString()).ToList();

            response.CategoryCount = bookCategoryViews.Count();

            if (!string.IsNullOrEmpty(request.SearchString))
                bookCategoryViews = bookCategoryViews.Where(x => x.CategoryNameBengali.StartsWith(request.SearchString)).ToArray();

            response.Subjects = bookCategoryViews.Skip(request.Skip).Take(request.Take);
            

            return response;
        }
    }
}

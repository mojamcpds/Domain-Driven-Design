using System.Linq;
using DMS.Books.Models.PocoModels;
using DMS.SharedKernel.Infrastructure.FakeForTests;

namespace DMS.Books.Fakes
{
    public class FakeBookDbSet:FakeDbSet<Book,int>
    {

        public override Book Find(params object[] keyValues)
        {
            var keyValue = (int)keyValues.FirstOrDefault();
            return this.SingleOrDefault(p => p.Id == keyValue);
        }
    }
}

using System;
using DMS.Books.Services.Viewmodels;


namespace DMS.Books.Services.Messaging
{
    public class CreateBookRequest
    {
        public CreateBookRequest()
        {
            Create = new CreateBookView();
        }

        public CreateBookView Create { get; set; }
    }
}

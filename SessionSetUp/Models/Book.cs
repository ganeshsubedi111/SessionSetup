using System;
using System.Collections.Generic;

namespace SessionSetUp.models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Bookname { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Author { get; set; } = null!;
    }
}

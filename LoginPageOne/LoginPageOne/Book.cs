using System;
using SQLite;

namespace LoginPageOne
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
    }
}


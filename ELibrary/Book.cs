﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

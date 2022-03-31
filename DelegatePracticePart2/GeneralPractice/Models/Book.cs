using GeneralPractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Enums;

namespace GeneralPractice.Models
{
    internal class Book : IEntity
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public string Authorname { get; set; }     
        public int PageCount { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Book(string name,string authorName,int pageCount)
        {
            _id++;
            Id = _id;
            Authorname = authorName;
            Name = name;
            PageCount = pageCount;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"BookId: {Id} - Name: {Name} - Authorname: {Authorname} - PageCount: {PageCount} - IsDeleted: {IsDeleted}");
        }
    }
}

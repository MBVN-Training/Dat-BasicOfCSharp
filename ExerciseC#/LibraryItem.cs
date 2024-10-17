using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseC_
{
    public class LibraryItem
    {
        private int Id { get; set; } = 0;
        private string Title { get; set; }
        private string Author { get; set; }
        private DateTime PublicationDate { get; set; }

        public LibraryItem()
        {

        }

        public LibraryItem(int Id, string  Title, string Author, DateTime PublicationDate)
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
            this.PublicationDate = PublicationDate;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        // Phương thức getter và setter cho Title
        public string GetTitle()
        {
            return Title;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        // Phương thức getter và setter cho Author
        public string GetAuthor()
        {
            return Author;
        }

        public void SetAuthor(string author)
        {
            Author = author;
        }

        // Phương thức getter và setter cho PublicationDate
        public DateTime GetPublicationDate()
        {
            return PublicationDate;
        }

        public void SetPublicationDate(DateTime publicationDate)
        {
            PublicationDate = publicationDate;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Author: {Author}, Publication Date: {PublicationDate.ToShortDateString()}";
        }

    }
}

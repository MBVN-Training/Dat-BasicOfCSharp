using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseC_
{
    public class Book : LibraryItem
    {
        public int NumberOfPage { get; set; }
        public Book() { }
        public Book(LibraryItem library, int numberOfPage)
        : base(library.GetId(), library.GetTitle(), library.GetAuthor(), library.GetPublicationDate())  // Gọi constructor của lớp cha
        {
            NumberOfPage = numberOfPage;
        }

        public int GetNumberOfPage()
        {
            return NumberOfPage;
        }

        public void SetNumberOfPage(int numberOfPage)
        {
            NumberOfPage = numberOfPage;
        }

        public override string ToString()
        {
            return base.ToString() + $", Number of Pages: {NumberOfPage}, Type: Book";
        }

    }
}

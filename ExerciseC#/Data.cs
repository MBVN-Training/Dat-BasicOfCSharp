using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseC_
{
    public class Data
    {
        private static Data _instance;
        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Data();
                }
                return _instance;
            }
        }
        public Data()
        {

        }

        public List<LibraryItem> items = null;
        public List<Borrower> borrowers = null;
        public List<BorrowingHistory> histories = Service.Instance.borrowingHistories;

        public void InitializeLibraryData()
        {
            items = new List<LibraryItem>
                {
                    new Book(new LibraryItem(1, "Fishing for Beginners", "John Doe", new DateTime(2023, 10, 12)), 100),
                    new Book(new LibraryItem(2, "Advanced Cooking", "Jane Smith", new DateTime(2023, 11, 5)), 200),
                    new Book(new LibraryItem(3, "The History of Rome", "Mark Antony", new DateTime(2023, 9, 20)), 300),
                    new Book(new LibraryItem(4, "World of Programming", "Linus Torvalds", new DateTime(2023, 10, 25)), 400),
                    new Book(new LibraryItem(5, "Science in Everyday Life", "Albert Einstein", new DateTime(2023, 8, 14)), 250),
    
                    // DVDs with release dates in 2022
                    new DVD(new LibraryItem(6, "Nature's Wonders", "David Attenborough", new DateTime(2022, 5, 1)), 90.5),
                    new DVD(new LibraryItem(7, "90s Music Remastered", "Various Artists", new DateTime(2022, 6, 15)), 120.0),
                    new DVD(new LibraryItem(8, "Documentary on World War II", "Ken Burns", new DateTime(2022, 3, 20)), 150.0),
                    new DVD(new LibraryItem(9, "The Universe Explained", "Neil deGrasse Tyson", new DateTime(2022, 4, 10)), 180.5),

                    // Magazines
                    new Magazine(new LibraryItem(11, "Tech Today", "Various Authors", new DateTime(2023, 9, 15))),
                    new Magazine(new LibraryItem(12, "Health & Fitness", "Various Authors", new DateTime(2023, 8, 25))),
                    new Magazine(new LibraryItem(13, "Travel World", "Various Authors", new DateTime(2023, 7, 10))),
                    new Magazine(new LibraryItem(14, "Art & Design", "Various Authors", new DateTime(2023, 6, 30))),
                    new Magazine(new LibraryItem(15, "Business Insights", "Various Authors", new DateTime(2023, 5, 5)))
                };


            foreach (var item in items)
            {
                Service.Instance.AddNewItem(item);
            }
        }

        public void InitializeBorrowerData()
        {
            borrowers = new List<Borrower>
            {
                new Borrower("John Doe", "123 Main St", 1),
                new Borrower("Jane Smith", "456 Broadway", 2),
                new Borrower("Emily Brown", "789 Elm St", 3),
                new Borrower("Michael Johnson", "101 Pine St", 4),
                new Borrower("Sarah Davis", "202 Maple St", 5)
            };

            foreach (var borrower in borrowers)
            {
                Service.Instance.AddBorrower(borrower);
            }
        }

        public void BorrowItemsSampleData()
        {
            Service.Instance.BorrowItem<Book>(1, 1);
            Service.Instance.BorrowItem<DVD>(1, 6);
            Service.Instance.BorrowItem<Magazine>(1, 11);

            Service.Instance.BorrowItem<Book>(2, 2);
            Service.Instance.BorrowItem<DVD>(2, 7);
            Service.Instance.BorrowItem<Magazine>(2, 12);

            Service.Instance.BorrowItem<Book>(3, 3);
            Service.Instance.BorrowItem<DVD>(3, 8);
            Service.Instance.BorrowItem<Magazine>(3, 13);

            Service.Instance.BorrowItem<Book>(4, 4);
            Service.Instance.BorrowItem<DVD>(4, 9);
            Service.Instance.BorrowItem<Magazine>(4, 14);

            Service.Instance.BorrowItem<Book>(5, 5);
            Service.Instance.BorrowItem<DVD>(5, 10);
            Service.Instance.BorrowItem<Magazine>(5, 15);
        }


    }
}

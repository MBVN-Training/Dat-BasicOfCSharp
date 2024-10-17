using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExerciseC_
{
    public class Exercise2
    {
        private static Exercise2 _instance;
        public static Exercise2 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Exercise2();
                }
                return _instance;
            }
        }

        List<LibraryItem> items = Data.Instance.items;
        List<Borrower> borrowers = Data.Instance.borrowers;
        List<BorrowingHistory> histories = Data.Instance.histories;

        public Exercise2()
        {
            Data.Instance.InitializeLibraryData();
            Data.Instance.InitializeBorrowerData();
            Data.Instance.BorrowItemsSampleData();
        }

        public List<Book> getBookItem()
        {
            List<Book> books = (from item in items
                                where item is Book
                                select item).Cast<Book>().ToList();
            Console.Clear();
            return books;
        }

        public List<Book> orderListBook()
        {
            List<Book> ordered_book = (from item in items
                                       where item is Book
                                       orderby item.GetTitle() ascending
                                       select item).Cast<Book>().ToList();
            Console.Clear();
            return ordered_book;
        }

        public int countDVD()
        {
            int countedDVD = (from item in items
                              where item is DVD && item.GetPublicationDate().Year == 2022
                              select item).Count();
            Console.Clear();

            return countedDVD;
        }

        public List<Borrower> borrowersList()
        {
            List<Borrower> borrower = (from history in histories
                                       join item in items on history.GetIdItem() equals item.GetId()
                                       join borrow in borrowers on history.GetBorrowerLibraryCardNumber() equals borrow.GetLibraryCardNumber()
                                       where item is Book &&
                                       (from historyDVD in histories
                                       join itemDVD in items on historyDVD.GetIdItem() equals itemDVD.GetId()
                                       where itemDVD is DVD
                                       select historyDVD.GetBorrowerLibraryCardNumber()).Contains(borrow.GetLibraryCardNumber())
                                       select borrow).Distinct().ToList();
            Console.Clear();
            return borrower;

        }

    }
}

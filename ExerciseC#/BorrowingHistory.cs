using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExerciseC_
{
    public class BorrowingHistory
    {
        private int BorrowerLibraryCardNumber { get; set; }
        private DateTime BorrowDate { get; set; }
        private int IdItem { get; set; }
        private DateTime? ReturnDate { get; set; }

        public BorrowingHistory() { }

        public BorrowingHistory(int borrowerLibraryCardNumber, DateTime borrowDate, int idItem)
        {
            BorrowerLibraryCardNumber = borrowerLibraryCardNumber;
            BorrowDate = borrowDate;
            IdItem = idItem;
            ReturnDate = null;
        }

        public int GetBorrowerLibraryCardNumber()
        {
            return BorrowerLibraryCardNumber;
        }

        public void SetBorrowerLibraryCardNumber(int borrower)
        {
            BorrowerLibraryCardNumber = borrower;
        }
        public DateTime GetBorrowDate()
        {
            return BorrowDate;
        }
        public void SetBorrowDate(DateTime borrowDate)
        {
            BorrowDate = borrowDate;
        }
        public int GetIdItem()
        {
            return IdItem;
        }
        public void SetIdItem(int _IdItem)
        {
            IdItem = _IdItem;
        }

        public DateTime? GetReturnDate() 
        {
            return ReturnDate;
        }

        public void SetReturnDate(DateTime returnDate) 
        {
            ReturnDate = returnDate;
        }

        public override string ToString()
        {
            return "BorrowerLibraryCardNumber: " + BorrowerLibraryCardNumber + ", IdItem: " + IdItem + ", BorrowDate: " + BorrowDate.ToShortDateString() + ", ReturnDate: " + ReturnDate.ToString();
        }
    }
}

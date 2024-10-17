using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseC_
{
    public class Borrower
    {
        private string Name { get; set; }
        private string Address { get; set; }
        private int LibraryCardNumber { get; set; }
        public Borrower() { }
        public Borrower(string name, string address, int libraryCardNumber)
        {
            Name = name;
            Address = address;
            LibraryCardNumber = libraryCardNumber;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public string GetAddress()
        {
            return Address;
        }
        public void SetAddress(string address)
        {
            Address = address;
        }
        public int GetLibraryCardNumber()
        {
            return LibraryCardNumber;
        }
        public void SetLibraryCardNumber(int _LibraryCardNumber)
        {
            this.LibraryCardNumber = _LibraryCardNumber;
        }
        public override string ToString()
        {
            return "LibraryCardNumber: " + LibraryCardNumber + ", Name: " + Name + ", Address: " + Address;
        }
    }
}

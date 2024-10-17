using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace ExerciseC_
{
    public class Program
    {
        public static void Run()
        {
            Data.Instance.InitializeLibraryData();
            Data.Instance.InitializeBorrowerData();
            Data.Instance.BorrowItemsSampleData(); 

            bool running = true;
            while (running)
            {
                ShowMainMenu();
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    running = HandleUserChoice(choice);
                }
                else
                {
                    Console.WriteLine("Input khong hop le. Vui long nhap so.");
                }
            }
        }

        private static void ShowMainMenu()
        {
            Console.Clear(); 
            Console.WriteLine("==================================================================================");
            Console.WriteLine("       Chao mung ban den voi Chuong trinh quan ly thu vien cua Vo The Dat");
            Console.WriteLine("==================================================================================");
            Console.WriteLine("Hay nhap nut tuong ung:");
            Console.WriteLine();
            Console.WriteLine("    1. Xem");
            Console.WriteLine("    2. Them");
            Console.WriteLine("    3. Sua");
            Console.WriteLine("    4. Xoa");
            Console.WriteLine("    5. Kiem tra su ton tai");
            Console.WriteLine("    6. Dang ky muon sach");
            Console.WriteLine("    7. Muon sach");
            Console.WriteLine("    8. Tra sach");
            Console.WriteLine("    9. Loc danh sach la Book(Bai2)");
            Console.WriteLine("    10. Sap xep cac item Book theo thu tu(Bai2)");
            Console.WriteLine("    11. Dem DVD trong nam 2022(Bai2)");
            Console.WriteLine("    12. In danh sach Borrower vua muon Book vua muon DVD(Bai2)");
            Console.WriteLine("    13. Thoat");
            Console.WriteLine();
            Console.WriteLine("===================================================================");
            Console.WriteLine("                      Han hanh duoc phuc vu ban");
            Console.WriteLine("===================================================================");
            Console.Write("Nhap lua chon: ");
        }

        private static bool HandleUserChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    ShowItemList();
                    break;
                case 2:
                    AddNewItem();
                    break;
                case 3:
                    UpdateItem();
                    break;
                case 4:
                    DeleteItem();
                    break;
                case 5:
                    CheckItemExistence();
                    break;
                case 6:
                    AddBorrower();
                    break;
                case 7:
                    BorrowItem();
                    break;
                case 8:
                    ReturnItem();
                    break;
                case 9:
                    List<Book> books = Exercise2.Instance.getBookItem();
                    Service.Instance.DisplayTable(books);
                    Console.ReadLine();
                    break;
                case 10:
                    List<Book> orderBook = Exercise2.Instance.orderListBook();
                    Service.Instance.DisplayTable(orderBook);
                    Console.ReadLine();
                    break;
                case 11:
                    int countDVD = Exercise2.Instance.countDVD();
                    Console.WriteLine("The number of DVD is: " +  countDVD);
                    Console.ReadLine();
                    break;
                case 12:
                    List<Borrower> borrowers = Exercise2.Instance.borrowersList();
                    Service.Instance.DisplayTable(borrowers);
                    Console.ReadLine();
                    break;
                case 13:
                    Console.WriteLine("Thoat chuong trinh.");
                    return false;
                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    break;
            }
            return true; // Continue running
        }

        private static void ShowItemList()
        {
            Console.WriteLine("Danh sach cac item:");
            Console.WriteLine("1. Xem danh sach cac item hien co");
            Console.WriteLine("2. Danh sach nguoi muon");
            Console.WriteLine("3. Xem lich su muon");
            Console.WriteLine("4. Quay lai");
            Console.Write("Nhap lua chon: ");

            int subChoice;
            if (int.TryParse(Console.ReadLine(), out subChoice))
            {
                switch (subChoice)
                {
                    case 1:
                        Console.WriteLine("==============================================");
                        Console.WriteLine("Danh sach cac Item hien co:");
                        Service.Instance.DisplayTable(Service.Instance.items);
                        break;
                    case 2:
                        Console.WriteLine("==============================================");
                        Console.WriteLine("Danh sach nguoi muon:");
                        Service.Instance.DisplayTable(Service.Instance.borrowers);
                        break;
                    case 3:
                        Console.WriteLine("==============================================");
                        Console.WriteLine("Danh sach lich su muon:");
                        Service.Instance.DisplayTable(Service.Instance.borrowingHistories);
                        break;
                    //case 4:
                    //    return; // Go back to the main menu
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input khong hop le.");
            }
            //Console.WriteLine("Nhan phim bat ky de quay lai...");
            Console.ReadLine();
        }

        private static void AddNewItem()
        {
            Console.WriteLine("Ban muon them du lieu cua Item nao");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. DVD");
            Console.WriteLine("3. Magazine");
            Console.WriteLine("4. Quay lai");
            Console.Write("Nhap lua chon: ");
            int subChoice;
            if (int.TryParse(Console.ReadLine(), out subChoice))
            {
                switch (subChoice)
                {
                    case 1:
                        Console.WriteLine("==============================================");
                        Console.WriteLine("Enter details to add a new Book:");
                        Console.Write("Enter Book ID: ");
                        int Id = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Enter Book Title: ");
                        string Title = Console.ReadLine();
                        Console.Write("Enter Author Name: ");
                        string Author = Console.ReadLine();
                        Console.Write("Enter Publication Date (or press Enter to use today's date): ");
                        string dateInput = Console.ReadLine();
                        DateTime publicationDate = string.IsNullOrWhiteSpace(dateInput) ? DateTime.Now : DateTime.Parse(dateInput);
                        Console.Write("Enter Number of Pages: ");
                        int numberOfPages = int.Parse(Console.ReadLine() ?? "0");
                        Book newBook = new Book(new LibraryItem(Id, Title, Author, publicationDate), numberOfPages);
                        Service.Instance.AddNewItem<Book>(newBook);
                        Console.WriteLine("==============================================");
                        break;
                    case 2:
                        Console.WriteLine("==============================================");
                        Console.WriteLine("Enter details to add a new DVD:");
                        Console.Write("Enter DVD ID: ");
                        int _Id = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Enter DVD Title: ");
                        string _Title = Console.ReadLine();
                        Console.Write("Enter Author Name: ");
                        string _Author = Console.ReadLine();
                        Console.Write("Enter Publication Date (or press Enter to use today's date): ");
                        string _dateInput = Console.ReadLine();
                        DateTime _publicationDate = string.IsNullOrWhiteSpace(_dateInput) ? DateTime.Now : DateTime.Parse(_dateInput);
                        Console.Write("Enter Number of Runtimes: ");
                        int Runtime = int.Parse(Console.ReadLine() ?? "0");
                        DVD newDVD = new DVD(new LibraryItem(_Id, _Title, _Author, _publicationDate), Runtime);
                        Service.Instance.AddNewItem<DVD>(newDVD);
                        Console.WriteLine("==============================================");
                        break;
                    case 3:
                        Console.WriteLine("==============================================");
                        Console.WriteLine("Enter details to add a new magazine:");
                        Console.Write("Enter Magazine ID: ");
                        int __Id = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Enter Magazine Title: ");
                        string __Title = Console.ReadLine();
                        Console.Write("Enter Author Name: ");
                        string __Author = Console.ReadLine();
                        Console.Write("Enter Publication Date (or press Enter to use today's date): ");
                        string __dateInput = Console.ReadLine();
                        DateTime __publicationDate = string.IsNullOrWhiteSpace(__dateInput) ? DateTime.Now : DateTime.Parse(__dateInput);
                        Magazine newMagazine = new Magazine(new LibraryItem(__Id, __Title, __Author, __publicationDate));
                        Service.Instance.AddNewItem<Magazine>(newMagazine);
                        Console.WriteLine("==============================================");
                        break;
                    case 4:
                        return; // Go back to the main menu
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input khong hop le.");
            }
            Console.ReadLine();
        }
        private static void UpdateItem()
        {
            Console.WriteLine("Ban muon sua du lieu cua Item nao");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. DVD");
            Console.WriteLine("3. Magazine");
            Console.WriteLine("4. Quay lai");
            Console.Write("Nhap lua chon: ");

            int subChoice;
            if (int.TryParse(Console.ReadLine(), out subChoice))
            {
                switch (subChoice)
                {
                    case 1:
                        Console.WriteLine("==============================================");
                        Console.Write("Enter Book ID to update: ");
                        int bookId = int.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Enter new Book Title (or press Enter to keep current): ");
                        string newBookTitle = Console.ReadLine();
                        Console.Write("Enter new Author Name (or press Enter to keep current): ");
                        string newAuthor = Console.ReadLine();
                        Console.Write("Enter new Publication Date (or press Enter to keep current): ");
                        string bookDateInput = Console.ReadLine();
                        DateTime? newBookPublicationDate = string.IsNullOrWhiteSpace(bookDateInput) ? (DateTime?)null : DateTime.Parse(bookDateInput);
                        Console.Write("Enter new Number of Pages (or press Enter to keep current): ");
                        string numberOfPagesInput = Console.ReadLine();
                        int? newNumberOfPages = string.IsNullOrWhiteSpace(numberOfPagesInput) ? (int?)null : int.Parse(numberOfPagesInput);

                        // Call the update method
                        Service.Instance.UpdateItem<Book>(
                            bookId,
                            title: newBookTitle,
                            author: newAuthor,
                            publicationDate: newBookPublicationDate,
                            additionalParameter: newNumberOfPages);

                        Console.WriteLine("==============================================");
                        break;

                    case 2:
                        Console.WriteLine("==============================================");
                        Console.Write("Enter DVD ID to update: ");
                        int dvdId = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Enter new DVD Title (or press Enter to keep current): ");
                        string newDvdTitle = Console.ReadLine();
                        Console.Write("Enter new Author Name (or press Enter to keep current): ");
                        string newDvdAuthor = Console.ReadLine();
                        Console.Write("Enter new Publication Date (or press Enter to keep current): ");
                        string dvdDateInput = Console.ReadLine();
                        DateTime? newDvdPublicationDate = string.IsNullOrWhiteSpace(dvdDateInput) ? (DateTime?)null : DateTime.Parse(dvdDateInput);
                        Console.Write("Enter new Number of Runtimes (or press Enter to keep current): ");
                        string runtimeInput = Console.ReadLine();
                        double? newRuntime = string.IsNullOrWhiteSpace(runtimeInput) ? (double?)null : double.Parse(runtimeInput);

                        // Call the update method
                        Service.Instance.UpdateItem<DVD>(
                            dvdId,
                            title: newDvdTitle,
                            author: newDvdAuthor,
                            publicationDate: newDvdPublicationDate,
                            additionalParameter: newRuntime);

                        Console.WriteLine("==============================================");
                        break;

                    case 3:
                        Console.WriteLine("==============================================");
                        Console.Write("Enter Magazine ID to update: ");
                        int magazineId = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Enter new Magazine Title (or press Enter to keep current): ");
                        string newMagazineTitle = Console.ReadLine();
                        Console.Write("Enter new Author Name (or press Enter to keep current): ");
                        string newMagazineAuthor = Console.ReadLine();
                        Console.Write("Enter new Publication Date (or press Enter to keep current): ");
                        string magazineDateInput = Console.ReadLine();
                        DateTime? newMagazinePublicationDate = string.IsNullOrWhiteSpace(magazineDateInput) ? (DateTime?)null : DateTime.Parse(magazineDateInput);

                        // Call the update method
                        Service.Instance.UpdateItem<Magazine>(
                            magazineId,
                            title: newMagazineTitle,
                            author: newMagazineAuthor,
                            publicationDate: newMagazinePublicationDate);

                        Console.WriteLine("==============================================");
                        break;

                    case 4:
                        return; // Go back to the main menu
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input khong hop le.");
            }
            Console.ReadLine();
        }

        private static void AddBorrower()
        {
            Console.WriteLine("==============================================");
            Console.Write("Enter LibraryCardNumber: ");
            int LibraryCardNumber = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Name: ");
            string Name = Console.ReadLine();
            Console.Write("Enter Address: ");
            string Address = Console.ReadLine();

            Borrower borrower = new Borrower(Name, Address, LibraryCardNumber);

            Service.Instance.AddBorrower(borrower);
            Console.WriteLine("==============================================");
            Console.ReadLine();
        }

        private static void BorrowItem()
        {
            Console.Write("Nhap So The Thu Vien: ");
            int libraryCardNumber = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap ID Item: ");
            int itemId = int.Parse(Console.ReadLine() ?? "0");

            Service.Instance.BorrowItem<LibraryItem>(libraryCardNumber, itemId);
            Console.WriteLine("==============================================");
            Console.ReadLine();
        }

        private static void ReturnItem()
        {
            Console.Write("Nhap So The Thu Vien: ");
            int libraryCardNumber = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap ID Item: ");
            int itemId = int.Parse(Console.ReadLine() ?? "0");

            Service.Instance.ReturnItem<LibraryItem>(libraryCardNumber, itemId);
            Console.WriteLine("==============================================");
            Console.ReadLine();
        }

        private static void DeleteItem()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("Ban muon xoa Item nao");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. DVD");
            Console.WriteLine("3. Magazine");
            Console.WriteLine("4. Quay lai");
            Console.Write("Nhap lua chon: ");

            int subChoice;
            if (int.TryParse(Console.ReadLine(), out subChoice))
            {
                switch (subChoice)
                {
                    case 1:
                        Console.WriteLine("==============================================");
                        Console.Write("Enter Book ID to delete: ");
                        int bookId = int.Parse(Console.ReadLine() ?? "0");
                        Service.Instance.DeleteItem<Book>(bookId);
                        Console.WriteLine("==============================================");
                        break;

                    case 2:
                        Console.WriteLine("==============================================");
                        Console.Write("Enter DVD ID to delete: ");
                        int dvdId = int.Parse(Console.ReadLine() ?? "0");
                        Service.Instance.DeleteItem<DVD>(dvdId);
                        Console.WriteLine("==============================================");
                        break;

                    case 3:
                        Console.WriteLine("==============================================");
                        Console.Write("Enter Magazine ID to delete: ");
                        int magazineId = int.Parse(Console.ReadLine() ?? "0");
                        Service.Instance.DeleteItem<Magazine>(magazineId);
                        Console.WriteLine("==============================================");
                        break;

                    case 4:
                        return; // Go back to the main menu

                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input khong hop le.");
            }
            Console.ReadLine();
        }

        private static void CheckItemExistence()
        {
            Console.WriteLine("Ban muon kiem tra su ton tai cua Item nao");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. DVD");
            Console.WriteLine("3. Magazine");
            Console.WriteLine("4. Quay lai");
            Console.Write("Nhap lua chon: ");

            int subChoice;
            if (int.TryParse(Console.ReadLine(), out subChoice))
            {
                switch (subChoice)
                {
                    case 1:
                        Console.WriteLine("==============================================");
                        Console.Write("Nhap Book ID de kiem tra: ");
                        int bookId = int.Parse(Console.ReadLine() ?? "0");

                        bool bookExists = Service.Instance.CheckExistItem<Book>(bookId);
                        Console.WriteLine(bookExists ? "Book da ton tai." : "Book khong ton tai.");
                        Console.WriteLine("==============================================");
                        break;

                    case 2:
                        Console.WriteLine("==============================================");
                        Console.Write("Nhap DVD ID de kiem tra: ");
                        int dvdId = int.Parse(Console.ReadLine() ?? "0");

                        bool dvdExists = Service.Instance.CheckExistItem<DVD>(dvdId);
                        Console.WriteLine(dvdExists ? "DVD da ton tai." : "DVD khong ton tai.");
                        Console.WriteLine("==============================================");
                        break;

                    case 3:
                        Console.WriteLine("==============================================");
                        Console.Write("Nhap Magazine ID de kiem tra: ");
                        int magazineId = int.Parse(Console.ReadLine() ?? "0");

                        bool magazineExists = Service.Instance.CheckExistItem<Magazine>(magazineId);
                        Console.WriteLine(magazineExists ? "Magazine da ton tai." : "Magazine khong ton tai.");
                        Console.WriteLine("==============================================");
                        break;

                    case 4:
                        return; // Go back to the main menu
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input khong hop le.");
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Run();
        }
    }
}

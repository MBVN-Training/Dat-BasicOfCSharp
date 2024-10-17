using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseC_
{
    public class Service
    {
        private static Service _instance;
        public static Service Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Service();
                }
                return _instance;
            }
        }

        public Service()
        {
        }

        public List<LibraryItem> items = new List<LibraryItem>();
        public List<BorrowingHistory> borrowingHistories = new List<BorrowingHistory>();
        public List<Borrower> borrowers = new List<Borrower>();

        public List<LibraryItem> AddNewItem<T>(T newItem) where T : LibraryItem
        {
            if (newItem == null)
            {
                Console.WriteLine($"{typeof(T).Name} cannot be null.");
                return items;
            }

            bool exists = items.Any(item => item.GetId() == newItem.GetId());

            if (exists)
            {
                Console.WriteLine($"This {typeof(T).Name} already exists.");
                return items; 
            }

            try
            {
                items.Add(newItem);
                Console.WriteLine($"{typeof(T).Name} added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add {typeof(T).Name}: {ex.Message}");
            }
            return items;
        }

        public void GetData<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No items available.");
                return;
            }

            Console.WriteLine("==========================");

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public bool CheckExistItem<T>(int id) where T : LibraryItem
        {
            return items.Any(item => item.GetId() == id);
        }

        public void UpdateItem<T>(int ID, string title = null, string author = null, DateTime? publicationDate = null,
object additionalParameter = null) where T : LibraryItem
        {
            LibraryItem existingItem = items.FirstOrDefault(item => item.GetId() == ID);

            if (existingItem != null)
            {
                if (!string.IsNullOrEmpty(title))
                {
                    existingItem.SetTitle(title);
                }
                if (!string.IsNullOrEmpty(author))
                {
                    existingItem.SetAuthor(author);
                }
                if (publicationDate.HasValue)
                {
                    existingItem.SetPublicationDate(publicationDate.Value);
                }

                if (existingItem is Book book && additionalParameter is int numberOfPages)
                {
                    book.SetNumberOfPage(numberOfPages);
                }
                else if (existingItem is DVD dvd && additionalParameter is double runTime)
                {
                    dvd.SetRunTime(runTime);
                }
                Console.WriteLine($"{typeof(T).Name} updated successfully.");
            }
            else
            {
                Console.WriteLine($"{typeof(T).Name} khong ton tai.");
            }
        }

        public void DeleteItem<T>(int ID) where T : LibraryItem
        {
            // Find the item with the given ID
            LibraryItem itemToRemove = items.FirstOrDefault(item => item.GetId() == ID);

            // Check if the item exists
            if (itemToRemove == null)
            {
                Console.WriteLine($"This {typeof(T).Name} does not exist.");
                return;
            }

            try
            {
                items.Remove(itemToRemove);
                Console.WriteLine($"{typeof(T).Name} removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete {typeof(T).Name}: {ex.Message}");
            }
        }


        public void AddBorrower(Borrower borrower)
        {
            if (borrower == null)
            {
                Console.WriteLine("Borrower cannot be null");
                return;
            }

            bool exists = borrowers.Any(b => b.GetLibraryCardNumber() == borrower.GetLibraryCardNumber());
            if (exists)
            {
                Console.WriteLine("This borrower already exists.");
                return;
            }
            borrowers.Add(borrower);
            Console.WriteLine("Borrower added successfully.");
        }

        public bool BorrowItem<T>(int libraryCardNumber, int itemId)
        {
            var borrower = borrowers.FirstOrDefault(b => b.GetLibraryCardNumber() == libraryCardNumber);
            if (borrower == null)
            {
                Console.WriteLine("Borrower not found.");
                return false;
            }

            var item = items.FirstOrDefault(i => i.GetId() == itemId);
            if (item == null)
            {
                Console.WriteLine($"{typeof(T).Name} with ID {itemId} not found.");
                return false;
            }

            // Kiểm tra xem item có đang được mượn hay không
            var existingBorrow = borrowingHistories.FirstOrDefault(b => b.GetIdItem() == itemId && b.GetBorrowerLibraryCardNumber() == libraryCardNumber);
            if (existingBorrow != null)
            {
                Console.WriteLine($"{typeof(T).Name} is already borrowed.");
                return false;
            }

            var borrowingHistory = new BorrowingHistory(borrower.GetLibraryCardNumber(), DateTime.Now, itemId);

            borrowingHistories.Add(borrowingHistory);
            Console.WriteLine($"{typeof(T).Name} borrowed successfully.");
            return true;
        }

        public bool ReturnItem<T>(int libraryCardNumber, int itemId) 
        {
            var borrowingHistory = borrowingHistories.FirstOrDefault(b => b.GetIdItem() == itemId && b.GetBorrowerLibraryCardNumber() == libraryCardNumber);

            if (borrowingHistory == null)
            {
                Console.WriteLine($"{typeof(T).Name} with ID {itemId} is not currently borrowed.");
                return false;
            }

            borrowingHistory.SetReturnDate(DateTime.Now);
            Console.WriteLine($"{typeof(T).Name} returned successfully.");
            return true;
        }

        public void DisplayTable<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("No items available.");
                return;
            }

            // Bước 1: Tìm tất cả các headers từ chuỗi ToString() của từng đối tượng
            var headers = new HashSet<string>();
            var itemDicts = new List<Dictionary<string, string>>();

            foreach (var item in list)
            {
                var dict = item.ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(part =>
                                          {
                                              var parts = part.Split(new[] { ':' }, 2); // Tách chỉ ở dấu : đầu tiên
                                              return parts.Select(p => p.Trim()).ToArray();
                                          })
                                          .Where(parts => parts.Length == 2)
                                          .ToDictionary(parts => parts[0], parts => parts[1]);

                itemDicts.Add(dict);

                foreach (var key in dict.Keys)
                {
                    headers.Add(key);
                }
            }

            var headerList = headers.ToList();

            // Bước 2: Tính toán độ rộng của cột
            var columnWidths = new int[headerList.Count];
            for (int i = 0; i < headerList.Count; i++)
            {
                columnWidths[i] = headerList[i].Length;
            }

            foreach (var dict in itemDicts)
            {
                for (int i = 0; i < headerList.Count; i++)
                {
                    if (dict.TryGetValue(headerList[i], out var value))
                    {
                        columnWidths[i] = Math.Max(columnWidths[i], value.Length);
                    }
                }
            }

            // Bước 3: Tạo các phương thức phụ trợ
            string CenterText(string text, int width)
            {
                int padding = width - text.Length;
                int padLeft = padding / 2;
                int padRight = padding - padLeft;
                return new string(' ', padLeft) + text + new string(' ', padRight);
            }

            string CreateBorderRow()
            {
                return "+" + string.Join("+", columnWidths.Select(w => new string('-', w + 2))) + "+";
            }

            // Bước 4: In ra bảng với đường viền
            Console.WriteLine(CreateBorderRow());
            Console.WriteLine("| " + string.Join(" | ", headerList.Select((h, i) => CenterText(h, columnWidths[i]))) + " |");
            Console.WriteLine(CreateBorderRow());

            foreach (var dict in itemDicts)
            {
                var values = headerList.Select(h => dict.ContainsKey(h) ? dict[h] : "").ToList();
                Console.WriteLine("| " + string.Join(" | ", values.Select((v, i) => CenterText(v, columnWidths[i]))) + " |");
            }

            Console.WriteLine(CreateBorderRow());
        }
    }
}

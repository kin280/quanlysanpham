using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string filePath = "products.csv";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Hiển thị thông tin sản phẩm");
            Console.WriteLine("3. Tìm kiếm sản phẩm");
            Console.WriteLine("4. Thoát");
            Console.Write("Chọn một tùy chọn: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    DisplayProducts();
                    break;
                case "3":
                    SearchProduct();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Tùy chọn không hợp lệ. Hãy thử lại.");
                    break;
            }
        }
    }

    static void AddProduct()
    {
        Console.WriteLine("Nhập thông tin sản phẩm:");

        Console.Write("Mã sản phẩm: ");
        string code = Console.ReadLine();

        Console.Write("Tên sản phẩm: ");
        string name = Console.ReadLine();

        Console.Write("Hãng sản xuất: ");
        string manufacturer = Console.ReadLine();

        Console.Write("Giá: ");
        string price = Console.ReadLine();

        Console.Write("Mô tả khác: ");
        string description = Console.ReadLine();

        string productInfo = $"{code},{name},{manufacturer},{price},{description}";

        try
        {
            File.AppendAllLines(filePath, new List<string> { productInfo });
            Console.WriteLine("Sản phẩm đã được thêm thành công.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi thêm sản phẩm: {ex.Message}");
        }
    }

    static void DisplayProducts()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string[] products = File.ReadAllLines(filePath);

                Console.WriteLine("Danh sách sản phẩm:");

                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Không có sản phẩm nào được thêm.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi hiển thị sản phẩm: {ex.Message}");
        }
    }

    static void SearchProduct()
    {
        Console.Write("Nhập mã sản phẩm cần tìm kiếm: ");
        string searchCode = Console.ReadLine();

        try
        {
            if (File.Exists(filePath))
            {
                string[] products = File.ReadAllLines(filePath);

                Console.WriteLine("Kết quả tìm kiếm:");

                foreach (var product in products)
                {
                    if (product.Contains(searchCode))
                    {
                        Console.WriteLine(product);
                        return;
                    }
                }

                Console.WriteLine($"Không tìm thấy sản phẩm với mã {searchCode}.");
            }
            else
            {
                Console.WriteLine("Không có sản phẩm nào được thêm.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi tìm kiếm sản phẩm: {ex.Message}");
        }
    }
}

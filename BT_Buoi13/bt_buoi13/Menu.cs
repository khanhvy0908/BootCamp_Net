using Newtonsoft.Json;

public class Menu
{
    public List<SanPham> SanPhamList { get; set; }

    private const string MenuFilePath = "menu.json"; // Đường dẫn đến file lưu menu
    public Menu()
    {
        LoadMenuFromFile();

        if (SanPhamList == null)
        {
            SanPhamList = new List<SanPham>();
        }
    }


    // Tính tổng doanh thu dự kiến
    public void TinhTongDoanhThu()
    {
        if(SanPhamList == null || SanPhamList.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Danh sách sản phẩm trống.");
            Console.ResetColor();
            return;
        }
        double tongDoanhThu = SanPhamList.Sum(sp => sp.TinhGiaBan());
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nTổng doanh thu dự kiến: {tongDoanhThu}");
        Console.ResetColor();
        
    }

    // Xóa sản phẩm khỏi danh sách theo mã. 
    public void XoaSanPham()
    {
        // hien thi dánh sach truoc
        HienThiDanhSach();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nNhap ma san pham can xoa: ");
        Console.ResetColor();
        string ma = Console.ReadLine();

        SanPham sp = SanPhamList.FirstOrDefault(s => s.MaSanPham.Equals(ma, StringComparison.OrdinalIgnoreCase));

         if (sp == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Khong tim thay san pham.");
        Console.ResetColor();
        return;
    }

    SanPhamList.Remove(sp);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Da xoa san pham thanh cong.");
    Console.ResetColor();

    SaveMenuToFile();

    }


    // Hàm hiển thị danh sách sản phẩm
    public void HienThiDanhSach()
    {
        if (SanPhamList == null || SanPhamList.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Danh sách sản phẩm trống.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n===== DANH SACH DIEN TU =====");
        Console.ResetColor();
        foreach (var item in SanPhamList.Where(sp => sp is DienTu))
        {
            item.HienThi();
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n===== DANH SACH THOI TRANG =====");
        Console.ResetColor();
        foreach (var item in SanPhamList.Where(sp => sp is ThoiTrang))
        {
            item.HienThi();
        }
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n===== DANH SACH THUC PHAM ====="); 
        Console.ResetColor();
        foreach (var item in SanPhamList.Where(sp => sp is ThucPham))
        {
            item.HienThi();
        }


    }


    // Thêm sản phẩm vào danh sách
    public void ThemSanPham()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1.Thêm sản phẩm mới \n");
        Console.ResetColor();
        int loai;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Chon loai san pham:");
        Console.WriteLine("1. Dien Tu");
        Console.WriteLine("2. Thoi Trang");
        Console.WriteLine("3. Thuc Pham"); Console.ResetColor();
        loai = InputHandler.NhapSoNguyen(1, 3);

        Console.Write("Nhap ten san pham: ");
        string ten = Console.ReadLine();

        Console.Write("Nhap gia goc: ");
        double gia = double.Parse(Console.ReadLine());

        string ma = "";
        SanPham sp = null;

        switch (loai)
        {
            case 1:
                ma = TaoMaSanPham("DT");

                Console.Write("Nhap phi bao hanh: ");
                double phiBH = double.Parse(Console.ReadLine());

                sp = new DienTu(ma, ten, gia, phiBH);
                break;

            case 2:
                ma = TaoMaSanPham("TT");

                Console.Write("Nhap phan tram giam gia: ");
                double giam = double.Parse(Console.ReadLine());

                sp = new ThoiTrang(ma, ten, gia, giam);
                break;

            case 3:
                ma = TaoMaSanPham("TP");

                Console.Write("Nhap phi van chuyen: ");
                double phiVC = double.Parse(Console.ReadLine());

                sp = new ThucPham(ma, ten, gia, phiVC);
                break;
        }

        if (sp != null)
        {
            SanPhamList.Add(sp);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Da them san pham vao menu.");
        Console.ResetColor();

        SaveMenuToFile(); // Lưu menu sau khi thêm sản phẩm mới

    }

    // hàm tạo mã sản phẩm tự động dựa trên loại sản phẩm và số lượng sản phẩm đã có
    private string TaoMaSanPham(string prefix)
    {
        var danhSach = SanPhamList
            .Where(sp => sp.MaSanPham.StartsWith(prefix));

        if (!danhSach.Any())
            return prefix + "1";

        int max = danhSach.Max(sp =>
            int.Parse(sp.MaSanPham.Substring(prefix.Length)));

        return prefix + (max + 1);
    }




    // luu lai du lieu menu vao file
    public void SaveMenuToFile()
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        string json = JsonConvert.SerializeObject(SanPhamList, Formatting.Indented, settings);

        File.WriteAllText(MenuFilePath, json);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Da luu menu vao file.");
        Console.ResetColor();
    }



    // doc du lieu tu file va load vao menu
    public void LoadMenuFromFile()
    {
        if (File.Exists(MenuFilePath))
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            string json = File.ReadAllText(MenuFilePath);

            SanPhamList = JsonConvert.DeserializeObject<List<SanPham>>(json, settings);

            if (SanPhamList == null)
            {
                SanPhamList = new List<SanPham>();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Da load menu tu file.");
            Console.ResetColor();
        }
    }




    // Hiện thị menu chức năng
    public void HienThiMenu()
    {
        int choice;
        bool checkValid;
        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n===== MENU QUẢN LÝ SẢN PHẨM =====");
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm");
            Console.WriteLine("3. Tính tổng doanh thu dự kiến");
            Console.WriteLine("4. Xóa sản phẩm");
            Console.WriteLine("5. Thoát");
            Console.WriteLine("===================================");
            Console.Write("Vui lòng chọn chức năng (1-5): ");
            Console.ResetColor();

            choice = InputHandler.NhapSoNguyen(1, 5);
            switch (choice)
            {
                case 1:
                    ThemSanPham();
                    break;
                case 2:
                    HienThiDanhSach();
                    break;
                case 3:
                    TinhTongDoanhThu();
                    break;
                case 4:
                    XoaSanPham();
                    break;
                case 5:
                    Console.WriteLine("Thoát chương trình.");
                    return; // thoat khoi ham hien thi menu
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    Console.ResetColor();
                    break;

            }
        }
        while (true);
    }
}
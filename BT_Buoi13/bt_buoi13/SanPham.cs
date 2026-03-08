public abstract class SanPham
{
    public string MaSanPham { get; set; }
    public string TenSanPham { get; set; }
    public double GiaGoc { get; set; }



    public SanPham(string maSanPham, string tenSanPham, double giaGoc)
    {
        MaSanPham = maSanPham;
        TenSanPham = tenSanPham;
        GiaGoc = giaGoc;
    }

    public abstract double TinhGiaBan();
    // khi class con ke thua class nay thi
    // bat buoc phai override ham TinhGiaBan de tinh gia ban cho san pham do

    public virtual void HienThi()
    {
        Console.WriteLine($"Ma: {MaSanPham} | Ten: {TenSanPham} | Gia: {GiaGoc}");
    }


}
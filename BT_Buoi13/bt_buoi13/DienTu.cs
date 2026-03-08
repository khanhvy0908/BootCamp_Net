public class DienTu : SanPham
{
    public double PhiBaoHanh { get; set; }

    public DienTu(string maSanPham, string tenSanPham, double giaGoc, double phiBaoHanh)
        : base(maSanPham, tenSanPham, giaGoc)
    {
        PhiBaoHanh = phiBaoHanh;
    }

    public override void HienThi()
{
    Console.WriteLine($"[Dien Tu] Ma: {MaSanPham} | Ten: {TenSanPham} | Gia: {GiaGoc} | Phi BH: {PhiBaoHanh}");
}


    public override double TinhGiaBan()
    {
        return GiaGoc + PhiBaoHanh;
    }
}
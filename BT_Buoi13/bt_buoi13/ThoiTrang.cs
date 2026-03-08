public class ThoiTrang : SanPham
{
    public double PhanTramGiam { get; set; }

    public ThoiTrang(string ma, string ten, double gia, double giam)
        : base(ma, ten, gia)
    {
        PhanTramGiam = giam;
    }

    public override double TinhGiaBan()
    {
        return GiaGoc - (GiaGoc * PhanTramGiam / 100);
    }

    public override void HienThi()
    {
        Console.WriteLine($"[Thoi Trang] Ma: {MaSanPham} | Ten: {TenSanPham} | Gia: {GiaGoc} | Giam gia: {PhanTramGiam}%");
    }

}

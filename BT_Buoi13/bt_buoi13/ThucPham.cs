public class ThucPham : SanPham
{
    public double PhiVanChuyen { get; set; }

    public ThucPham(string ma, string ten, double gia, double phiVC)
        : base(ma, ten, gia)
    {
        PhiVanChuyen = phiVC;
    }

    public override double TinhGiaBan()
    {
        return GiaGoc + PhiVanChuyen;
    }

    public override void HienThi()
    {
        Console.WriteLine($"[Thuc Pham] Ma: {MaSanPham} | Ten: {TenSanPham} | Gia: {GiaGoc} | Phi VC: {PhiVanChuyen}");
    }

}

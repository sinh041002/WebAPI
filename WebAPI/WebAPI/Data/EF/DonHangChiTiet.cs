namespace WebAPI.Data.EF
{
    public class DonHangChiTiet
    {
        public Guid MaHh { get; set; }
        public Guid MaDH { get; set; }

        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }


        //relationship
        public DonHang donHang { get; set; }
        public HangHoa hangHoa { get; set; }
    }
}

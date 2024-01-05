namespace WebAPI.Data.EF
{
    public enum TinhTrangDonDatHang
    {
        New=0, paymen=1, Comple=2,Cancel=-1
    }
    public class DonHang
    {
        
        public Guid MaDonHang { get; set; }
        public DateTime NgayDatHang { get; set; }
        public DateTime NgayGiaoHang { get; set; }  
        public TinhTrangDonDatHang TinhTrangDonDatHang { get; set; }    

        public string NguoiNhanHang { get; set; }
        public string DiaChiGiaoHang { get;set; }
        public string SoDienThoai { get; set; }

        public  ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }

    }
}

namespace WebAPI.Model
{
    public class HangHoaVM
    {
        public string TenHangHoa { get; set; }
        public double GiaHangHoa { get; set; }

    }
    public class HangHoa : HangHoaVM
    {
        public Guid MaHangHoa { get; set; }
      

    }
}

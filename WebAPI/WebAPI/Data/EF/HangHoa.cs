﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data.EF
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        [Required]
        public Guid MaHangHoa { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenHangHoa { get;set; }
        public string MoTa { get; set; }
        public byte GiamGia { get; set; }
        [Range(0,double.MaxValue)]        
        
        public Double Gia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

        public  ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        public HangHoa()
        {
            DonHangChiTiets=new List<DonHangChiTiet>();
        }
    }
}

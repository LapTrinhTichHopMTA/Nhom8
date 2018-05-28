using Nhom8.DataAccess.Models.LoaiSanPham;
using Nhom8.DataAccess.Models.NhaSanXuat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8.DataAccess.Models.SanPham
{
    public class SanPham_OBJ
    {
        public int MaSanPham { get; set; }

        [StringLength(100)]
        public string TenSanPham { get; set; }

        public int? SoLuongTon { get; set; }

        public decimal? DonGia { get; set; }

        public string MoTa { get; set; }

        [StringLength(100)]
        public string AnhBia { get; set; }

        public int? MaNhaSanXuat { get; set; }

        public int? MaLoaiSanPham { get; set; }

        public bool? HienThi { get; set; }
    }
}

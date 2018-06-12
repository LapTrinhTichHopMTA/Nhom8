using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8.DataAccess.Models.TaiKhoan
{
    public class TaiKhoan_OBJ
    {
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        public int MaNguoiDung { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayCapNhap { get; set; }

        public bool? HienThi { get; set; }

        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        public string DiaChi { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }
    }
}

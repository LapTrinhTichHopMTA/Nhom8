using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8.DataAccess.Models.NhanVien
{
    public class NhanVien_OBJ
    {

        public int MaNhanVien { get; set; }

        [StringLength(20)]
        public string ChungMinhThu { get; set; }

        [StringLength(100)]
        public string TenNhanVien { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string ChucVu { get; set; }

        public decimal? TienLuong { get; set; }

        public bool? HienThi { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }


      ///  public virtual ICollection<PhanCong> PhanCongs { get; set; }
    }
}

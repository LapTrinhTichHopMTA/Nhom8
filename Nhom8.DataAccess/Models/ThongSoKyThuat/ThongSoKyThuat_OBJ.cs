using Nhom8.DataAccess.Models.SanPham;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8.DataAccess.Models.ThongSoKyThuat
{
    public class ThongSoKyThuat_OBJ
    {
   
        public int MaMay { get; set; }

        public int MaSanPham { get; set; }

        [StringLength(100)]
        public string Ram { get; set; }

        [StringLength(100)]
        public string ManHinh { get; set; }

        [StringLength(100)]
        public string CPU { get; set; }

        [StringLength(100)]
        public string HeDieuHanh { get; set; }

        [StringLength(100)]
        public string OCung { get; set; }

        [StringLength(100)]
        public string KichThuoc { get; set; }

        [StringLength(100)]
        public string CongKetNoi { get; set; }

        [StringLength(100)]
        public string CacManHinh { get; set; }

        public bool? HienThi { get; set; }

        public virtual SanPham_OBJ SanPham { get; set; }
    }
}

using Nhom8.DataAccess.Models.SanPham;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8.DataAccess.Models.LoaiSanPham
{
    public class LoaiSanPham_OBJ
    {
        public int MaLoaiSanPham { get; set; }

        [StringLength(100)]
        public string TenLoaiSanPham { get; set; }

        [StringLength(100)]
        public string DonViTinh { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public bool? HienThi { get; set; }

        [StringLength(50)]
        public string AnhBia { get; set; }

        //public virtual ICollection<SanPham_OBJ> SanPhams { get; set; }
    }
}

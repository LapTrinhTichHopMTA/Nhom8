using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8.DataAccess.Models.NhaSanXuat
{
    public class NhaSanXuat_OBJ
    {
        public int MaNhaSanXuat { get; set; }

        [StringLength(100)]
        public string TenNhaSanXuat { get; set; }

        [StringLength(100)]
        public string QuocGia { get; set; }

        public bool? HienThi { get; set; }
    }
}

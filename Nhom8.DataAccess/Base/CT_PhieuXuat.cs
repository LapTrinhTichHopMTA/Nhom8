namespace Nhom8.DataAccess.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PhieuXuat
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPhieuXuat { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSanPham { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal? DonGia { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaKhuyenMai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public bool? HienThi { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}

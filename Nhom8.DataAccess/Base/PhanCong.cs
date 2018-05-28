namespace Nhom8.DataAccess.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanCong")]
    public partial class PhanCong
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNhanVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDonHang { get; set; }

        public DateTime? NgayGiaoHang { get; set; }

        [StringLength(10)]
        public string SoCong { get; set; }

        public decimal? SoTienNop { get; set; }

        [StringLength(50)]
        public string NguoiTao { get; set; }

        public DateTime? NgayTao { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}

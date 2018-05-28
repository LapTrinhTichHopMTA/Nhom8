namespace Nhom8.DataAccess.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CT_PhieuXuat = new HashSet<CT_PhieuXuat>();
            ThongSoKyThuats = new HashSet<ThongSoKyThuat>();
        }

        [Key]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuXuat> CT_PhieuXuat { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongSoKyThuat> ThongSoKyThuats { get; set; }
    }
}

namespace Nhom8.DataAccess.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSanPham")]
    public partial class LoaiSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}

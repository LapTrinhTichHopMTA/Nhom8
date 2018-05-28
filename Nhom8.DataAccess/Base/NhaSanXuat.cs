namespace Nhom8.DataAccess.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaSanXuat()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        public int MaNhaSanXuat { get; set; }

        [StringLength(100)]
        public string TenNhaSanXuat { get; set; }

        [StringLength(100)]
        public string QuocGia { get; set; }

        public bool? HienThi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}

namespace Nhom8.DataAccess.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongSoKyThuat")]
    public partial class ThongSoKyThuat
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMay { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public virtual SanPham SanPham { get; set; }
    }
}

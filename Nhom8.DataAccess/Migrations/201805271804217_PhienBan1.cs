namespace Nhom8.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhienBan1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CT_PhieuXuat",
                c => new
                    {
                        MaPhieuXuat = c.Int(nullable: false),
                        MaSanPham = c.Int(nullable: false),
                        SoLuong = c.Int(),
                        DonGia = c.Decimal(storeType: "money"),
                        GiaKhuyenMai = c.Decimal(storeType: "money"),
                        GhiChu = c.String(maxLength: 100),
                        HienThi = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.MaPhieuXuat, t.MaSanPham })
                .ForeignKey("dbo.PhieuXuat", t => t.MaPhieuXuat, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.MaSanPham, cascadeDelete: true)
                .Index(t => t.MaPhieuXuat)
                .Index(t => t.MaSanPham);
            
            CreateTable(
                "dbo.PhieuXuat",
                c => new
                    {
                        MaPhieuXuat = c.Int(nullable: false, identity: true),
                        MaKhachHang = c.Int(nullable: false),
                        TinhTrangGiaoHang = c.Int(),
                        NgayDatHang = c.DateTime(),
                        HienThi = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaPhieuXuat)
                .ForeignKey("dbo.KhachHang", t => t.MaKhachHang, cascadeDelete: true)
                .Index(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKhachHang = c.Int(nullable: false, identity: true),
                        TenKhachHang = c.String(maxLength: 100),
                        NgaySinh = c.DateTime(),
                        GioiTinh = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100, fixedLength: true, unicode: false),
                        SoDienThoai = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        HienThi = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.PhanCong",
                c => new
                    {
                        MaNhanVien = c.Int(nullable: false),
                        MaDonHang = c.Int(nullable: false),
                        NgayGiaoHang = c.DateTime(),
                        SoCong = c.String(maxLength: 10, fixedLength: true),
                        SoTienNop = c.Decimal(precision: 18, scale: 2),
                        NguoiTao = c.String(maxLength: 50, unicode: false),
                        NgayTao = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.MaNhanVien, t.MaDonHang })
                .ForeignKey("dbo.NhanVien", t => t.MaNhanVien, cascadeDelete: true)
                .ForeignKey("dbo.TaiKhoan", t => t.NguoiTao)
                .ForeignKey("dbo.PhieuXuat", t => t.MaDonHang, cascadeDelete: true)
                .Index(t => t.MaNhanVien)
                .Index(t => t.MaDonHang)
                .Index(t => t.NguoiTao);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNhanVien = c.Int(nullable: false, identity: true),
                        ChungMinhThu = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        TenNhanVien = c.String(maxLength: 100),
                        NgaySinh = c.DateTime(),
                        GioiTinh = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 100),
                        SoDienThoai = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        ChucVu = c.String(maxLength: 100),
                        TienLuong = c.Decimal(storeType: "money"),
                        HienThi = c.Boolean(),
                        HinhAnh = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        TenTaiKhoan = c.String(nullable: false, maxLength: 50, unicode: false),
                        MatKhau = c.String(maxLength: 100, unicode: false),
                        MaNguoiDung = c.Int(nullable: false, identity: true),
                        NgayTao = c.DateTime(),
                        NgayCapNhap = c.DateTime(),
                        HienThi = c.Boolean(),
                        TenNguoiDung = c.String(maxLength: 50),
                        NgaySinh = c.DateTime(),
                        GioiTinh = c.String(maxLength: 50),
                        DiaChi = c.String(),
                        DienThoai = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TenTaiKhoan);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        TenSanPham = c.String(maxLength: 100),
                        SoLuongTon = c.Int(),
                        DonGia = c.Decimal(precision: 18, scale: 2),
                        MoTa = c.String(),
                        AnhBia = c.String(maxLength: 100),
                        MaNhaSanXuat = c.Int(),
                        MaLoaiSanPham = c.Int(),
                        HienThi = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaSanPham)
                .ForeignKey("dbo.LoaiSanPham", t => t.MaLoaiSanPham, cascadeDelete: true)
                .ForeignKey("dbo.NhaSanXuat", t => t.MaNhaSanXuat)
                .Index(t => t.MaNhaSanXuat)
                .Index(t => t.MaLoaiSanPham);
            
            CreateTable(
                "dbo.LoaiSanPham",
                c => new
                    {
                        MaLoaiSanPham = c.Int(nullable: false, identity: true),
                        TenLoaiSanPham = c.String(maxLength: 100),
                        DonViTinh = c.String(maxLength: 100),
                        GhiChu = c.String(maxLength: 100),
                        HienThi = c.Boolean(),
                        AnhBia = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaLoaiSanPham);
            
            CreateTable(
                "dbo.NhaSanXuat",
                c => new
                    {
                        MaNhaSanXuat = c.Int(nullable: false, identity: true),
                        TenNhaSanXuat = c.String(maxLength: 100),
                        QuocGia = c.String(maxLength: 100),
                        HienThi = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaNhaSanXuat);
            
            CreateTable(
                "dbo.ThongSoKyThuat",
                c => new
                    {
                        MaMay = c.Int(nullable: false),
                        MaSanPham = c.Int(nullable: false),
                        Ram = c.String(maxLength: 100),
                        ManHinh = c.String(maxLength: 100),
                        CPU = c.String(maxLength: 100),
                        HeDieuHanh = c.String(maxLength: 100),
                        OCung = c.String(maxLength: 100),
                        KichThuoc = c.String(maxLength: 100),
                        CongKetNoi = c.String(maxLength: 100),
                        CacManHinh = c.String(maxLength: 100),
                        HienThi = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.MaMay, t.MaSanPham })
                .ForeignKey("dbo.SanPham", t => t.MaSanPham, cascadeDelete: true)
                .Index(t => t.MaSanPham);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThongSoKyThuat", "MaSanPham", "dbo.SanPham");
            DropForeignKey("dbo.SanPham", "MaNhaSanXuat", "dbo.NhaSanXuat");
            DropForeignKey("dbo.SanPham", "MaLoaiSanPham", "dbo.LoaiSanPham");
            DropForeignKey("dbo.CT_PhieuXuat", "MaSanPham", "dbo.SanPham");
            DropForeignKey("dbo.PhanCong", "MaDonHang", "dbo.PhieuXuat");
            DropForeignKey("dbo.PhanCong", "NguoiTao", "dbo.TaiKhoan");
            DropForeignKey("dbo.PhanCong", "MaNhanVien", "dbo.NhanVien");
            DropForeignKey("dbo.PhieuXuat", "MaKhachHang", "dbo.KhachHang");
            DropForeignKey("dbo.CT_PhieuXuat", "MaPhieuXuat", "dbo.PhieuXuat");
            DropIndex("dbo.ThongSoKyThuat", new[] { "MaSanPham" });
            DropIndex("dbo.SanPham", new[] { "MaLoaiSanPham" });
            DropIndex("dbo.SanPham", new[] { "MaNhaSanXuat" });
            DropIndex("dbo.PhanCong", new[] { "NguoiTao" });
            DropIndex("dbo.PhanCong", new[] { "MaDonHang" });
            DropIndex("dbo.PhanCong", new[] { "MaNhanVien" });
            DropIndex("dbo.PhieuXuat", new[] { "MaKhachHang" });
            DropIndex("dbo.CT_PhieuXuat", new[] { "MaSanPham" });
            DropIndex("dbo.CT_PhieuXuat", new[] { "MaPhieuXuat" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.ThongSoKyThuat");
            DropTable("dbo.NhaSanXuat");
            DropTable("dbo.LoaiSanPham");
            DropTable("dbo.SanPham");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.NhanVien");
            DropTable("dbo.PhanCong");
            DropTable("dbo.KhachHang");
            DropTable("dbo.PhieuXuat");
            DropTable("dbo.CT_PhieuXuat");
        }
    }
}

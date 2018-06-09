using Nhom8.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nhom8.DataAccess.Models.LoaiSanPham;
using System.Data.Entity;

namespace Nhom8.DataAccess.Models.SanPham
{
    public class SanPham_BUS
    {
        public IEnumerable<SanPham_OBJ> HienThiDanhSachSanPham()
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                IList<SanPham_OBJ> DanhSach = new List<SanPham_OBJ>();
                var query = db.SanPhams.ToList();
                foreach (var item in query)
                {
                    DanhSach.Add(new SanPham_OBJ()
                    {
                        MaSanPham = item.MaSanPham,
                        TenSanPham = item.TenSanPham,
                        SoLuongTon = item.SoLuongTon,
                        DonGia = item.DonGia,
                        MoTa = item.MoTa,
                        AnhBia = item.AnhBia,
                        MaLoaiSanPham = item.MaLoaiSanPham,
                        MaNhaSanXuat = item.MaLoaiSanPham,
                        HienThi = item.HienThi
               
                    });
                }
                return DanhSach;
            }
            catch
            {
                return null;
            }
        }

        public SanPham_OBJ HienThiSanPhamTheoID(int MaSanPham)
        {

            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                var item = (from SanPham in db.SanPhams where SanPham.MaSanPham == MaSanPham select SanPham).SingleOrDefault();

                SanPham_OBJ sanPhamModels = new SanPham_OBJ()
                {
                    MaSanPham = item.MaSanPham,
                    TenSanPham = item.TenSanPham,
                    SoLuongTon = item.SoLuongTon,
                    DonGia = item.DonGia,
                    MoTa = item.MoTa,
                    AnhBia = item.AnhBia,
                    MaLoaiSanPham = item.MaLoaiSanPham,
                    MaNhaSanXuat = item.MaLoaiSanPham,
                    HienThi = item.HienThi
                };
                return sanPhamModels;
            }
            catch
            {
                return null;
            }
        }


        public bool ThemMoiSanPham(SanPham_OBJ obj)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                Base.SanPham sanPham = new Base.SanPham
                {
                    MaSanPham = obj.MaSanPham,
                    TenSanPham = obj.TenSanPham,
                    SoLuongTon = obj.SoLuongTon,
                    DonGia = obj.DonGia,
                    MoTa = obj.MoTa,
                    AnhBia = obj.AnhBia,
                    MaLoaiSanPham = obj.MaLoaiSanPham,
                    MaNhaSanXuat = obj.MaLoaiSanPham,
                    HienThi = obj.HienThi
                };
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
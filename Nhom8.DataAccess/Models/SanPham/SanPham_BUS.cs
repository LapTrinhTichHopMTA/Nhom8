using Nhom8.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nhom8.DataAccess.Models.LoaiSanPham;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Nhom8.DataAccess.Models.SanPham
{
    public class SanPham_BUS
    {
        MayTinhDbContext db = new MayTinhDbContext();


        public SanPham_OBJ Mapper(Base.SanPham item)
        {
            SanPham_OBJ obj = new SanPham_OBJ()
            {
                MaSanPham = item.MaSanPham,
                TenSanPham = item.TenSanPham,
                SoLuongTon = item.SoLuongTon,
                DonGia = item.DonGia,
                MoTa = item.MoTa,
                AnhBia = item.AnhBia,
                MaLoaiSanPham = item.MaLoaiSanPham,
                MaNhaSanXuat = item.MaNhaSanXuat,
                HienThi = item.HienThi
            };
            return obj;
        }

        public Base.SanPham MapperBase(SanPham_OBJ obj)
        {
            Base.SanPham bs = new Base.SanPham()
            {
                MaSanPham = obj.MaSanPham,
                TenSanPham = obj.TenSanPham,
                SoLuongTon = obj.SoLuongTon,
                DonGia = obj.DonGia,
                MoTa = obj.MoTa,
                AnhBia = obj.AnhBia,
                MaLoaiSanPham = obj.MaLoaiSanPham,
                MaNhaSanXuat = obj.MaNhaSanXuat,
                HienThi = obj.HienThi
            };
            return bs; 
        }

        public IEnumerable<SanPham_OBJ> HienThiDanhSachSanPham()
        {
            try
            {

                IList<SanPham_OBJ> DanhSach = new List<SanPham_OBJ>();
                var query = db.SanPhams.ToList();
                foreach (var item in query)
                {
                    DanhSach.Add(Mapper(item));
                }
                return DanhSach;
            }
            catch
            {
                return null;
            }
        }




        public IEnumerable<SanPham_OBJ> TimKiemThongTinSanPham(string TuKhoa)
        {
            try
            {
                TuKhoa = TuKhoa.Trim();

                IList<SanPham_OBJ> DanhSach = new List<SanPham_OBJ>();
                var query = from sanphan in db.SanPhams
                            where sanphan.TenSanPham.Trim() == TuKhoa ||
                            sanphan.NhaSanXuat.TenNhaSanXuat.Trim() == TuKhoa ||
                            sanphan.LoaiSanPham.TenLoaiSanPham.Trim() == TuKhoa
                            select sanphan;

                foreach (var item in query)
                {
                    DanhSach.Add(Mapper(item));
                }
                return DanhSach;

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<SanPham_OBJ> TimKiemThongTinTheoMaLoaiSanPham(int MaLoaiSanPham)
        {
            try
            {


                IList<SanPham_OBJ> DanhSach = new List<SanPham_OBJ>();
                var query = from sanphan in db.SanPhams
                            where sanphan.MaLoaiSanPham == MaLoaiSanPham 
                            select sanphan;

                foreach (var item in query)
                {
                    DanhSach.Add(Mapper(item));
                }
                return DanhSach;

            }
            catch
            {
                return null;
            }
        }


        public IEnumerable<SanPham_OBJ> TimKiemThongTinTheoNhaSanXuat(int MaNhaSanXuat)
        {
            try
            {


                IList<SanPham_OBJ> DanhSach = new List<SanPham_OBJ>();
                var query = from sanphan in db.SanPhams
                            where sanphan.MaNhaSanXuat==MaNhaSanXuat
                            select sanphan;

                foreach (var item in query)
                {
                    DanhSach.Add(Mapper(item));
                }
                return DanhSach;

            }
            catch
            {
                return null;
            }
        }


        public IEnumerable<SanPham_OBJ> TimKiemThongTinTheoNhaSanXuatVsLoaiSanPham(int MaNhaSanXuat,int LoaiSanPham)
        {
            try
            {


                IList<SanPham_OBJ> DanhSach = new List<SanPham_OBJ>();
                var query = from sanphan in db.SanPhams
                            where sanphan.MaNhaSanXuat == MaNhaSanXuat && sanphan.MaLoaiSanPham == LoaiSanPham
                            select sanphan;

                foreach (var item in query)
                {
                    DanhSach.Add(Mapper(item));
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

                var item = (
                    from SanPham in db.SanPhams
                    where SanPham.MaSanPham == MaSanPham
                    select SanPham).SingleOrDefault();
                return Mapper(item);
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
                db.SanPhams.Add(MapperBase(obj));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhapSanPham(SanPham_OBJ obj)
        {
            try
            {
                db.Entry(MapperBase(obj)).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void save()
        {
            db.SaveChanges();
        }

        public bool SanPhamExists(int id)
        {
            return db.SanPhams.Count(e => e.MaLoaiSanPham == id) > 0;
        }

        public SanPham_OBJ XoaSanPham(int id)
        {
            Base.SanPham sp = db.SanPhams.Find(id);
            if (sp == null)
            {
                return null;
            }
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return Mapper(sp);
        }
    }
}
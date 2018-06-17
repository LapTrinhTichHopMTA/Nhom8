using Nhom8.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8.DataAccess.Models.LoaiSanPham
{
    public class LoaiSanPham_BUS
    {
        public LoaiSanPham_OBJ Mapper(Base.LoaiSanPham item)
        {

            LoaiSanPham_OBJ obj = new LoaiSanPham_OBJ()
            {
                MaLoaiSanPham = item.MaLoaiSanPham,
                TenLoaiSanPham = item.TenLoaiSanPham,
                DonViTinh = item.DonViTinh,
                AnhBia = item.AnhBia,
                HienThi = item.HienThi,
                GhiChu = item.GhiChu
            };
            return obj;
        }

        public  Base.LoaiSanPham MapperBase(LoaiSanPham_OBJ obj)
        {

            Base.LoaiSanPham item = new Base.LoaiSanPham()
            {
                MaLoaiSanPham = obj.MaLoaiSanPham,
                TenLoaiSanPham = obj.TenLoaiSanPham,
                DonViTinh = obj.DonViTinh,
                AnhBia = obj.AnhBia,
                HienThi = obj.HienThi,
                GhiChu = obj.GhiChu
            };
            return item;
        }

        public IEnumerable<LoaiSanPham_OBJ> HienThiDanhSachLoaiSanPham()
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                IList<LoaiSanPham_OBJ> DanhSach = new List<LoaiSanPham_OBJ>();
                var query = db.LoaiSanPhams.ToList();
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

        public IEnumerable<LoaiSanPham_OBJ> TimKiemThongTinSanPham(string TuKhoa)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                IList<LoaiSanPham_OBJ> DanhSach = new List<LoaiSanPham_OBJ>();
                TuKhoa = TuKhoa.Trim();

                if (string.IsNullOrEmpty(TuKhoa) == false)
                {
                    var query = from item in db.LoaiSanPhams
                                where item.TenLoaiSanPham.Trim() == TuKhoa ||
                                item.DonViTinh.Trim() == TuKhoa ||
                                item.GhiChu.Trim() == TuKhoa
                                select item;
                    foreach (var item in query)
                    {
                        DanhSach.Add(Mapper(item));
                    }
                    return DanhSach;
                }
                return null; 
            }
            catch
            {
                return null;
            }
        }

        public LoaiSanPham_OBJ GetMa(int MaLoaiSanPham)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                var items = (from item in db.LoaiSanPhams
                             where item.MaLoaiSanPham == MaLoaiSanPham
                             select item).SingleOrDefault();
                return Mapper(items);
            }
            catch
            {
                return null;
            }
        }


        public bool ThemMoi(LoaiSanPham_OBJ obj)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                db.LoaiSanPhams.Add(MapperBase(obj));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhap(LoaiSanPham_OBJ obj)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                Base.LoaiSanPham item = MapperBase(obj);
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public LoaiSanPham_OBJ Xoa(int id)
        {
            MayTinhDbContext db = new MayTinhDbContext();
            Base.LoaiSanPham item = db.LoaiSanPhams.Find(id);
            if (item == null)
            {
                return null;
            }
            db.LoaiSanPhams.Remove(item);
            db.SaveChanges();
            return Mapper(item);
        }
    }
}

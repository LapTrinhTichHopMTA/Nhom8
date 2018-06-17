using Nhom8.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8.DataAccess.Models.TaiKhoan
{
    public class TaiKhoan_BUS
    {
        public TaiKhoan_OBJ Mapper(Base.TaiKhoan item)
        {
            TaiKhoan_OBJ obj = new TaiKhoan_OBJ()
            {
                TenTaiKhoan = item.TenTaiKhoan,
                TenNguoiDung = item.TenNguoiDung,
                MatKhau = item.MatKhau,
                HienThi = item.HienThi,
                NgayTao = item.NgayTao,
                NgayCapNhap = item.NgayCapNhap,
                DiaChi = item.DiaChi,
                DienThoai = item.DienThoai,
                GioiTinh = item.GioiTinh,
                MaNguoiDung = item.MaNguoiDung,
                NgaySinh = item.NgaySinh, 
            };
            return obj;
        }


        public Base.TaiKhoan MapperBase(TaiKhoan_OBJ obj)
        {
            Base.TaiKhoan item = new Base.TaiKhoan()
            {
                TenTaiKhoan = obj.TenTaiKhoan,
                TenNguoiDung = obj.TenNguoiDung,
                MatKhau = obj.MatKhau,
                HienThi = obj.HienThi,
                NgayTao = obj.NgayTao,
                NgayCapNhap = obj.NgayCapNhap,
                DiaChi = obj.DiaChi,
                DienThoai = obj.DienThoai,
                GioiTinh = obj.GioiTinh,
                MaNguoiDung = obj.MaNguoiDung,
                NgaySinh = obj.NgaySinh,
            };
            return item;
        }
        public IEnumerable<TaiKhoan_OBJ> HienThiDanhSachTaiKhoan()
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();

                IList<TaiKhoan_OBJ> DanhSach = new List<TaiKhoan_OBJ>();
                var query = db.TaiKhoans.ToList();
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

        public IEnumerable<TaiKhoan_OBJ> TimKiemThongTinTaiKhoan(string TuKhoa)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                IList<TaiKhoan_OBJ> DanhSach = new List<TaiKhoan_OBJ>();
                TuKhoa = TuKhoa.Trim();

                if (string.IsNullOrEmpty(TuKhoa) == false)
                {
                    var query = from item in db.TaiKhoans
                                where item.TenTaiKhoan.Trim() == TuKhoa ||
                                item.TenNguoiDung.Trim() == TuKhoa||
                                item.GioiTinh.Trim() == TuKhoa||
                                item.DiaChi.Trim() == TuKhoa||
                                item.DienThoai.Trim()==TuKhoa
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

        public TaiKhoan_OBJ GetMa(string TenTaiKhoan)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                var items = (from item in db.TaiKhoans
                             where item.TenTaiKhoan == TenTaiKhoan
                             select item).SingleOrDefault();
                return Mapper(items);
            }
            catch
            {
                return null;
            }
        }


        public bool ThemMoi(TaiKhoan_OBJ obj)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                db.TaiKhoans.Add(MapperBase(obj));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhap(TaiKhoan_OBJ obj)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                Base.TaiKhoan item = MapperBase(obj);
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TaiKhoan_OBJ Xoa(string TenTaiKhoan)
        {
            MayTinhDbContext db = new MayTinhDbContext();
            Base.TaiKhoan item = db.TaiKhoans.Find(TenTaiKhoan);
            if (item == null)
            {
                return null;
            }
            db.TaiKhoans.Remove(item);
            db.SaveChanges();
            return Mapper(item);
        }
    }
}

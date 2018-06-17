using Nhom8.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8.DataAccess.Models.NhaSanXuat
{
    public class NhaSanXuat_BUS
    {
        public NhaSanXuat_OBJ Mapper(Base.NhaSanXuat item)
        {
            NhaSanXuat_OBJ obj = new NhaSanXuat_OBJ()
            {
                MaNhaSanXuat = item.MaNhaSanXuat,
                TenNhaSanXuat = item.TenNhaSanXuat,
                QuocGia = item.QuocGia,
                HienThi = item.HienThi,
            };
            return obj;
        }


        public Base.NhaSanXuat MapperBase(NhaSanXuat_OBJ obj)
        {
            Base.NhaSanXuat item  = new Base.NhaSanXuat()
            {
            
                MaNhaSanXuat = obj.MaNhaSanXuat,
                TenNhaSanXuat = obj.TenNhaSanXuat,
                QuocGia = obj.QuocGia,
                HienThi = obj.HienThi,
            };
            return item;
        }

        public IEnumerable<NhaSanXuat_OBJ> HienThiDanhSachNhaSanXuat()
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();

                IList<NhaSanXuat_OBJ> DanhSach = new List<NhaSanXuat_OBJ>();
                var query = db.NhaSanXuats.ToList();
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

        public IEnumerable<NhaSanXuat_OBJ> TimKiemThongTinNhaSanXuat(string TuKhoa)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                IList<NhaSanXuat_OBJ> DanhSach = new List<NhaSanXuat_OBJ>();
                TuKhoa = TuKhoa.Trim();

                if (string.IsNullOrEmpty(TuKhoa) == false)
                {
                    var query = from item in db.NhaSanXuats
                                where item.TenNhaSanXuat.Trim() == TuKhoa ||
                                item.QuocGia.Trim() == TuKhoa 
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


        public NhaSanXuat_OBJ GetMa(int MaNhaSanXuat)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                var items = (from item in db.NhaSanXuats
                            where item.MaNhaSanXuat == MaNhaSanXuat
                            select item).SingleOrDefault(); 
                return Mapper(items); 
            }
            catch
            {
                return null;
            }
        }


        public bool ThemMoi(NhaSanXuat_OBJ obj)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                db.NhaSanXuats.Add(MapperBase(obj));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhap(NhaSanXuat_OBJ obj)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                Base.NhaSanXuat item = MapperBase(obj);
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public NhaSanXuat_OBJ Xoa(int id)
        {
            MayTinhDbContext db = new MayTinhDbContext();
            Base.NhaSanXuat item = db.NhaSanXuats.Find(id);
            if (item == null)
            {
                return null;
            }
            db.NhaSanXuats.Remove(item);
            db.SaveChanges();
            return Mapper(item);
        }
    }
}

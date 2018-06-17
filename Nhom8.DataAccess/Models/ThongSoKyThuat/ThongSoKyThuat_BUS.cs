using Nhom8.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8.DataAccess.Models.ThongSoKyThuat
{
    public class ThongSoKyThuat_BUS
    {
        MayTinhDbContext db = new MayTinhDbContext();
        public ThongSoKyThuat_OBJ Mapper(Base.ThongSoKyThuat item)
        {
            SanPham.SanPham_BUS bus= new SanPham.SanPham_BUS();
            ThongSoKyThuat_OBJ obj = new ThongSoKyThuat_OBJ()
            {
                MaMay = item.MaMay,
                MaSanPham = item.MaSanPham,
                CacManHinh = item.CacManHinh,
                CongKetNoi = item.CongKetNoi,
                KichThuoc = item.KichThuoc,
                HeDieuHanh = item.HeDieuHanh,
                CPU = item.CPU,
                ManHinh = item.ManHinh,
                HienThi = item.HienThi,
                Ram = item.Ram,
                OCung = item.OCung,
                SanPham = bus.Mapper(item.SanPham)
            }; 
            return obj; 
        }


        public Base.ThongSoKyThuat  MapperBase(ThongSoKyThuat_OBJ obj)
        {
            SanPham.SanPham_BUS bus = new SanPham.SanPham_BUS();
            Base.ThongSoKyThuat item = new Base.ThongSoKyThuat()
            {
                MaMay = obj.MaMay,
                MaSanPham = obj.MaSanPham,
                CacManHinh = obj.CacManHinh,
                CongKetNoi = obj.CongKetNoi,
                KichThuoc = obj.KichThuoc,
                HeDieuHanh = obj.HeDieuHanh,
                CPU = obj.CPU,
                ManHinh = obj.ManHinh,
                HienThi = obj.HienThi,
                Ram = obj.Ram,
                OCung = obj.OCung,
            };
            return item;
        }
        public IEnumerable<ThongSoKyThuat_OBJ> HienThiThongSoKyThuat()
        {
            try
            {
                IList<ThongSoKyThuat_OBJ> DanhSach = new List<ThongSoKyThuat_OBJ>();
                var query = db.ThongSoKyThuats.ToList();
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

        public IEnumerable<ThongSoKyThuat_OBJ> TimKiemThongSoKyThuat(string TuKhoa)
        {
            try
            {
                TuKhoa = TuKhoa.Trim();
                IList<ThongSoKyThuat_OBJ> DanhSach = new List<ThongSoKyThuat_OBJ>();
                var query = from item in db.ThongSoKyThuats
                            where item.SanPham.TenSanPham.Trim() == TuKhoa ||
                            item.CacManHinh.Trim() == TuKhoa ||
                            item.CongKetNoi.Trim() == TuKhoa ||
                            item.KichThuoc.Trim() == TuKhoa ||
                            item.KichThuoc.Trim() == TuKhoa ||
                            item.HeDieuHanh.Trim() == TuKhoa ||
                            item.CPU.Trim() == TuKhoa ||
                            item.ManHinh.Trim() == TuKhoa ||
                            item.Ram.Trim() == TuKhoa ||
                            item.OCung.Trim() == TuKhoa 
                            select item;
                return DanhSach;
            }
            catch
            {
                return null;
            }
        }



        public ThongSoKyThuat_OBJ GetMa(int MaSanPham, int MaMay)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                var items = (from item in db.ThongSoKyThuats
                             where item.MaSanPham == MaSanPham && item.MaMay == MaMay
                             select item).SingleOrDefault();
                return Mapper(items);
            }
            catch
            {
                return null;
            }
        }

        

        public bool ThemMoi(ThongSoKyThuat_OBJ obj)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                db.ThongSoKyThuats.Add(MapperBase(obj));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhap(ThongSoKyThuat_OBJ obj)
        {
            try
            {
                MayTinhDbContext db = new MayTinhDbContext();
                Base.ThongSoKyThuat item = MapperBase(obj);
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

      
        public ThongSoKyThuat_OBJ Xoa(int MaSanPham, int MaMay)
        {
            MayTinhDbContext db = new MayTinhDbContext();
            Base.ThongSoKyThuat item = (
                from items in db.ThongSoKyThuats
                where items.MaSanPham == MaSanPham && items.MaMay == MaMay
                select items).SingleOrDefault();

            if (item == null)
            {
                return null;
            }
            db.ThongSoKyThuats.Remove(item);
            db.SaveChanges();
            return Mapper(item);
        }
    }
}

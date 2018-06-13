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
    }
}

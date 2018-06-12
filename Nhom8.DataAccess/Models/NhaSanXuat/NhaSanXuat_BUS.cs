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
    }
}

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
    }
}

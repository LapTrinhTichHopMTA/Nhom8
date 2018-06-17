using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Nhom8.DataAccess.Base;
using Nhom8.DataAccess.Models.SanPham;
using Nhom8.WebAPI.Models;

namespace Nhom8.WebAPI.Controllers
{

    public class SanPhamController : ApiController
    {
        [HttpGet]

        public IEnumerable<SanPham_OBJ> GetAll()
        {
            SanPham_BUS bus = new SanPham_BUS();
            return bus.HienThiDanhSachSanPham();
        }

        //[Route("getall")]
        public PhanTrang<SanPham_OBJ> GetAll(int trang, int SoBanGhi)
        {
            int DoDaiDanhSach = 0;

            SanPham_BUS bus = new SanPham_BUS();
            var DanhSach = bus.HienThiDanhSachSanPham();
            DoDaiDanhSach = DanhSach.Count();

            var TrangSanPham = DanhSach.OrderByDescending(x => x.MaSanPham).Skip(trang * SoBanGhi).Take(SoBanGhi);
            var PhanTrang = new PhanTrang<SanPham_OBJ>()
            {
                DanhSach = TrangSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }


        //[Route("getall")]
        public PhanTrang<SanPham_OBJ> GetAll(int trang, int SoBanGhi, string TuKhoa)
        {
            int DoDaiDanhSach = 0;

            SanPham_BUS bus = new SanPham_BUS();
            var DanhSach = bus.TimKiemThongTinSanPham(TuKhoa);
            DoDaiDanhSach = DanhSach.Count();

            var TrangSanPham = DanhSach.OrderByDescending(x => x.MaSanPham).Skip(trang * SoBanGhi).Take(SoBanGhi);

            var PhanTrang = new PhanTrang<SanPham_OBJ>()
            {
                DanhSach = TrangSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }



        //[Route("getall")]
        public PhanTrang<SanPham_OBJ> GetAll(int MaNhaSanXuat, int trang, int SoBanGhi)
        {
            int DoDaiDanhSach = 0;

            SanPham_BUS bus = new SanPham_BUS();
            var DanhSach = bus.TimKiemThongTinTheoNhaSanXuat(MaNhaSanXuat);
            DoDaiDanhSach = DanhSach.Count();

            var TrangSanPham = DanhSach.OrderByDescending(x => x.MaSanPham).Skip(trang * SoBanGhi).Take(SoBanGhi);

            var PhanTrang = new PhanTrang<SanPham_OBJ>()
            {
                DanhSach = TrangSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }


        //[Route("getall")]
        public PhanTrang<SanPham_OBJ> GetAlls(int trang, int SoBanGhi, int MaLoaiSanPham)
        {
            int DoDaiDanhSach = 0;

            SanPham_BUS bus = new SanPham_BUS();
            var DanhSach = bus.TimKiemThongTinTheoMaLoaiSanPham(MaLoaiSanPham);
            DoDaiDanhSach = DanhSach.Count();

            var TrangSanPham = DanhSach.OrderByDescending(x => x.MaSanPham).Skip(trang * SoBanGhi).Take(SoBanGhi);

            var PhanTrang = new PhanTrang<SanPham_OBJ>()
            {
                DanhSach = TrangSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }

       
        public PhanTrang<SanPham_OBJ> GetAlls(int trang, int SoBanGhi, int MaLoaiSanPham, int MaNhaSanXuat)
        {
            int DoDaiDanhSach = 0;

            SanPham_BUS bus = new SanPham_BUS();
            var DanhSach = bus.TimKiemThongTinTheoNhaSanXuatVsLoaiSanPham(MaNhaSanXuat, MaLoaiSanPham);
            DoDaiDanhSach = DanhSach.Count();

            var TrangSanPham = DanhSach.OrderByDescending(x => x.MaSanPham).Skip(trang * SoBanGhi).Take(SoBanGhi);

            var PhanTrang = new PhanTrang<SanPham_OBJ>()
            {
                DanhSach = TrangSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }



        public IHttpActionResult GetId(int MaSanPham)
        {
            SanPham_BUS bus = new SanPham_BUS();

            if (bus.HienThiSanPhamTheoID(MaSanPham) == null)
            {
                return NotFound();
            }

            return Ok(bus.HienThiSanPhamTheoID(MaSanPham));
        }



        [HttpPost]
        public void PostSanPham([FromBody]SanPham_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            SanPham_BUS bus = new SanPham_BUS();
            bus.ThemMoiSanPham(obj);  
        }


        [HttpPut]
        public IHttpActionResult PutSanPham([FromBody]SanPham_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SanPham_BUS bus = new SanPham_BUS();
            bus.CapNhapSanPham(obj);

            return StatusCode(HttpStatusCode.NoContent);
        }

       

       

        [HttpDelete]
        public IHttpActionResult Delete(int MaSanPham)
        {

            SanPham_BUS bus = new SanPham_BUS();

            if (bus.XoaSanPham(MaSanPham) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(bus.XoaSanPham(MaSanPham));

            }
        }



    }
}

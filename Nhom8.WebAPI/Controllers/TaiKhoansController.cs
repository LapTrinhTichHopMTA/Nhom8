using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Nhom8.DataAccess.Base;
using Nhom8.DataAccess.Models.TaiKhoan;
using Nhom8.WebAPI.Models;

namespace Nhom8.WebAPI.Controllers
{
    public class TaiKhoansController : ApiController
    {
        private MayTinhDbContext db = new MayTinhDbContext();


        // GET: api/LoaiSanPhams
        public IEnumerable<TaiKhoan_OBJ> GetAll()
        {
            TaiKhoan_BUS bus = new TaiKhoan_BUS();
            return bus.HienThiDanhSachTaiKhoan();
        }

        // GET: api/LoaiSanPhams
        public PhanTrang<TaiKhoan_OBJ> GetAll(int trang, int SoBanGhi)
        {
            TaiKhoan_BUS bus = new TaiKhoan_BUS();
            int DoDaiDanhSach = 0;

            var DanhSach = bus.HienThiDanhSachTaiKhoan();
            DoDaiDanhSach = DanhSach.Count();

            var TrangLoaiSanPham = DanhSach.OrderByDescending(x => x.NgayTao).Skip(trang * SoBanGhi).Take(SoBanGhi);


            var PhanTrang = new PhanTrang<TaiKhoan_OBJ>()
            {
                DanhSach = TrangLoaiSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }

        // GET: api/LoaiSanPhams
        public PhanTrang<TaiKhoan_OBJ> GetAll(int trang, int SoBanGhi, string TuKhoa)
        {
            TaiKhoan_BUS bus = new TaiKhoan_BUS();
            int DoDaiDanhSach = 0;

            var DanhSach = bus.TimKiemThongTinTaiKhoan(TuKhoa);
            DoDaiDanhSach = DanhSach.Count();

            var TrangLoaiSanPham = DanhSach.OrderByDescending(x => x.NgayTao).Skip(trang * SoBanGhi).Take(SoBanGhi);


            var PhanTrang = new PhanTrang<TaiKhoan_OBJ>()
            {
                DanhSach = TrangLoaiSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }


        public IHttpActionResult GetId(string TenTaiKhoan)
        {
            TaiKhoan_BUS bus = new TaiKhoan_BUS();

            if (bus.GetMa(TenTaiKhoan) == null)
            {
                return NotFound();
            }

            return Ok(bus.GetMa(TenTaiKhoan));
        }



        [HttpPost]
        public void PostSanPham([FromBody]TaiKhoan_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            TaiKhoan_BUS bus = new TaiKhoan_BUS();
            bus.ThemMoi(obj);
        }


        [HttpPut]
        public IHttpActionResult PutSanPham([FromBody]TaiKhoan_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TaiKhoan_BUS bus = new TaiKhoan_BUS();
            bus.CapNhap(obj);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(string TenTaiKhoan)
        {

            TaiKhoan_BUS bus = new TaiKhoan_BUS();

            if (bus.Xoa(TenTaiKhoan) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(bus.Xoa(TenTaiKhoan));

            }
        }

    }
}
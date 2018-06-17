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
using Nhom8.DataAccess.Models.LoaiSanPham;
using Nhom8.WebAPI.Models;

namespace Nhom8.WebAPI.Controllers
{
    public class LoaiSanPhamsController : ApiController
    {
        private MayTinhDbContext db = new MayTinhDbContext();

        // GET: api/LoaiSanPhams
        public IEnumerable<LoaiSanPham_OBJ> GetAll()
        {
            LoaiSanPham_BUS bus = new LoaiSanPham_BUS();
            return bus.HienThiDanhSachLoaiSanPham(); 
        }

        public PhanTrang<LoaiSanPham_OBJ> GetAll(int trang, int SoBanGhi)
        {
            LoaiSanPham_BUS bus = new LoaiSanPham_BUS();
            int DoDaiDanhSach = 0;

            var DanhSach = bus.HienThiDanhSachLoaiSanPham();
            DoDaiDanhSach = DanhSach.Count();

            var TrangLoaiSanPham = DanhSach.OrderByDescending(x => x.MaLoaiSanPham).Skip(trang * SoBanGhi).Take(SoBanGhi);


            var PhanTrang = new PhanTrang<LoaiSanPham_OBJ>()
            {
                DanhSach = TrangLoaiSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }

  
        public PhanTrang<LoaiSanPham_OBJ> GetAll(int trang, int SoBanGhi, string TuKhoa)
        {
            LoaiSanPham_BUS bus = new LoaiSanPham_BUS();
            int DoDaiDanhSach = 0;

            var DanhSach = bus.TimKiemThongTinSanPham(TuKhoa);
            DoDaiDanhSach = DanhSach.Count();

            var TrangLoaiSanPham = DanhSach.OrderByDescending(x => x.MaLoaiSanPham).Skip(trang * SoBanGhi).Take(SoBanGhi);

            var PhanTrang = new PhanTrang<LoaiSanPham_OBJ>()
            {
                DanhSach = TrangLoaiSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }


        public IHttpActionResult GetId(int MaLoaiSanPham)
        {
            LoaiSanPham_BUS bus = new LoaiSanPham_BUS();

            if (bus.GetMa(MaLoaiSanPham) == null)
            {
                return NotFound();
            }

            return Ok(bus.GetMa(MaLoaiSanPham));
        }



        [HttpPost]
        public void PostSanPham([FromBody]LoaiSanPham_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            LoaiSanPham_BUS bus = new LoaiSanPham_BUS();
            bus.ThemMoi(obj);
        }


        [HttpPut]
        public IHttpActionResult PutSanPham([FromBody]LoaiSanPham_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LoaiSanPham_BUS bus = new LoaiSanPham_BUS();
            bus.CapNhap(obj);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int MaLoaiSanPham)
        {

            LoaiSanPham_BUS bus = new LoaiSanPham_BUS();

            if (bus.Xoa(MaLoaiSanPham) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(bus.Xoa(MaLoaiSanPham));

            }
        }
    }
}
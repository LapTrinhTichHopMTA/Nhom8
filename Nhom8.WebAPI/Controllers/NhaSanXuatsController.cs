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
using Nhom8.DataAccess.Models.NhaSanXuat;
using Nhom8.WebAPI.Models;

namespace Nhom8.WebAPI.Controllers
{
    public class NhaSanXuatsController : ApiController
    {
        private MayTinhDbContext db = new MayTinhDbContext();

        // GET: api/LoaiSanPhams
        public IEnumerable<NhaSanXuat_OBJ> GetAll()
        {
            NhaSanXuat_BUS bus = new NhaSanXuat_BUS();
            return bus.HienThiDanhSachNhaSanXuat();
        }

        // GET: api/LoaiSanPhams
        public PhanTrang<NhaSanXuat_OBJ> GetAll(int trang, int SoBanGhi)
        {
            NhaSanXuat_BUS bus = new NhaSanXuat_BUS();
            int DoDaiDanhSach = 0;

            var DanhSach = bus.HienThiDanhSachNhaSanXuat();
            DoDaiDanhSach = DanhSach.Count();

            var TrangLoaiSanPham = DanhSach.OrderByDescending(x => x.MaNhaSanXuat).Skip(trang * SoBanGhi).Take(SoBanGhi);


            var PhanTrang = new PhanTrang<NhaSanXuat_OBJ>()
            {
                DanhSach = TrangLoaiSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }

        // GET: api/LoaiSanPhams
        public PhanTrang<NhaSanXuat_OBJ> GetAll(int trang, int SoBanGhi, string TuKhoa)
        {
            NhaSanXuat_BUS bus = new NhaSanXuat_BUS();
            int DoDaiDanhSach = 0;

            var DanhSach = bus.TimKiemThongTinNhaSanXuat(TuKhoa);
            DoDaiDanhSach = DanhSach.Count();

            var TrangLoaiSanPham = DanhSach.OrderByDescending(x => x.MaNhaSanXuat).Skip(trang * SoBanGhi).Take(SoBanGhi);

            var PhanTrang = new PhanTrang<NhaSanXuat_OBJ>()
            {
                DanhSach = TrangLoaiSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }



        public IHttpActionResult GetId(int MaNhaSanXuat)
        {
            NhaSanXuat_BUS bus = new NhaSanXuat_BUS();

            if (bus.GetMa(MaNhaSanXuat) == null)
            {
                return NotFound();
            }

            return Ok(bus.GetMa(MaNhaSanXuat));
        }



        [HttpPost]
        public void PostSanPham([FromBody]NhaSanXuat_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            NhaSanXuat_BUS bus = new NhaSanXuat_BUS();
            bus.ThemMoi(obj);
        }


        [HttpPut]
        public IHttpActionResult PutSanPham([FromBody]NhaSanXuat_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            NhaSanXuat_BUS bus = new NhaSanXuat_BUS();
            bus.CapNhap(obj);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int MaNhaSanXuat)
        {

            NhaSanXuat_BUS bus = new NhaSanXuat_BUS();

            if (bus.Xoa(MaNhaSanXuat) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(bus.Xoa(MaNhaSanXuat));

            }
        }

    }
}
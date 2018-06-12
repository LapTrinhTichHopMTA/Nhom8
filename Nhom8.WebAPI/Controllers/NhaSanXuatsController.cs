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


        // GET: api/NhaSanXuats/5
        [ResponseType(typeof(NhaSanXuat))]
        public IHttpActionResult GetNhaSanXuat(int id)
        {
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Find(id);
            if (nhaSanXuat == null)
            {
                return NotFound();
            }

            return Ok(nhaSanXuat);
        }

        // PUT: api/NhaSanXuats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhaSanXuat(int id, NhaSanXuat nhaSanXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhaSanXuat.MaNhaSanXuat)
            {
                return BadRequest();
            }

            db.Entry(nhaSanXuat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaSanXuatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NhaSanXuats
        [ResponseType(typeof(NhaSanXuat))]
        public IHttpActionResult PostNhaSanXuat(NhaSanXuat nhaSanXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhaSanXuats.Add(nhaSanXuat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhaSanXuat.MaNhaSanXuat }, nhaSanXuat);
        }

        // DELETE: api/NhaSanXuats/5
        [ResponseType(typeof(NhaSanXuat))]
        public IHttpActionResult DeleteNhaSanXuat(int id)
        {
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Find(id);
            if (nhaSanXuat == null)
            {
                return NotFound();
            }

            db.NhaSanXuats.Remove(nhaSanXuat);
            db.SaveChanges();

            return Ok(nhaSanXuat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhaSanXuatExists(int id)
        {
            return db.NhaSanXuats.Count(e => e.MaNhaSanXuat == id) > 0;
        }
    }
}
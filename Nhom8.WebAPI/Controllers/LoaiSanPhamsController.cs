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

        // GET: api/LoaiSanPhams
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

        // GET: api/LoaiSanPhams
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



        // GET: api/LoaiSanPhams/5
        [ResponseType(typeof(LoaiSanPham))]
        public IHttpActionResult GetLoaiSanPham(int id)
        {
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            return Ok(loaiSanPham);
        }

        // PUT: api/LoaiSanPhams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoaiSanPham(int id, LoaiSanPham loaiSanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loaiSanPham.MaLoaiSanPham)
            {
                return BadRequest();
            }

            db.Entry(loaiSanPham).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiSanPhamExists(id))
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

        // POST: api/LoaiSanPhams
        [ResponseType(typeof(LoaiSanPham))]
        public IHttpActionResult PostLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoaiSanPhams.Add(loaiSanPham);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = loaiSanPham.MaLoaiSanPham }, loaiSanPham);
        }

        // DELETE: api/LoaiSanPhams/5
        [ResponseType(typeof(LoaiSanPham))]
        public IHttpActionResult DeleteLoaiSanPham(int Ma)
        {
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(Ma);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            db.LoaiSanPhams.Remove(loaiSanPham);
            db.SaveChanges();

            return Ok(loaiSanPham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoaiSanPhamExists(int id)
        {
            return db.LoaiSanPhams.Count(e => e.MaLoaiSanPham == id) > 0;
        }
    }
}
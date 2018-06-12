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
    

        // GET: api/TaiKhoans/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult GetTaiKhoan(string id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return Ok(taiKhoan);
        }

        // PUT: api/TaiKhoans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaiKhoan(string id, TaiKhoan taiKhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taiKhoan.TenTaiKhoan)
            {
                return BadRequest();
            }

            db.Entry(taiKhoan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiKhoanExists(id))
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

        // POST: api/TaiKhoans
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult PostTaiKhoan(TaiKhoan taiKhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaiKhoans.Add(taiKhoan);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TaiKhoanExists(taiKhoan.TenTaiKhoan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = taiKhoan.TenTaiKhoan }, taiKhoan);
        }

        // DELETE: api/TaiKhoans/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult DeleteTaiKhoan(string id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            db.TaiKhoans.Remove(taiKhoan);
            db.SaveChanges();

            return Ok(taiKhoan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaiKhoanExists(string id)
        {
            return db.TaiKhoans.Count(e => e.TenTaiKhoan == id) > 0;
        }
    }
}
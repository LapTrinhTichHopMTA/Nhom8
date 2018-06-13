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
using Nhom8.DataAccess.Models.ThongSoKyThuat;
using Nhom8.WebAPI.Models;

namespace Nhom8.WebAPI.Controllers
{
    public class ThongSoKyThuatsController : ApiController
    {
        private MayTinhDbContext db = new MayTinhDbContext();

        // GET: api/ThongSoKyThuats
        public IEnumerable<ThongSoKyThuat_OBJ> GetALL()
        {
            ThongSoKyThuat_BUS bus = new ThongSoKyThuat_BUS(); 

            return bus.HienThiThongSoKyThuat();
        }

        // GET: api/ThongSoKyThuats
        public PhanTrang<ThongSoKyThuat_OBJ> GetALL(int trang, int SoBanGhi)
        {
            ThongSoKyThuat_BUS bus = new ThongSoKyThuat_BUS();
            int DoDaiDanhSach = 0;
            var DanhSach = bus.HienThiThongSoKyThuat();
            DoDaiDanhSach = DanhSach.Count();

            var TrangSanPham = DanhSach.OrderByDescending(x => x.MaSanPham).Skip(trang * SoBanGhi).Take(SoBanGhi);

            var PhanTrang = new PhanTrang<ThongSoKyThuat_OBJ>()
            {
                DanhSach = TrangSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
 
        }


        // GET: api/ThongSoKyThuats
        public PhanTrang<ThongSoKyThuat_OBJ> GetALL(int trang, int SoBanGhi, string TuKhoa)

        {
            ThongSoKyThuat_BUS bus = new ThongSoKyThuat_BUS();
            int DoDaiDanhSach = 0;
            var DanhSach = bus.TimKiemThongSoKyThuat(TuKhoa);
            DoDaiDanhSach = DanhSach.Count();

            var TrangSanPham = DanhSach.OrderByDescending(x => x.MaSanPham).Skip(trang * SoBanGhi).Take(SoBanGhi);

            var PhanTrang = new PhanTrang<ThongSoKyThuat_OBJ>()
            {
                DanhSach = TrangSanPham,
                Trang = trang,
                SoBanGhi = SoBanGhi,
                SoTrang = (int)Math.Ceiling((decimal)DoDaiDanhSach / SoBanGhi)
            };
            return PhanTrang;
        }



        // GET: api/ThongSoKyThuats/5
        [ResponseType(typeof(ThongSoKyThuat))]
        public IHttpActionResult GetThongSoKyThuat(int id)
        {
            ThongSoKyThuat thongSoKyThuat = db.ThongSoKyThuats.Find(id);
            if (thongSoKyThuat == null)
            {
                return NotFound();
            }

            return Ok(thongSoKyThuat);
        }

        // PUT: api/ThongSoKyThuats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutThongSoKyThuat(int id, ThongSoKyThuat thongSoKyThuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thongSoKyThuat.MaMay)
            {
                return BadRequest();
            }

            db.Entry(thongSoKyThuat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThongSoKyThuatExists(id))
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

        // POST: api/ThongSoKyThuats
        [ResponseType(typeof(ThongSoKyThuat))]
        public IHttpActionResult PostThongSoKyThuat(ThongSoKyThuat thongSoKyThuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ThongSoKyThuats.Add(thongSoKyThuat);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ThongSoKyThuatExists(thongSoKyThuat.MaMay))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = thongSoKyThuat.MaMay }, thongSoKyThuat);
        }

        // DELETE: api/ThongSoKyThuats/5
        [ResponseType(typeof(ThongSoKyThuat))]
        public IHttpActionResult DeleteThongSoKyThuat(int id)
        {
            ThongSoKyThuat thongSoKyThuat = db.ThongSoKyThuats.Find(id);
            if (thongSoKyThuat == null)
            {
                return NotFound();
            }

            db.ThongSoKyThuats.Remove(thongSoKyThuat);
            db.SaveChanges();

            return Ok(thongSoKyThuat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThongSoKyThuatExists(int id)
        {
            return db.ThongSoKyThuats.Count(e => e.MaMay == id) > 0;
        }
    }
}
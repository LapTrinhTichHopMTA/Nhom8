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

namespace Nhom8.WebAPI.Controllers
{
    public class SanPhamsController : ApiController
    {
        private MayTinhDbContext db = new MayTinhDbContext();

        public IQueryable<SanPham> GetSanPhams()
        {
            return db.SanPhams;
        }

        [ResponseType(typeof(SanPham))]
        public IHttpActionResult GetSanPham(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return Ok(sanPham);
        }


        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanPham(int id, SanPham sanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanPham.MaSanPham)
            {
                return BadRequest();
            }

            db.Entry(sanPham).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(id))
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


       [ResponseType(typeof(SanPham))]
        public IHttpActionResult PostSanPham(SanPham sanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SanPhams.Add(sanPham);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sanPham.MaSanPham }, sanPham);
        }


        [ResponseType(typeof(SanPham))]
        public IHttpActionResult DeleteSanPham(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            db.SanPhams.Remove(sanPham);
            db.SaveChanges();

            return Ok(sanPham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanPhamExists(int id)
        {
            return db.SanPhams.Count(e => e.MaSanPham == id) > 0;
        }
    }
}
﻿using System;
using System.Collections.Generic;
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
    //[RoutePrefix("api/sanpham")]
    //[Authorize]
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


        public IHttpActionResult GetId(int MaSanPham)
        {
            SanPham_BUS sanPhamClient = new SanPham_BUS();

            if (sanPhamClient.HienThiSanPhamTheoID(MaSanPham) == null)
            {
                return NotFound();
            }

            return Ok(sanPhamClient.HienThiSanPhamTheoID(MaSanPham));
        }

       
        [ResponseType(typeof(SanPham_OBJ))]
        public IHttpActionResult PostNhanVien(SanPham_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SanPham_BUS bus = new SanPham_BUS();

            bool kt = bus.ThemMoiSanPham(obj);
            bus.save(); 

            if (kt == true)
            {
                return CreatedAtRoute("DefaultApi", new { id = obj.MaLoaiSanPham }, obj);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // PUT api/values/5

        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoaiSanPham(int id, SanPham_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != obj.MaSanPham)
            {
                return BadRequest();
            }
            SanPham_BUS bus = new SanPham_BUS();
            bool b = bus.CapNhapSanPham(obj);
            try
            {
                bus.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bus.SanPhamExists(id))
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
        private MayTinhDbContext db = new MayTinhDbContext();

       

        [HttpDelete]
        [ResponseType(typeof(SanPham_OBJ))]
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

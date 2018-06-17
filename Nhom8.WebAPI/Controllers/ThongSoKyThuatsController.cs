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



        public IHttpActionResult GetId(int MaSanPham, int MaMay)
        {
            ThongSoKyThuat_BUS bus = new ThongSoKyThuat_BUS();

            if (bus.GetMa(MaSanPham,MaMay) == null)
            {
                return NotFound();
            }

            return Ok(bus.GetMa(MaSanPham, MaMay));
        }



        [HttpPost]
        public void PostSanPham([FromBody]ThongSoKyThuat_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            ThongSoKyThuat_BUS bus = new ThongSoKyThuat_BUS();
            bus.ThemMoi(obj);
        }


        [HttpPut]
        public IHttpActionResult PutSanPham([FromBody]ThongSoKyThuat_OBJ obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ThongSoKyThuat_BUS bus = new ThongSoKyThuat_BUS();
            bus.CapNhap(obj);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int MaSanPham, int MaMay)
        {

            ThongSoKyThuat_BUS bus = new ThongSoKyThuat_BUS();

            if (bus.Xoa(MaSanPham, MaMay) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(bus.Xoa(MaSanPham, MaMay));

            }
        }
    }
}
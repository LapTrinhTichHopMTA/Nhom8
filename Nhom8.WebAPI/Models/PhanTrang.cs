using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom8.WebAPI.Models
{
    public class PhanTrang<T>
    {
        public int Trang { get; set; }
        public int SoTrang { get; set; }
        public int SoBanGhi { get; set; }
        public IEnumerable<T> DanhSach { set; get; }
        public int DoDai
        {
            get
            {
                return (DanhSach != null) ? DanhSach.Count() : 0; 
            }
        }

    }
}
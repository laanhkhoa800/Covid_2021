//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Code_CH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GioHang
    {
        public int maGH { get; set; }
        public Nullable<int> maHD { get; set; }
        public Nullable<int> maKH { get; set; }
        public Nullable<System.DateTime> ngaydat { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual TaiKhoanKhachHang TaiKhoanKhachHang { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CuaHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HangHoa
    {
        public int MaHH { get; set; }
        public string TenHH { get; set; }
        public Nullable<int> MaLH { get; set; }
        public Nullable<decimal> Gia { get; set; }
        public Nullable<int> SLTon { get; set; }
        public string DonVi { get; set; }
    
        public virtual LoaiHang LoaiHang { get; set; }
    }
}

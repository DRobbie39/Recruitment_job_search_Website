//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Job.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongViec()
        {
            this.CongTies = new HashSet<CongTy>();
        }
    
        public int MaCongViec { get; set; }
        public string TenCongViec { get; set; }
        public Nullable<double> MucLuong { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> MaLoaiViec { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongTy> CongTies { get; set; }
        public virtual LoaiViec LoaiViec { get; set; }
    }
}

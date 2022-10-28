namespace QLbansach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            CHITIETDONTHANGs = new HashSet<CHITIETDONTHANG>();
        }

        [Key]
        [Required(ErrorMessage ="Mã đơn hàng không được để trống")]
        [DisplayName("Mã đơn hàng")]
        public int MaDonHang { get; set; }

        [DisplayName("Đã thanh toán")]
        public bool? Dathanhtoan { get; set; }
        
        [DisplayName("Tình trạng giao")]
        public bool? Tinhtranggiaohang { get; set; }

        [DisplayName("Ngày đật")]
        public DateTime? Ngaydat { get; set; }

        [DisplayName("Ngày giao")]
        public DateTime? Ngaygiao { get; set; }

        public int? MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONTHANG> CHITIETDONTHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}

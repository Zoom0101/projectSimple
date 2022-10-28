namespace QLbansach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONDATHANGs = new HashSet<DONDATHANG>();
        }

        [Key]
        [DisplayName("Mã KH")]
        [Required(ErrorMessage ="Mã KH không được để trống")]
        public int MaKH { get; set; }

        [Required(ErrorMessage ="Tên không được để trống")]
        [StringLength(50)]
        [DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [DisplayName("Tài khoản")]
        public string Taikhoan { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string Matkhau { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        [DisplayName("Địa chỉ KH")]
        public string DiachiKH { get; set; }

        [DisplayName("Số đt")]
        [StringLength(50)]
        public string DienthoaiKH { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime? Ngaysinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANGs { get; set; }
    }
}

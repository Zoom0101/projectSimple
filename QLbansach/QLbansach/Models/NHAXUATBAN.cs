namespace QLbansach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAXUATBAN")]
    public partial class NHAXUATBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAXUATBAN()
        {
            SACHes = new HashSet<SACH>();
        }

        [Key]
        [Required(ErrorMessage ="Mã MXB không được để trống")]
        [DisplayName("Mã nhà xuất bản")]
        public int MaNXB { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên NXB")]
        public string TenNXB { get; set; }

        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        public string Diachi { get; set; }

        [StringLength(50)]
        [DisplayName("Số điện thoại")]
        public string DienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }
    }
}

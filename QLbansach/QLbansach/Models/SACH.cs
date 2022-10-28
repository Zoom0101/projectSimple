namespace QLbansach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CHITIETDONTHANGs = new HashSet<CHITIETDONTHANG>();
        }

        [Key]
        [DisplayName("Mã sách")]
        public int Masach { get; set; }

        [Required(ErrorMessage ="Tên sách không được để trống")]
        [StringLength(100)]
        public string Tensach { get; set; }

        [DisplayName("Giá bán")]
        [Required(ErrorMessage ="Giá bán không được để trống")]
        public decimal? Giaban { get; set; }

        [DisplayName("Mô tả")]
        public string Mota { get; set; }

        [StringLength(50)]
        [DisplayName("Ảnh bìa")]
        public string Anhbia { get; set; }

        [DisplayName("Ngày cập nhập")]
        public DateTime? Ngaycapnhat { get; set; }

        [DisplayName("Số lượng tồn")]
        [Required(ErrorMessage ="SLT không được để trống")]
        public int? Soluongton { get; set; }

        [DisplayName("Mã chủ đề")]
        public int? MaCD { get; set; }

        [DisplayName("Mã NXB")]
        public int? MaNXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONTHANG> CHITIETDONTHANGs { get; set; }

        public virtual CHUDE CHUDE { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }
    }
}

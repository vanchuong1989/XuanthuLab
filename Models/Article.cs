using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TichHopEntityFramwork.Models
{
    //[Table("TableName")] 
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255, MinimumLength =5, ErrorMessage ="{0} phải từ {2} đến {1}")]
        [Required(ErrorMessage ="{0} phải nhập")]
        [Column(TypeName ="nvarchar")]
        [Display(Name ="Tiêu đề")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày tạo")]
        [Required(ErrorMessage = "{0} phải nhập")]
        public DateTime Created { get; set; }



        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
    }
}

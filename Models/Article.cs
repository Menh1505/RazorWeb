
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorWeb.Models
{   
    public class Article
    {
        [Key]
        public int ID {get; set;}

        [StringLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Tiêu đề")]
        public string Title{get; set;}

        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Ngày tạo")]
        public DateTime Created {get; set;}

        [Column(TypeName = "ntext")]
        [DisplayName("Nội dung")]
        public string Content {get; set;}
    }
}

/*
    dotnet-aspnet-codegenerator razorpage -m RazorWeb.Models.Article -dc RazorWeb.Models.MyBlogContext -outDir Pages/Blog -udl --referenceScriptLibraries
*/
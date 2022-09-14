using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirSnC.Models
{
    public class Products
    {
        [Key]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Price { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string? Description { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Picture1 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Picture2 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Picture3 { get; set; }

    }
}

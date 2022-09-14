using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AirSnC.Models
{
    public class SignIn
    {
        [Column(TypeName ="nvarchar(50)")]
        public string? UserType { get; set; }
        [Key]
        public string? Username { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string? Password { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string? Email { get; set; }
       

    }
    
}

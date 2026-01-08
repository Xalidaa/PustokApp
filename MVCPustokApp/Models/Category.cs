using MVCPustokApp.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPustokApp.Models
{
    public class Category : BaseEntity
    {
        [MaxLength(30, ErrorMessage = "Name must be less than 30 characters")]
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Feature>? Features { get; set; }

    }
}

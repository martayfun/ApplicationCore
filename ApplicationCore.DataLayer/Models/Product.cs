using ApplicationCore.DataLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.DataLayer.Models
{
    public class Product : BaseKeyedEntity<int>
    {
        [StringLength(250)]
        [Column(TypeName = "NVARCHAR(250)")]
        public string Code { get; set; }

        [StringLength(250)]
        [Column(TypeName = "NVARCHAR(250)")]
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

        public int? OrderNumber { get; set; }
    }
}

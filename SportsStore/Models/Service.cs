using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Service
    {
        public long? ServiceID { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        [Column(TypeName = "decimal(8, 2)")] // sepcify the sql data type
        public decimal Price { get; set; }
        public virtual Department? Department { get; set; }
        public int DepartmentID { get; set; } 
    }
}

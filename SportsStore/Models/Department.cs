namespace SportsStore.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual IEnumerable<Product>? Products { get; set; }
        public virtual IEnumerable<Service>? Services { get; set; }
    }
}

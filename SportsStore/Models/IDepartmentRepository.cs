namespace SportsStore.Models
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> Departments { get; }
        Department GetById(int id);
        public void Delete(int id);
        public void Update(Department department);
        void Add(Department department);
    }
}

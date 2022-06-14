using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class EFDepartmentRepository : IDepartmentRepository
    {
        private StoreDbContext context;
        public EFDepartmentRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Department> Departments => context.Departments;

        public void Add(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = GetById(id);
            if (result != null)
            {
                context.Departments.Remove(result);
                context.SaveChanges();
            }
        }

        public Department GetById(int id)
            => context.Departments.FirstOrDefault(x => x.DepartmentID == id);

        public void Update(Department department)
        {
            context.Entry(department).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

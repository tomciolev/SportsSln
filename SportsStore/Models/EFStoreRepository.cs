using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;
        public EFStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
        public Product GetById(int id)
        {
            return(context.Products.Include(x => x.Department).FirstOrDefault(p => p.ProductID == id));
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = GetById(id);
            if(result != null)
            {
                context.Products.Remove(result);
                context.SaveChanges();
            }
        }
        public List<Department> GetDepartments()
        {
            return(context.Departments.ToList());
        }

        public void Update(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}

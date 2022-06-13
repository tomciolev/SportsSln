namespace SportsStore.Models
{
    //A class that depends on the IStoreRepository interface can obtain Product objects without needing to
    //know the details of how they are stored or how the implementation class will deliver them.
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
        //represents the collection of objects that can be queried, such as those managed by a database
        Product GetById(int id);
        void Add(Product product);
        void Update(int id, Product product);
        void Delete(int id);
        List<Department> GetDepartments();

    }

}

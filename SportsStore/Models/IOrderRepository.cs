namespace SportsStore.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
        void Update(int id, Order order);
        Order GetById(int id);  
    }
}
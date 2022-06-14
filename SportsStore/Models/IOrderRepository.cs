namespace SportsStore.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
        Order GetById(int id);
        public void Delete(int id);
        public void Update(Order order);
    }
}
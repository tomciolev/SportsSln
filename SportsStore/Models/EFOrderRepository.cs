using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    //order repository to service i dodajemy go w program.cs
    //class to implement IOrderRepository
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext context;
        public EFOrderRepository(StoreDbContext repo)
        {
            context = repo;
        }
        //zwraca wszystkie produkty, które znajdują się w lini z koszyka
        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines).ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            //linia poniżej zapewnia, że nie nadpisze produktu w zamówieniu
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}

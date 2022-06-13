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
        public void Update(int id, Order order)
        {
            var result = context.Orders.FirstOrDefault(x => x.OrderID == id);
            if(result != null)
            {
                result.Name = order.Name;
                result.Surname = order.Surname;
                result.Street = order.Street;
                result.City = order.City;
                result.Country = order.Country;
                result.ApartmentNumber = order.ApartmentNumber;
                result.PhoneNumber = order.PhoneNumber;
                result.Shipped = order.Shipped;
                context.SaveChanges();
            }
        }

        public Order GetById(int id)
            => context.Orders.FirstOrDefault(x => x.OrderID == id);
    }
}

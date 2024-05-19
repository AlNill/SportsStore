
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Web.Models;

public class EFOrderRepository : IOrderRepository
{
    private readonly ApplicationContext _context;

    public EFOrderRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<Order> Orders => _context.Orders
        .Include(o => o.CartLines)
        .ThenInclude(l => l.Product);

    public void SaveOrder(Order order)
    {
        _context.AttachRange(order.CartLines.Select(l => l.Product));
        if(order.OrderId == 0)
            _context.Orders.Add(order);
        _context.SaveChanges();
    }
}

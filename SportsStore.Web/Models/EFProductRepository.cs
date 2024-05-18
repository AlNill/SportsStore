namespace SportsStore.Web.Models;

public class EFProductRepository : IProductRepository
{
    private ApplicationContext _context;

    public EFProductRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<Product> Products => _context.Products;
}

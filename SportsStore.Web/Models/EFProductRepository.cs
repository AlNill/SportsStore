namespace SportsStore.Web.Models;

public class EFProductRepository : IProductRepository
{
    private ApplicationContext _context;

    public EFProductRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<Product> Products => _context.Products;

    public void SaveProduct(Product product)
    {
        if(product.ProductID == 0)
            _context.Products.Add(product);
        else
        {
            Product dbEntity = _context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if(dbEntity != null)
            {
                dbEntity.Name = product.Name;
                dbEntity.Description = product.Description;
                dbEntity.Price = product.Price;
                dbEntity.Category = product.Category;
            }
        }
        _context.SaveChanges();
    }

    public Product DeleteProduct(int productID)
    {
        Product dbEntry = _context.Products.FirstOrDefault(p => p.ProductID == productID);
        if(dbEntry != null)
        {
            _context.Products.Remove(dbEntry);
            _context.SaveChanges();
        }
        return dbEntry;
    }
}

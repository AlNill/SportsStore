namespace SportsStore.Web.Models;

public interface IProductRepository
{
    IQueryable<Product> Products { get; }
}

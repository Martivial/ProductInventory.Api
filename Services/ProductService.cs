using MojeApiKontrolery.Models;

namespace MojeApiKontrolery.Services;

public class ProductService
{
   private readonly AppDbContext _context;

   public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products.Find(id);
    }
    
    public void Add(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
             throw new ArgumentException("Product name cannot be empty!");
         }

         if (product.Price < 0)
         {
             throw new ArgumentException("Product price cannot be negative!");
         }

        if (product.Stock < 0)
         {
             throw new ArgumentException("Stock cannot be negative!");
         }

       _context.Products.Add(product);
       _context.SaveChanges();
       
    }
}
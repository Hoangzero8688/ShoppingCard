using ASM_Net104_ShoppingCard.Context;
using ASM_Net104_ShoppingCard.Models;
using ASM_Net104_ShoppingCard.Repository.Interface;

namespace ASM_Net104_ShoppingCard.Repository.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly MyDbContext _dbContext;

        public ProductRepo(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public bool Add(Product brand)
        {
            _dbContext.Add(brand);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            _dbContext.Remove(id);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public int GetId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            _dbContext.Update(id);
            _dbContext.SaveChanges();
            return true;
        }
    }
}

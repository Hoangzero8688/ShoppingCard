using ASM_Net104_ShoppingCard.Context;
using ASM_Net104_ShoppingCard.Models;
using ASM_Net104_ShoppingCard.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASM_Net104_ShoppingCard.Repository.Repo
{
    public class BrandRepo : IBrandRepo
    {
        private readonly MyDbContext _dbContext;

        public BrandRepo(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public bool Add(Brand brand)
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

        public List<Brand> GetAll()
        {
            return _dbContext.brands.ToList();
        }

        public Brand GetById(int idBrand)
        {
            var brandId = _dbContext.brands.FirstOrDefault(c => c.id == idBrand);
            return brandId;
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

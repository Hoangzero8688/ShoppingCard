using ASM_Net104_ShoppingCard.Context;
using ASM_Net104_ShoppingCard.Models;
using ASM_Net104_ShoppingCard.Repository.Interface;

namespace ASM_Net104_ShoppingCard.Repository.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly MyDbContext _dbContext;

        public CategoryRepo(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public bool Add(Category category)
        {
            _dbContext.Add(category);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var categoryId = _dbContext.categories.FirstOrDefault(c => c.Id == id);
            _dbContext.Remove(categoryId);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Category> GetAll()
        {
            return _dbContext.categories.ToList();
        }

        public Category GetByid(int id)
        {
            var categoryId = _dbContext.categories.FirstOrDefault(c => c.Id == id);
            return categoryId;
        }

        public int GetId(int id)
        {
         
            throw new NotImplementedException();
        }

        public bool Update(Category category)
        {
            _dbContext.Update(category);
            _dbContext.SaveChanges();
            return true;
        }
    }
}

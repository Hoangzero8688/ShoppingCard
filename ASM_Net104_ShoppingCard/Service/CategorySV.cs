using ASM_Net104_ShoppingCard.Models;
using ASM_Net104_ShoppingCard.Repository.Interface;
using ASM_Net104_ShoppingCard.Service.IService;

namespace ASM_Net104_ShoppingCard.Service
{
    public class CategorySV : ICategorySV
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategorySV(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public bool Add(Category Category)
        {
            return _categoryRepo.Add(Category);
        }

        public bool Delete(int id)
        {
            return _categoryRepo.Delete(id);
        }

        public List<Category> GetAll()
        {
            return _categoryRepo.GetAll().ToList();
        }

        public object GetById(int id)
        {
            return _categoryRepo.GetByid(id);
        }

        public int GetId(int id)
        {
            return id;
        }

        public bool Update(int id, Category category)
        {
            return _categoryRepo.Update(category);
        }
    }
}

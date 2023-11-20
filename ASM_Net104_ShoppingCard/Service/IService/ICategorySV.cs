using ASM_Net104_ShoppingCard.Models;

namespace ASM_Net104_ShoppingCard.Service.IService
{
    public interface ICategorySV
    {
        public List<Category> GetAll();

        public int GetId(int id);

        public bool Add(Category category);

        public bool Update(int id, Category category);
        public bool Delete(int id);
        object GetById(int id);
    }
}

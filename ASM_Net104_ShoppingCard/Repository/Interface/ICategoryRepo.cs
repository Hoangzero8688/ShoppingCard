using ASM_Net104_ShoppingCard.Models;

namespace ASM_Net104_ShoppingCard.Repository.Interface
{
    public interface ICategoryRepo
    {
        public List<Category> GetAll();

        public int GetId(int id);

        public bool Add(Category category);

        public bool Update(Category category);
        public bool Delete(int id);

        Category GetByid(int id);
    }
}

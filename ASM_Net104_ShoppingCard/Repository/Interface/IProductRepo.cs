using ASM_Net104_ShoppingCard.Models;

namespace ASM_Net104_ShoppingCard.Repository.Interface
{
    public interface IProductRepo
    {
        public List<Product> GetAll();

        public int GetId(int id);

        public bool Add(Product brand);

        public bool Update(int id);
        public bool Delete(int id);
    }
}

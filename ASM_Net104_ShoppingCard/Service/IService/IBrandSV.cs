using ASM_Net104_ShoppingCard.Models;

namespace ASM_Net104_ShoppingCard.Service.IService
{
    public interface IBrandSV
    {
        public List<Brand> GetAll();

        public int GetId(int id);

        public bool Add(Brand brand);

        public bool Update(int id);
        public bool Delete(int id);
        Brand GetById(int idBrand);
    }
}

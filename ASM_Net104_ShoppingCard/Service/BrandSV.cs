using ASM_Net104_ShoppingCard.Models;
using ASM_Net104_ShoppingCard.Repository.Interface;
using ASM_Net104_ShoppingCard.Repository.Repo;
using ASM_Net104_ShoppingCard.Service.IService;

namespace ASM_Net104_ShoppingCard.Service
{
    public class BrandSV : IBrandSV
    {
        private readonly IBrandRepo _brandRepo;

        public BrandSV(IBrandRepo brandRepo)
        {
            _brandRepo = brandRepo;
        }
        public bool Add(Brand brand)
        {
            return _brandRepo.Add(brand);
        }

        public bool Delete(int id)
        {
           return (_brandRepo.Delete(id));
        }

        public List<Brand> GetAll()
        {
            return _brandRepo.GetAll().ToList();
        }

        public Brand GetById(int idBrand)
        {
            var brand = _brandRepo.GetById(idBrand);
            return brand;
        }

        public int GetId(int id)
        {
            return id;
        }

        public bool Update(int id)
        {
            return _brandRepo.Update(id);
        }
    }
}

using ASM_Net104_ShoppingCard.Context;
using ASM_Net104_ShoppingCard.Models;
using ASM_Net104_ShoppingCard.Repository.Interface;
using ASM_Net104_ShoppingCard.Service.IService;

namespace ASM_Net104_ShoppingCard.Service
{
    public class ProductSV: IProductSV
    {
        private readonly IProductRepo _productRepo;

        public ProductSV(IProductRepo productRepo)
        {
            _productRepo = productRepo;   
        }
        public bool Add(Product product)
        {
            if (_productRepo.Add(product) == true)
            {
                return _productRepo.Add(product);
            }
            else { return false; }
        }

        public bool Delete(int id)
        {
            if (_productRepo.Delete(id) == true)
            {
                return _productRepo.Delete(id);
            }
            else { return false; }
        }

        public List<Product> GetAll()
        {
            return _productRepo.GetAll();
        }

        public int GetId(int id)
        {
            return _productRepo.GetId(id);
        }

        public bool Update(int id)
        {
            if (_productRepo.Update(id) == true)
            {
                return _productRepo.Update(id);
            }
            else { return false; }
        }
    }
}

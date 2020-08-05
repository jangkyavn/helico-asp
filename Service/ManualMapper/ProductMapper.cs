using Data.Entities;
using Service.ViewModels;

namespace Service.ManualMapper
{
    public static class ProductMapper
    {
        public static ProductViewModel Mapper(this ProductViewModel productVM, Product product)
        {
            productVM.Id = product.Id;
            productVM.CreatedBy = product.CreatedBy;
            productVM.ModifiedBy = product.ModifiedBy;
            productVM.CreatedDate = product.CreatedDate;
            productVM.ModifiedDate = product.ModifiedDate;

            return productVM;
        }
    }
}

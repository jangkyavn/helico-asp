using Data.Entities;
using Service.ViewModels;

namespace Service.ManualMapper
{
    public static class ProductCategoryMapper
    {
        public static ProductCategoryViewModel Mapper(this ProductCategoryViewModel productCategoryVM, ProductCategory productCategory)
        {
            productCategoryVM.Id = productCategory.Id;
            productCategoryVM.Position = productCategory.Position;
            productCategoryVM.CreatedBy = productCategory.CreatedBy;
            productCategoryVM.ModifiedBy = productCategory.ModifiedBy;
            productCategoryVM.CreatedDate = productCategory.CreatedDate;
            productCategoryVM.ModifiedDate = productCategory.ModifiedDate;

            return productCategoryVM;
        }
    }
}

using Data.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class ProductViewModel : AuditableEntity
    {
        public ProductViewModel()
        {
            Price = 0;
            Quantity = 0;
            IsHighlight = false;
        }

        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Name_VN { get; set; }
        public string Name_EN { get; set; }
        public string ShortDescription_VN { get; set; }
        public string ShortDescription_EN { get; set; }
        public string DetailedDescription_VN { get; set; }
        public string DetailedDescription_EN { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsHighlight { get; set; }

        public string ImageBase64 { get; set; }
        public string ImageName { get; set; }
        public List<IFormFile> Files { get; set; }
        public string CategoryName_VN { get; set; }
        public string CategoryName_EN { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}

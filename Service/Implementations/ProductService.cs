using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Interfaces;
using Service.ManualMapper;
using Service.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductService(
            DataContext dataContext,
            IMapper mapper,
            IHostingEnvironment hostingEnvironment)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> AnyAsync(string id)
        {
            bool result = await _dataContext.Products.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<ProductViewModel> CreateAsync(ProductViewModel productVM)
        {
            Product product = _mapper.Map<Product>(productVM);

            product.ProductTranslations.Add(new ProductTranslation
            {
                LanguageId = productVM.LanguageId,
                Name = productVM.Name,
                ShortDescription = productVM.ShortDescription,
                DetailedDescription = productVM.DetailedDescription,
                SeoPageTitle = productVM.SeoPageTitle,
                SeoAlias = productVM.SeoAlias,
                SeoKeywords = productVM.SeoKeywords,
                SeoDescription = productVM.SeoDescription
            });

            List<Language> otherLanguages = await _dataContext.Languages
                .Where(x => x.Id != productVM.LanguageId)
                .ToListAsync();

            foreach (Language item in otherLanguages)
            {
                product.ProductTranslations.Add(new ProductTranslation
                {
                    LanguageId = item.Id,
                    Name = productVM.Name,
                    ShortDescription = productVM.ShortDescription,
                    DetailedDescription = productVM.DetailedDescription,
                    SeoPageTitle = productVM.SeoPageTitle,
                    SeoAlias = productVM.SeoAlias,
                    SeoKeywords = productVM.SeoKeywords,
                    SeoDescription = productVM.SeoDescription
                });
            }

            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            ProductViewModel result = productVM.Mapper(product);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            Product product = await _dataContext
                .Products.FirstOrDefaultAsync(x => x.Id == id);

            if (!string.IsNullOrEmpty(product.Image))
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, Constants.ProductImagePath + product.Image);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductViewModel productVM)
        {
            await DeleteAsync(productVM.Id);
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            List<ProductViewModel> result = await _dataContext.Products
              .OrderByDescending(x => x.CreatedDate)
              .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
              .ToListAsync();

            return result;
        }

        public async Task<PagedList<ProductViewModel>> GetAllPagingAsync(PagingParams @params)
        {
            IQueryable<ProductViewModel> query = from p in _dataContext.Products
                                                 join pt in _dataContext.ProductTranslations
                                                 on p.Id equals pt.ProductId
                                                 join pc in _dataContext.ProductCategories
                                                 on p.CategoryId equals pc.Id
                                                 join pct in _dataContext.ProductCategoryTranslations
                                                 on pc.Id equals pct.ProductCategoryId
                                                 where pt.LanguageId == @params.LanguageId && pct.LanguageId == @params.LanguageId
                                                 orderby p.CreatedDate descending
                                                 select new ProductViewModel
                                                 {
                                                     Id = p.Id,
                                                     Image = p.Image,
                                                     ImageBase64 = p.Image.ConvertBase64(_hostingEnvironment, Constants.ProductImagePath),
                                                     Name = pt.Name,
                                                     ShortDescription = pt.ShortDescription,
                                                     DetailedDescription = pt.DetailedDescription,
                                                     CategoryName = pct.Name
                                                 };

            if (!string.IsNullOrEmpty(@params.Keyword))
            {
                string keyword = @params.Keyword.ToUpper().ToTrim();

                query = query.Where(x => x.Name.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.Name.ToUpper().Contains(keyword) ||
                                                x.ShortDescription.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.ShortDescription.ToUpper().Contains(keyword) ||
                                                x.CategoryName.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.CategoryName.ToUpper().Contains(keyword));
            }

            if (!string.IsNullOrEmpty(@params.SortValue))
            {
                switch (@params.SortKey)
                {
                    case "name":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.Name);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.Name);
                        }
                        break;
                    case "description":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.ShortDescription);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.ShortDescription);
                        }
                        break;
                    case "categoryName":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.CategoryName);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.CategoryName);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (@params.PageSize == -1)
            {
                @params.PageSize = await query.CountAsync();
            }

            return await PagedList<ProductViewModel>
                .CreateAsync(query, @params.PageNumber, @params.PageSize);
        }

        public async Task<ProductViewModel> GetByIdAsync(string id, string languageId)
        {
            ProductViewModel result = await (from p in _dataContext.Products
                                             join pt in _dataContext.ProductTranslations
                                             on p.Id equals pt.ProductId
                                             where p.Id == id && pt.LanguageId == languageId
                                             select new ProductViewModel
                                             {
                                                 Id = p.Id,
                                                 CategoryId = p.CategoryId,
                                                 Image = p.Image,
                                                 ImageBase64 = p.Image.ConvertBase64(_hostingEnvironment, Constants.ProductImagePath),
                                                 ImageName = p.Image.GetOriginalImageName(),
                                                 IsTypical = p.IsTypical,
                                                 Name = pt.Name,
                                                 ShortDescription = pt.ShortDescription,
                                                 DetailedDescription = pt.DetailedDescription,
                                                 SeoPageTitle = pt.SeoPageTitle,
                                                 SeoAlias = pt.SeoAlias,
                                                 SeoKeywords = pt.SeoKeywords,
                                                 SeoDescription = pt.SeoDescription,
                                                 LanguageId = pt.LanguageId,
                                                 CreatedBy = p.CreatedBy,
                                                 CreatedDate = p.CreatedDate,
                                                 Status = p.Status
                                             }).FirstOrDefaultAsync();

            return result;
        }

        public async Task UpdateAsync(ProductViewModel productVM)
        {
            Product product = await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == productVM.Id);
            product.CategoryId = productVM.CategoryId;
            product.Image = productVM.Image;
            product.IsTypical = productVM.IsTypical;
            product.Status = productVM.Status;

            ProductTranslation productTrans = await _dataContext.ProductTranslations
                .FirstOrDefaultAsync(x => x.ProductId == productVM.Id && x.LanguageId == productVM.LanguageId);

            productTrans.Name = productVM.Name;
            productTrans.ShortDescription = productVM.ShortDescription;
            productTrans.DetailedDescription = productVM.DetailedDescription;
            productTrans.SeoPageTitle = productVM.SeoPageTitle;
            productTrans.SeoAlias = productVM.SeoAlias;
            productTrans.SeoKeywords = productVM.SeoKeywords;
            productTrans.SeoDescription = productVM.SeoDescription;
            await _dataContext.SaveChangesAsync();
        }
    }
}

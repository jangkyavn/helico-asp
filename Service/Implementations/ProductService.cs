using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Interfaces;
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
            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            ProductViewModel result = _mapper.Map<ProductViewModel>(product);
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
                                                 join pc in _dataContext.ProductCategories on p.CategoryId equals pc.Id
                                                 orderby p.CreatedDate descending
                                                 select new ProductViewModel
                                                 {
                                                     Id = p.Id,
                                                     Image = p.Image,
                                                     ImageBase64 = p.Image.ConvertBase64(_hostingEnvironment, Constants.ProductImagePath),
                                                     Name_VN = p.Name_VN ?? string.Empty,
                                                     Name_EN = p.Name_EN ?? string.Empty,
                                                     ShortDescription_VN = p.ShortDescription_VN ?? string.Empty,
                                                     ShortDescription_EN = p.ShortDescription_EN ?? string.Empty,
                                                     DetailedDescription_VN = p.DetailedDescription_VN ?? string.Empty,
                                                     DetailedDescription_EN = p.DetailedDescription_EN ?? string.Empty,
                                                     CategoryName_VN = pc.Name_VN ?? string.Empty,
                                                     CategoryName_EN = pc.Name_EN ?? string.Empty,
                                                     IsHighlight = p.IsHighlight,
                                                     Price = p.Price,
                                                     Status = p.Status
                                                 };

            if (!string.IsNullOrEmpty(@params.Keyword))
            {
                string keyword = @params.Keyword.ToUpper().ToTrim();

                query = query.Where(x => x.Name_VN.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.Name_VN.ToUpper().Contains(keyword) ||
                                                x.ShortDescription_VN.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.ShortDescription_VN.ToUpper().Contains(keyword) ||
                                                x.CategoryName_VN.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.CategoryName_VN.ToUpper().Contains(keyword));
            }

            if (!string.IsNullOrEmpty(@params.SortValue))
            {
                switch (@params.SortKey)
                {
                    case "name":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.Name_VN);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.Name_VN);
                        }
                        break;
                    case "description":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.ShortDescription_VN);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.ShortDescription_VN);
                        }
                        break;
                    case "categoryName":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.CategoryName_VN);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.CategoryName_VN);
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

        public async Task<ProductViewModel> GetByIdAsync(string id)
        {
            ProductViewModel result = await (from p in _dataContext.Products
                                             where p.Id == id
                                             select new ProductViewModel
                                             {
                                                 Id = p.Id,
                                                 CategoryId = p.CategoryId,
                                                 Image = p.Image,
                                                 ImageBase64 = p.Image.ConvertBase64(_hostingEnvironment, Constants.ProductImagePath),
                                                 ImageName = p.Image.GetOriginalImageName(),
                                                 IsHighlight = p.IsHighlight,
                                                 Price = p.Price,
                                                 Quantity = p.Quantity,
                                                 Name_VN = p.Name_VN,
                                                 Name_EN = p.Name_EN,
                                                 ShortDescription_VN = p.ShortDescription_VN,
                                                 ShortDescription_EN = p.ShortDescription_EN,
                                                 DetailedDescription_VN = p.DetailedDescription_VN,
                                                 DetailedDescription_EN = p.DetailedDescription_EN,
                                                 CreatedBy = p.CreatedBy,
                                                 CreatedDate = p.CreatedDate,
                                                 Status = p.Status
                                             }).FirstOrDefaultAsync();

            return result;
        }

        public async Task UpdateAsync(ProductViewModel productVM)
        {
            Product product = _mapper.Map<Product>(productVM);
            _dataContext.Products.Update(product);
            await _dataContext.SaveChangesAsync();
        }
    }
}

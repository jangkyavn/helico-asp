using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ProductCategoryService(
            DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(string id)
        {
            bool result = await _dataContext.ProductCategories.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task ChangePositionAsync(List<ProductCategoryViewModel> listVM)
        {
            int count = 1;
            foreach (ProductCategoryViewModel item in listVM)
            {
                ProductCategory productCategory = await _dataContext.ProductCategories
                    .FirstOrDefaultAsync(x => x.Id == item.Id);
                productCategory.Position = count;
                count += 1;
            }
            await _dataContext.SaveChangesAsync();
        }

        public async Task<ProductCategoryViewModel> CreateAsync(ProductCategoryViewModel productCategoryVM)
        {
            ProductCategory productCategory = _mapper.Map<ProductCategory>(productCategoryVM);

            if (_dataContext.ProductCategories.Any())
            {
                int? maxPosition = await _dataContext.ProductCategories.MaxAsync(x => x.Position);
                productCategory.Position = maxPosition + 1;
            }
            else
            {
                productCategory.Position = 1;
            }

            await _dataContext.ProductCategories.AddAsync(productCategory);
            await _dataContext.SaveChangesAsync();
            ProductCategoryViewModel result = _mapper.Map<ProductCategoryViewModel>(productCategory);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            ProductCategory productCategory = await _dataContext
                .ProductCategories.FirstOrDefaultAsync(x => x.Id == id);

            _dataContext.ProductCategories.Remove(productCategory);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductCategoryViewModel productCategoryVM)
        {
            await DeleteAsync(productCategoryVM.Id);
        }

        public async Task<List<ProductCategoryViewModel>> GetAllAsync()
        {
            List<ProductCategoryViewModel> result = await _dataContext.ProductCategories
                .OrderBy(x => x.Position)
                .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

        public async Task<PagedList<ProductCategoryViewModel>> GetAllPagingAsync(PagingParams @params)
        {
            IQueryable<ProductCategoryViewModel> query = from pc in _dataContext.ProductCategories
                                                         orderby pc.Position
                                                         select new ProductCategoryViewModel
                                                         {
                                                             Id = pc.Id,
                                                             Position = pc.Position,
                                                             Name_VN = pc.Name_VN,
                                                             Name_EN = pc.Name_EN
                                                         };

            if (!string.IsNullOrEmpty(@params.Keyword))
            {
                string keyword = @params.Keyword.ToUpper().ToTrim();

                query = query.Where(x => x.Name_VN.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        x.Name_VN.ToUpper().Contains(keyword));
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
                    default:
                        break;
                }
            }

            if (@params.PageSize == -1)
            {
                @params.PageSize = await query.CountAsync();
            }

            return await PagedList<ProductCategoryViewModel>
                .CreateAsync(query, @params.PageNumber, @params.PageSize);
        }

        public async Task<ProductCategoryViewModel> GetByIdAsync(string id)
        {
            ProductCategoryViewModel result = await (from pc in _dataContext.ProductCategories
                                                     where pc.Id == id
                                                     select new ProductCategoryViewModel
                                                     {
                                                         Id = pc.Id,
                                                         Position = pc.Position,
                                                         Name_VN = pc.Name_VN,
                                                         Name_EN = pc.Name_EN,
                                                         CreatedBy = pc.CreatedBy,
                                                         CreatedDate = pc.CreatedDate,
                                                         Status = pc.Status
                                                     }).FirstOrDefaultAsync();

            return result;
        }

        public async Task UpdateAsync(ProductCategoryViewModel productCategoryVM)
        {
            ProductCategory productCategory = _mapper.Map<ProductCategory>(productCategoryVM);
            _dataContext.ProductCategories.Update(productCategory);
            await _dataContext.SaveChangesAsync();
        }
    }
}

using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Extentions;

namespace WebAPI.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(
            DataContext dataContext,
            IProductCategoryService productCategoryService) : base(dataContext)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ProductCategoryViewModel> data = await _productCategoryService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingParams pagingParams)
        {
            PagedList<ProductCategoryViewModel> paged = await _productCategoryService.GetAllPagingAsync(pagingParams);
            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);
            return Ok(paged.Items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            ProductCategoryViewModel data = await _productCategoryService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryViewModel productCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductCategoryViewModel result = await _productCategoryService.CreateAsync(productCategoryVM);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductCategoryViewModel productCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(productCategoryVM.Id))
            {
                return BadRequest();
            }

            ProductCategoryViewModel data = await _productCategoryService.GetByIdAsync(productCategoryVM.Id);
            if (data == null)
            {
                return NotFound();
            }

            await _productCategoryService.UpdateAsync(productCategoryVM);
            return Ok(true);
        }

        [HttpPut("ChangePosition")]
        public async Task<IActionResult> ChangePosition(List<ProductCategoryViewModel> list)
        {
            using (IDbContextTransaction transaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    await _productCategoryService.ChangePositionAsync(list);
                    transaction.Commit();
                    return Ok(true);
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            ProductCategoryViewModel data = await _productCategoryService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            await _productCategoryService.DeleteAsync(id);
            return Ok(true);
        }
    }
}

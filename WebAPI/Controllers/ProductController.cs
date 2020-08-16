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
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(
            DataContext dataContext,
            IProductService productService
            ) : base(dataContext)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ProductViewModel> data = await _productService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingParams pagingParams)
        {
            PagedList<ProductViewModel> paged = await _productService.GetAllPagingAsync(pagingParams);
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

            ProductViewModel data = await _productService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (IDbContextTransaction transaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    ProductViewModel result = await _productService.CreateAsync(productVM);
                    transaction.Commit();
                    return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductViewModel productVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(productVM.Id))
            {
                return BadRequest();
            }

            bool data = await _productService.AnyAsync(productVM.Id);
            if (data == false)
            {
                return NotFound();
            }

            using (IDbContextTransaction transaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    await _productService.UpdateAsync(productVM);
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

            bool check = await _productService.AnyAsync(id);
            if (check == false)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id);
            return Ok(true);
        }
    }
}

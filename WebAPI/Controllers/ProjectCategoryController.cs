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
    public class ProjectCategoryController : BaseController
    {
        private readonly IProjectCategoryService _projectCategoryService;

        public ProjectCategoryController(
            DataContext dataContext,
            IProjectCategoryService projectCategoryService) : base(dataContext)
        {
            _projectCategoryService = projectCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ProjectCategoryViewModel> data = await _projectCategoryService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingParams pagingParams)
        {
            PagedList<ProjectCategoryViewModel> paged = await _projectCategoryService.GetAllPagingAsync(pagingParams);
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

            ProjectCategoryViewModel data = await _projectCategoryService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectCategoryViewModel projectCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProjectCategoryViewModel result = await _projectCategoryService.CreateAsync(projectCategoryVM);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProjectCategoryViewModel projectCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(projectCategoryVM.Id))
            {
                return BadRequest();
            }

            bool checkAny = await _projectCategoryService.AnyAsync(projectCategoryVM.Id);
            if (checkAny == false)
            {
                return NotFound();
            }

            await _projectCategoryService.UpdateAsync(projectCategoryVM);
            return Ok(true);
        }

        [HttpPut("ChangePosition")]
        public async Task<IActionResult> ChangePosition(List<ProjectCategoryViewModel> list)
        {
            using (IDbContextTransaction transaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    await _projectCategoryService.ChangePositionAsync(list);
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

            bool check = await _projectCategoryService.AnyAsync(id);
            if (check == false)
            {
                return NotFound();
            }

            await _projectCategoryService.DeleteAsync(id);
            return Ok(true);
        }
    }
}

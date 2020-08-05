﻿using Data;
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
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(
            DataContext dataContext,
            IProjectService projectService
            ) : base(dataContext)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ProjectViewModel> data = await _projectService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingParams pagingParams)
        {
            PagedList<ProjectViewModel> paged = await _projectService.GetAllPagingAsync(pagingParams);
            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);
            return Ok(paged.Items);
        }

        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(string id, string languageId)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            ProjectViewModel data = await _projectService.GetByIdAsync(id, languageId);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel projectVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (IDbContextTransaction transaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    ProjectViewModel result = await _projectService.CreateAsync(projectVM);
                    transaction.Commit();
                    return CreatedAtAction(nameof(GetById), new { id = result.Id, languageId = result.LanguageId }, result);
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProjectViewModel projectVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(projectVM.Id))
            {
                return BadRequest();
            }

            bool data = await _projectService.AnyAsync(projectVM.Id);
            if (data == false)
            {
                return NotFound();
            }

            using (IDbContextTransaction transaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    await _projectService.UpdateAsync(projectVM);
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

            bool check = await _projectService.AnyAsync(id);
            if (check == false)
            {
                return NotFound();
            }

            await _projectService.DeleteAsync(id);
            return Ok(true);
        }
    }
}

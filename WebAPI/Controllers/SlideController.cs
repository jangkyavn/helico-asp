using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class SlideController : BaseController
    {
        private readonly ISlideService _slideService;

        public SlideController(
            DataContext dataContext,
            ISlideService slideService
            ) : base(dataContext)
        {
            _slideService = slideService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<SlideViewModel> data = await _slideService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            SlideViewModel data = await _slideService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SlideViewModel slideVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SlideViewModel result = await _slideService.CreateAsync(slideVM);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SlideViewModel slideVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(slideVM.Id))
            {
                return BadRequest();
            }

            bool checkAny = await _slideService.AnyAsync(slideVM.Id);
            if (checkAny == false)
            {
                return NotFound();
            }

            await _slideService.UpdateAsync(slideVM);
            return Ok(true);
        }

        [HttpPut("ChangePosition")]
        public async Task<IActionResult> ChangePosition(List<SlideViewModel> list)
        {
            using (IDbContextTransaction transaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    await _slideService.ChangePositionAsync(list);
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

            bool checkAny = await _slideService.AnyAsync(id);
            if (checkAny == false)
            {
                return NotFound();
            }

            await _slideService.DeleteAsync(id);
            return Ok(true);
        }
    }
}

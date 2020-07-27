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
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(
            DataContext dataContext,
            IUserService userService) : base(dataContext)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<UserViewModel> data = await _userService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("getAllExceptMySelf")]
        public async Task<IActionResult> GetAllExceptMySelf()
        {
            string currentId = User.GetUserId();

            if (string.IsNullOrEmpty(currentId))
            {
                return NotFound();
            }

            IList<UserViewModel> usersVM = await _userService.GetAllExceptMySelfAsync(currentId);
            return Ok(usersVM);
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]PagingParams @params)
        {
            PagedList<UserViewModel> paged = await _userService.GetAllPagingAsync(@params);
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

            UserViewModel data = await _userService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet("GetGenders")]
        public IActionResult GetGenders()
        {
            List<EnumModel> data = _userService.GetGenders();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserAddViewModel userVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (IDbContextTransaction transaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    UserViewModel data = await _userService.CreateAsync(userVM);

                    transaction.Commit();
                    return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserViewModel userVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(userVM.Id.ToString()))
            {
                return BadRequest();
            }

            UserViewModel data = await _userService.GetByIdAsync(userVM.Id);
            if (data == null)
            {
                return NotFound();
            }

            using (IDbContextTransaction transaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    await _userService.UpdateAsync(userVM);
                    transaction.Commit();

                    return Ok(true);
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            }
        }

        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(KeyParam keyParam)
        {
            if (string.IsNullOrEmpty(keyParam.Id))
            {
                return BadRequest();
            }

            bool result = await _userService.ChangeStatusAsync(keyParam.Id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            UserViewModel data = await _userService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(data);
            return Ok(true);
        }
    }
}

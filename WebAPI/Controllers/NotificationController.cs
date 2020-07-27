using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Threading.Tasks;
using WebAPI.Extentions;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    public class NotificationController : BaseController
    {
        public NotificationController(DataContext dataContext,
            INotificationService notificationService) : base(dataContext, notificationService)
        {
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]PagingParams pagingParams)
        {
            string currentUserId = User.GetUserId();
            PagedList<NotificationViewModel> paged = await _notificationService.GetAllPagingAsync(pagingParams, currentUserId);
            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);
            return Ok(paged.Items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest();
            }

            NotificationViewModel data = await _notificationService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("getCountUnView")]
        public async Task<IActionResult> GetCountUnView()
        {
            string currentUserId = User.GetUserId();
            int result = await _notificationService.GetCountUnViewAsync(currentUserId);
            return Ok(result);
        }

        [HttpPut("markViewedAll")]
        public async Task<IActionResult> MarkViewedAll()
        {
            string currentUserId = User.GetUserId();

            using (IDbContextTransaction transaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    await _notificationService.MarkViewedAllAsync(currentUserId);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            }

            return Ok(true);
        }

        [HttpPut("MarkSeen")]
        public async Task<IActionResult> MarkSeen(KeyParam keyParam)
        {
            if (string.IsNullOrEmpty(keyParam.Id))
            {
                return BadRequest();
            }

            NotificationViewModel notificationVM = await _notificationService.GetByIdAsync(keyParam.Id);
            if (notificationVM == null)
            {
                return NotFound();
            }

            try
            {
                await _notificationService.MarkSeenNotification(notificationVM);
            }
            catch (Exception e)
            {
                if (!await _notificationService.CheckExistsAsync(keyParam.Id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            }

            return Ok(true);
        }

        [HttpDelete("deleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            string currentUserId = User.GetUserId();
            await _notificationService.DeleteAllAsync(currentUserId);
            return Ok(true);
        }
    }
}

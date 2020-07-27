using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Threading.Tasks;
using Wangkanai.Detection;
using WebAPI.Extentions;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    public class DiaryController : BaseController
    {
        private readonly IDiaryService _diaryService;
        private readonly IDetection _detection;
        private readonly IHttpContextAccessor _accessor;

        public DiaryController(IDiaryService diaryService, IDetection detection, IHttpContextAccessor accessor)
        {
            _diaryService = diaryService;
            _detection = detection;
            _accessor = accessor;
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingParams pagingParams)
        {
            PagedList<DiaryViewModel> paged = await _diaryService.GetAllPagingAsync(pagingParams);
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

            DiaryViewModel data = await _diaryService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DiaryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            viewModel.UserId = User.GetUserId();
            viewModel.CreatedDate = DateTime.Now;
            viewModel.IPAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            viewModel.Browser = $"{_detection.Browser.Type} ({_detection.Browser.Version})";
            viewModel.Device = _detection.Device.Type.ToString();

            DiaryViewModel data = await _diaryService.CreateAsync(viewModel);
            return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);
        }
    }
}

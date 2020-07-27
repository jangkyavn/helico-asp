using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly DataContext _dataContext;
        protected readonly INotificationService _notificationService;

        public BaseController() { }

        public BaseController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public BaseController(DataContext dataContext, INotificationService notificationService)
        {
            _dataContext = dataContext;
            _notificationService = notificationService;
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebMVC.Controllers.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

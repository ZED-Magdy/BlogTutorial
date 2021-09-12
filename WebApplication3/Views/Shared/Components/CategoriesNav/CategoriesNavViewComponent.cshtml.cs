using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Views.Shared
{
    public class CategoriesNavViewComponent : ViewComponent
    {
        private readonly DBContext context;

        public CategoriesNavViewComponent(DBContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(context.Categories);
        }
    }
}

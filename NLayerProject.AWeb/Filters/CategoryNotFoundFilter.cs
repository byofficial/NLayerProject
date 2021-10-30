using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.AWeb.DTOs;
using NLayerProject.Core.Services;

namespace NLayerProject.AWeb.Filters
{

    public class CategoryNotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;

        public CategoryNotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int) context.ActionArguments.Values.FirstOrDefault();

            var category = await _categoryService.GetByIdAsync(id);

            if (category != null) //Eğer gelen id değerine sahip veri varsa ActionMetota Gir
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
               

                errorDto.Errors.Add($"id'si {id} olan kayıt veritabanında bulunamadı!");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}

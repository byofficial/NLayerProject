using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.AWeb.ApiService;
using NLayerProject.AWeb.DTOs;


namespace NLayerProject.AWeb.Filters
{

    public class CategoryNotFoundFilter:ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryApiService;

        public CategoryNotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int) context.ActionArguments.Values.FirstOrDefault();

            var category = await _categoryApiService.GetByIdAsync(id);

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

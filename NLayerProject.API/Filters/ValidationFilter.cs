using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLayerProject.API.DTOs;

namespace NLayerProject.API.Filters
{
    public class ValidationFilter:ActionFilterAttribute
    {
        // Request ilk anda müdahele edilir.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Geçersiz / Yazılmayan Veri Varsa
            if (context.ModelState.IsValid == false)
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400; //Bad Requests

                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(v => v.Errors);

                modelErrors.ToList().ForEach(x =>
                {
                    errorDto.Errors.Add(x.ErrorMessage);
                });

                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}

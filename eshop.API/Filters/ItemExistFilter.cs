using eshop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.API.Filters
{
    public class ItemExistFilter : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public ItemExistFilter(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            //bu filtrenin uygulandığı action'ın "id" parametresi olmalı!
          
            if (!(context.ActionArguments["id"] is int id) )
            {
               
                context.Result = new BadRequestResult();
                return;
            }      



            var isExist = await productService.ProductIsExist(id);
            if (!isExist)
            {
                context.Result = new NotFoundObjectResult($"{id} id'li ürün bulunamadı");
                return;
            }

            await next();

        }
    }

    public class AlternativeIsExist : ActionFilterAttribute
    {
        private IProductService productService;

        public AlternativeIsExist(IProductService productService)
        {
            this.productService = productService;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!(context.ActionArguments["id"] is int id))
            {

                context.Result = new BadRequestResult();
                return;
            }



            var isExist = await productService.ProductIsExist(id);
            if (!isExist)
            {
                context.Result = new NotFoundObjectResult($"{id} id'li ürün bulunamadı");
                return;
            }

            await next();
        }
    }
}

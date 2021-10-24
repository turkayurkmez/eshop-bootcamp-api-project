using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.API.Filters
{
    public class ItemExistsAttribute : TypeFilterAttribute
    {
        public ItemExistsAttribute():base(typeof(ItemExistFilter))
        {

        }
    }
}

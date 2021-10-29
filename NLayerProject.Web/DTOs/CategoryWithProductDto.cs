using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NLayerProject.Web.DTOs
{
    public class CategoryWithProductDto:CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}

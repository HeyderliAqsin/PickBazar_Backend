using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class CategoryDTO
    {
        public string? SanitizedName { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}

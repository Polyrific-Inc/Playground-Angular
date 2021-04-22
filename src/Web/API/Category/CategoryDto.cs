using System;

namespace Web.API.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
    }
}

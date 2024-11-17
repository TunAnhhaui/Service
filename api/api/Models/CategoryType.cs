using api.Models;

namespace api.Models
{
    public class CategoryType
    {
        public int CategoryTypeId { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}

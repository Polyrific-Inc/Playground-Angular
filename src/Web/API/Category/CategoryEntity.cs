using Polyrific.Project.Core;

namespace Web.API.Category
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public override void UpdateValueFrom(BaseEntity source)
        {
            var sourceEntity = (CategoryEntity)source;
            Name = sourceEntity.Name;
        }
    }
}

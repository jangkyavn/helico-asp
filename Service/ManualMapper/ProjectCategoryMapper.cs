using Data.Entities;
using Service.ViewModels;

namespace Service.ManualMapper
{
    public static class ProjectCategoryMapper
    {
        public static ProjectCategoryViewModel Mapper(this ProjectCategoryViewModel projectCategoryVM, ProjectCategory projectCategory)
        {
            projectCategoryVM.Id = projectCategory.Id;
            projectCategoryVM.Position = projectCategory.Position;
            projectCategoryVM.CreatedBy = projectCategory.CreatedBy;
            projectCategoryVM.ModifiedBy = projectCategory.ModifiedBy;
            projectCategoryVM.CreatedDate = projectCategory.CreatedDate;
            projectCategoryVM.ModifiedDate = projectCategory.ModifiedDate;

            return projectCategoryVM;
        }
    }
}

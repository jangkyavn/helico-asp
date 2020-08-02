using Data.Entities;
using Service.ViewModels;

namespace Service.ManualMapper
{
    public static class ProjectMapper
    {
        public static ProjectViewModel Mapper(this ProjectViewModel projectVM, Project project)
        {
            projectVM.Id = project.Id;
            projectVM.CreatedBy = project.CreatedBy;
            projectVM.ModifiedBy = project.ModifiedBy;
            projectVM.CreatedDate = project.CreatedDate;
            projectVM.ModifiedDate = project.ModifiedDate;

            return projectVM;
        }
    }
}

using Data.Models;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class AboutUsViewModel : AuditableEntity
    {
        public string Id { get; set; }

        public List<AboutUsTranslationViewModel> AboutUsTranslations { get; set; }
    }
}

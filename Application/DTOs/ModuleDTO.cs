using Application.DTOs.Mapping;

namespace Application.DTOs
{
    public class ModuleDTO : Module, IMapFrom<Module>
    {
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

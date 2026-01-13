using Optera.Configuration.DTOs;
using Optera.Shared.Pagination.Pagination;
using Optera.Shared.Response;

namespace Optera.Configuration.Services.Interfaces
{
    public interface IConfigurationService
    {
        public Task<ServiceResponse<PagedList<GetComponentDto>>> GetComponents(UserParams? userParams);
        public Task<ServiceResponse<List<GetMenuItemDto>>> GetMenuItems();
        public Task<ServiceResponse<GetDataTableDto>> GetDataTable(string name);
    }
}

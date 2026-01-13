using Optera.DTOs.Region;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface IRegionRepository
    {
        public Task<ServiceResponse<PagedList<GetRegionDto>>> GetRegions(UserParams? userParams);
        public Task<ServiceResponse<GetRegionDto>> CreateRegion(CreateRegionDto createRegionDto);
        public Task<ServiceResponse<GetRegionDto>> UpdateRegion(UpdateRegionDto updateRegionDto);
        public Task<ServiceResponse<PagedList<GetRegionDto>>> Search(string value, UserParams? userParams);
        public Task<ServiceResponse<ICollection<GetRegionListDto>>> GetRegionsItemsList(long? cityId);
    }
}

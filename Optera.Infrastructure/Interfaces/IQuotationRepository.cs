using Optera.DTOs.Quotation;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface IQuotationRepository
    {
        public Task<ServiceResponse<GetQuotationDto>> CreateQuotation(CreateQuotationDto createQuotationDto);
        public Task<ServiceResponse<GetQuotationDto>> UpdateQuotation(UpdateQuotationDto updateQuotationDto);
        public Task<ServiceResponse<PagedList<GetQuotationDto>>> GetQuotations(UserParams? userParams);
        public Task<ServiceResponse<GetQuotationDto>> GetQuotation(long id);
    }
}

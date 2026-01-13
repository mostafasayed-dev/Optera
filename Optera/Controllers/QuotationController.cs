using Microsoft.AspNetCore.Mvc;
using Optera.Controllers.Base;
using Optera.DTOs.City;
using Optera.DTOs.Quotation;
using Optera.Extensions;
using Optera.Infrastructure.Interfaces;
using Optera.Repositories;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;

namespace Optera.Controllers
{
    public class QuotationController : BaseApiController
    {
        private readonly IQuotationRepository quotationRepository;
        public QuotationController(IQuotationRepository quotationRepository)
        {
            this.quotationRepository = quotationRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetQuotationDto>>> CreateQuotation(CreateQuotationDto createQuotationDto)
        {
            var result = await quotationRepository.CreateQuotation(createQuotationDto);
            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetQuotationDto>>> UpdateQuotation(UpdateQuotationDto updateQuotationDto)
        {
            var result = await quotationRepository.UpdateQuotation(updateQuotationDto);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<PagedList<GetQuotationDto>>>> GetQuotations([FromQuery] UserParams? userParams)
        {
            var result = await quotationRepository.GetQuotations(userParams);
            if (result.Status == ServiceStatus.Succeeded)
            {
                Response.AddPaginationHeader(result.Result.CurrentPage, result.Result.PageSize,
                                             result.Result.TotalCount, result.Result.TotalPages);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetQuotationDto>>> GetQuotation(long id)
        {
            var result = await quotationRepository.GetQuotation(id);
            if (result.Status == ServiceStatus.Succeeded)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Optera.DataAccess;
using Optera.DTOs.City;
using Optera.DTOs.Quotation;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories.Base;
using Optera.Utils.Models;
using Optera.Utils.Pagination;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Repositories
{
    public class QuotationRepository : BaseRepository<Quotation>, IQuotationRepository
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;

        public QuotationRepository(DBContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper, ICustomerRepository customerRepository) : base(context, httpContextAccessor)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }

        public async Task<ServiceResponse<GetQuotationDto>> CreateQuotation(CreateQuotationDto createQuotationDto)
        {
            try
            {
                var customer = customerRepository.AddCustomer(createQuotationDto.Customer);
                var quotation = mapper.Map<Quotation>(createQuotationDto);
                quotation.Code = GenerateReferenceNumber("QUT");
                quotation.Status = QuotationStatus.Draft.ToString();
                quotation.EmployeeId = GetEmployeeId();
                if (createQuotationDto.EffectiveDate == null)
                    quotation.EffectiveDate = DateTime.Now.Date;
                quotation.Customer = customer;
                Add(quotation);

                var result = await SaveChangesAsync();
                if(result.Success)
                    return ServiceResponse<GetQuotationDto>.Succeeded(mapper.Map<GetQuotationDto>(quotation), string.Format("Quotation {0} created successfully.", quotation.Code));

                return ServiceResponse<GetQuotationDto>.Failed(null, result.Message);
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetQuotationDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetQuotationDto>> UpdateQuotation(UpdateQuotationDto updateQuotationDto)
        {
            try
            {
                var quotation = GetById(updateQuotationDto.Id).Include(q => q.Customer).FirstOrDefault();
                if (quotation == null)
                    return ServiceResponse<GetQuotationDto>.NotFound(null, "Quotation not found!");

                mapper.Map(updateQuotationDto, quotation);

                if(quotation.Status == "Submitted")
                {
                    quotation.SubmitDate = DateTime.Now.Date;
                }
                Update(quotation);
                customerRepository.UpdateCustomer(quotation.Customer);
                var result = await SaveChangesAsync();

                if (result.Success)
                    return ServiceResponse<GetQuotationDto>.Succeeded(mapper.Map<GetQuotationDto>(quotation), string.Format("Quotation {0} updated successfully.", quotation.Code));

                return ServiceResponse<GetQuotationDto>.Failed(null, result.Message);
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetQuotationDto>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<PagedList<GetQuotationDto>>> GetQuotations(UserParams? userParams)
        {
            try
            {
                var quotations = Get().OrderByDescending(x => x.Id).ProjectTo<GetQuotationDto>(mapper.ConfigurationProvider);
                var result = await PagedList<GetQuotationDto>.CreatePageAsync(quotations, userParams);
                return ServiceResponse<PagedList<GetQuotationDto>>.Succeeded(result, "Quotations retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<PagedList<GetQuotationDto>>.Failed(null, ex.Message);
            }
        }

        public async Task<ServiceResponse<GetQuotationDto>> GetQuotation(long id)
        {
            try
            {
                var quotation = GetById(id).ProjectTo<GetQuotationDto>(mapper.ConfigurationProvider).FirstOrDefault();
                if(quotation == null)
                    return ServiceResponse<GetQuotationDto>.NotFound(null, "Quotation not found!");

                return ServiceResponse<GetQuotationDto>.Succeeded(quotation, "Quotation retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<GetQuotationDto>.Failed(null, ex.Message);
            }
        }
    }
}

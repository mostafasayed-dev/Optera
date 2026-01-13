using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Optera.DataAccess;
using Optera.Infrastructure.Interfaces.Base;
using Optera.Models.Base;
using Optera.Utils.Models;
using Optera.Utils.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Optera.Repositories.Base
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel
    {
        private readonly DBContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BaseRepository(DBContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void Add(TModel entity)
        {
            //entity.CreatedAt = entity.UpdatedAt = DateTime.UtcNow;
            entity.CreatedAt = entity.UpdatedAt = DateTime.Now;
            entity.Creator = entity.Updator = GetUsername();
            context.Entry(entity).State = EntityState.Added;
        }

        public async void AddRange(ICollection<TModel> entities)
        {
            foreach (var item in entities)
            {
                item.Creator = item.Updator = GetUsername();
                //item.CreatedAt = item.UpdatedAt = DateTime.UtcNow;
                item.CreatedAt = item.UpdatedAt = DateTime.Now;
            }
            await context.AddRangeAsync(entities);
        }

        public void Update(TModel entity)
        {
            //entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.Now;
            entity.Updator = GetUsername();
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TModel entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<TModel> Get()
        {
            return context.Set<TModel>().AsNoTracking();
        }

        public IQueryable<TModel> GetByStatus(string status)
        {
            return context.Set<TModel>().AsNoTracking().Where(p => p.Status == status);
        }

        public IQueryable<TModel> GetById(long Id)
        {
            return context.Set<TModel>().AsNoTracking().Where(p => p.Id == Id);
        }

        public async Task<ICollection<TModel>> GetAsync()
        {
            return await context.Set<TModel>().ToListAsync();
        }

        public async Task<ICollection<TModel>> GetByStatusAsync(string status)
        {
            return await context.Set<TModel>().Where(p => p.Status == status).ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(long id)
        {
            return await context.Set<TModel>().Where(p => p.Id == id).SingleOrDefaultAsync();
        }

        public async Task<ServiceResponse<bool>> SaveChangesAsync()
        {
            try
            {
                bool result = await context.SaveChangesAsync() > 0;
                if (!result)
                    throw new Exception("Failed to save changes to database!");
                return ServiceResponse<bool>.Succeeded(result);
            }
            catch (Exception exception)
            {
                if (exception.GetBaseException().GetType() == typeof(SqlException))
                {
                    int ErrorCode = ((SqlException)exception.InnerException).Number;
                    string message = "Database error occurred while saving data!";

                    switch (ErrorCode)
                    {
                        case 2627:  // Unique constraint error
                            return ServiceResponse<bool>.UniqueConstraintError(false, exception.InnerException.Message);
                        case 547:   // Constraint check violation
                            return ServiceResponse<bool>.ConstraintCheckError(false, exception.InnerException.Message);
                        case 2601:  // Duplicated key row error
                            return ServiceResponse<bool>.DublicateKeyError(false, exception.InnerException.Message);
                        default:
                            throw;
                    }
                }
                else
                    throw;
            }
        }

        private string GetUsername()
        {
            Claim claim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
            return (claim == null || string.IsNullOrEmpty(claim.Value)) ? "System" : claim.Value;
        }

        public int GetUserId()
        {
            Claim claim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            return (claim == null || string.IsNullOrEmpty(claim.Value)) ? -1: int.Parse(claim.Value);
        }

        public long GetEmployeeId()
        {
            Claim claim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int userId = (claim == null || string.IsNullOrEmpty(claim.Value)) ? -1: int.Parse(claim.Value);
            if (userId == -1)
                return -1;

            var employee = context.Employees.Where(x => x.UserId == userId).FirstOrDefault();
            if (employee == null)
                return -1;
            return employee.Id;
        }

        public string GenerateReferenceNumber(string prefix)
        {
            var result = context.ReferenceNumbers.Where(x => x.Prefix == prefix).FirstOrDefault();
            if(result == null)
                return string.Empty;
            
            string reference_number = result.Prefix;
            string _segment1 = result.Segment1;
            string _segment2 = result.Segment2;
            string _segment3 = result.Segment3;
            string _segment4 = result.Segment4;
            string _segment1_format = result.Segment1_Format;
            string _segment2_format = result.Segment2_Format;
            string _segment3_format = result.Segment3_Format;
            string _segment4_format = result.Segment4_Format;
            long _sequence = result.LastSequence + 1;

            // Segment 1
            if (!string.IsNullOrEmpty(_segment1))
            {
                if (string.IsNullOrEmpty(_segment1_format))
                {
                    reference_number += _segment1;
                }
                else
                {
                    if (_segment1_format.Trim().ToLower() == "date")
                    {
                        reference_number += DateTime.Now.ToString(_segment1);
                    }
                    else if (_segment1_format.Trim().ToLower() == "sequence")
                    {
                        _segment1 = _segment1.Substring(0, _segment1.Length - _sequence.ToString().Length) + _sequence.ToString();
                        reference_number += _segment1;
                    }
                }
            }
            // Segment 2
            if (!string.IsNullOrEmpty(_segment2))
            {
                if (string.IsNullOrEmpty(_segment2_format))
                {
                    reference_number += _segment2;
                }
                else
                {
                    if (_segment2_format.Trim().ToLower() == "date")
                    {
                        reference_number += DateTime.Now.ToString(_segment2);
                    }
                    else if (_segment2_format.Trim().ToLower() == "sequence")
                    {
                        _segment2 = _segment2.Substring(0, _segment2.Length - _sequence.ToString().Length) + _sequence.ToString();
                        reference_number += _segment2;
                    }
                }
            }
            // Segment 3
            if (!string.IsNullOrEmpty(_segment3))
            {
                if (string.IsNullOrEmpty(_segment3_format))
                {
                    reference_number += _segment3;
                }
                else
                {
                    if (_segment3_format.Trim().ToLower() == "date")
                    {
                        reference_number += DateTime.Now.ToString(_segment3);
                    }
                    else if(_segment3_format.Trim().ToLower() == "sequence")
                    {
                        _segment3 = _segment3.Substring(0, _segment3.Length - _sequence.ToString().Length) + _sequence.ToString();
                        reference_number += _segment3;
                    }
                }
            }
            // Segment 4
            if (!string.IsNullOrEmpty(_segment4))
            {
                if (string.IsNullOrEmpty(_segment4_format))
                {
                    reference_number += _segment4;
                }
                else
                {
                    if (_segment4_format.Trim().ToLower() == "date")
                    {
                        reference_number += DateTime.Now.ToString(_segment4);
                    }
                    else if (_segment4_format.Trim().ToLower() == "sequence")
                    {
                        _segment4 = _segment4.Substring(0, _segment4.Length - _sequence.ToString().Length) + _sequence.ToString();
                        reference_number += _segment4;
                    }
                }
            }

            result.LastSequence = _sequence;
            context.Entry(result).State = EntityState.Modified;
            context.SaveChanges();

            return reference_number;
        }

    }
}

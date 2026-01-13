using Microsoft.AspNetCore.Http;
using Optera.DataAccess;
using Optera.Infrastructure.Interfaces;
using Optera.Models;
using Optera.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Repositories
{
    public class ComponentRepository : BaseRepository<Component>, IComponentRepository
    {
        public ComponentRepository(DBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }


    }
}

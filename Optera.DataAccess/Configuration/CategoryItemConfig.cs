using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class CategoryItemConfig : IEntityTypeConfiguration<CategoryItem>
    {
        public void Configure(EntityTypeBuilder<CategoryItem> builder)
        {
            
        }
    }
}

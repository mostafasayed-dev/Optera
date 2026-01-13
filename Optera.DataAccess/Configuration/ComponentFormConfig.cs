using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class ComponentFormConfig : IEntityTypeConfiguration<ComponentForm>
    {
        public void Configure(EntityTypeBuilder<ComponentForm> builder)
        {
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Updator);
            builder.Ignore(p => p.Status);

            //QuotationEditComponent Forms
            builder.HasData(new ComponentForm { Id = 1, ComponentId = 1, Name = "customerInfoForm", Label = "Customer Info.", Model = "customer" });
            builder.HasData(new ComponentForm { Id = 2, ComponentId = 1, Name = "contactInfoForm", Label = "Contact Info.", Model = "customer" });
            builder.HasData(new ComponentForm { Id = 3, ComponentId = 1, Name = "addressInfoForm", Label = "Address Info.", Model = "customer" });
            builder.HasData(new ComponentForm { Id = 4, ComponentId = 1, Name = "inChargePersonInfoForm", Label = "Person in Charge", Model = "quotation" });
            builder.HasData(new ComponentForm { Id = 5, ComponentId = 1, Name = "paymentAndTermsInfoForm", Label = "Terms & Conditions", Model = "quotation" });
            builder.HasData(new ComponentForm { Id = 6, ComponentId = 1, Name = "otherInfoForm", Label = "Other Info.", Model = "quotation" });
        }
    }
}

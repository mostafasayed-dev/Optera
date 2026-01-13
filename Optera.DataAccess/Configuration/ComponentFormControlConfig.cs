using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class ComponentFormControlConfig : IEntityTypeConfiguration<ComponentFormControl>
    {
        public void Configure(EntityTypeBuilder<ComponentFormControl> builder)
        {
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Updator);
            builder.Ignore(p => p.Status);

            builder.ToTable(t => t.HasCheckConstraint("CK_ComponentControl_Type",
                "[Type] IN ('text','number','email','date', 'boolean')"));

            //QuotationEditComponent Forms Controls
            builder.HasData(new ComponentFormControl { Id = 1, ComponentFormId = 1, Name = "name", Type= "text", Label = "Customer Name", Field = "name", Required = true });
            builder.HasData(new ComponentFormControl { Id = 2, ComponentFormId = 1, Name = "name_OtherLanguage", Type = "text", Label = "Customer Name (Other Lang.)", Field = "name_OtherLanguage" });
            builder.HasData(new ComponentFormControl { Id = 3, ComponentFormId = 1, Name = "brandName", Type = "text", Label = "Brand Name", Field = "brandName" });
            builder.HasData(new ComponentFormControl { Id = 4, ComponentFormId = 1, Name = "brandName_OtherLanguage", Type = "text", Label = "Brand Name (Other Lang.)", Field = "brandName_OtherLanguage" });
            builder.HasData(new ComponentFormControl { Id = 5, ComponentFormId = 1, Name = "classId", Type = "number", Label = "Class", Field = "classId" });
            builder.HasData(new ComponentFormControl { Id = 6, ComponentFormId = 1, Name = "sectorId", Type = "text", Label = "Business Sector", Field = "sectorId" });
            builder.HasData(new ComponentFormControl { Id = 7, ComponentFormId = 2, Name = "email", Type = "email", Label = "Email", Field = "email" });
            builder.HasData(new ComponentFormControl { Id = 8, ComponentFormId = 2, Name = "phone", Type = "text", Label = "Phone", Field = "phone" });
            builder.HasData(new ComponentFormControl { Id = 9, ComponentFormId = 2, Name = "mobile", Type = "text", Label = "Mobile", Field = "mobile" });
            builder.HasData(new ComponentFormControl { Id = 10, ComponentFormId = 2, Name = "landLine", Type = "text", Label = "Land Line", Field = "landLine" });
            builder.HasData(new ComponentFormControl { Id = 11, ComponentFormId = 2, Name = "fax", Type = "text", Label = "Fax", Field = "fax" });
            builder.HasData(new ComponentFormControl { Id = 12, ComponentFormId = 3, Name = "addressLine1", Type = "text", Label = "Address Line 1", Field = "addressLine1" });
            builder.HasData(new ComponentFormControl { Id = 13, ComponentFormId = 3, Name = "addressLine2", Type = "text", Label = "Address Line 2", Field = "addressLine2" });
            builder.HasData(new ComponentFormControl { Id = 14, ComponentFormId = 3, Name = "buildingNo", Type = "text", Label = "Building No.", Field = "buildingNo" });
            builder.HasData(new ComponentFormControl { Id = 15, ComponentFormId = 3, Name = "secondaryNo", Type = "text", Label = "Secondary No.", Field = "secondaryNo" });
            builder.HasData(new ComponentFormControl { Id = 16, ComponentFormId = 3, Name = "postalCode", Type = "text", Label = "Postal Code", Field = "postalCode" });
            builder.HasData(new ComponentFormControl { Id = 17, ComponentFormId = 3, Name = "street", Type = "text", Label = "Street", Field = "street" });
            builder.HasData(new ComponentFormControl { Id = 18, ComponentFormId = 3, Name = "street_OtherLanguage", Type = "text", Label = "Street (Other Lang)", Field = "street_OtherLanguage" });
            builder.HasData(new ComponentFormControl { Id = 19, ComponentFormId = 3, Name = "district", Type = "text", Label = "District", Field = "district" });
            builder.HasData(new ComponentFormControl { Id = 20, ComponentFormId = 3, Name = "district_OtherLanguage", Type = "text", Label = "District (Other Lang)", Field = "district_OtherLanguage" });
            builder.HasData(new ComponentFormControl { Id = 21, ComponentFormId = 3, Name = "countryId", Type = "number", Label = "Country", Field = "countryId" });
            builder.HasData(new ComponentFormControl { Id = 22, ComponentFormId = 3, Name = "cityId", Type = "number", Label = "City", Field = "cityId" });
            builder.HasData(new ComponentFormControl { Id = 23, ComponentFormId = 3, Name = "regionId", Type = "number", Label = "Region", Field = "regionId" });
            builder.HasData(new ComponentFormControl { Id = 24, ComponentFormId = 4, Name = "inChargePersonName", Type = "text", Label = "Name", Field = "inChargePersonName" });
            builder.HasData(new ComponentFormControl { Id = 25, ComponentFormId = 4, Name = "inChargePersonPositionId", Type = "number", Label = "Position", Field = "inChargePersonPositionId" });
            builder.HasData(new ComponentFormControl { Id = 26, ComponentFormId = 4, Name = "inChargePersonPhone1", Type = "text", Label = "Phone 1", Field = "inChargePersonPhone1" });
            builder.HasData(new ComponentFormControl { Id = 27, ComponentFormId = 4, Name = "inChargePersonPhone2", Type = "text", Label = "Phone 2" , Field = "inChargePersonPhone2" });
            builder.HasData(new ComponentFormControl { Id = 28, ComponentFormId = 4, Name = "inChargePersonEmail", Type = "email", Label = "Email", Field = "inChargePersonEmail" });
            builder.HasData(new ComponentFormControl { Id = 29, ComponentFormId = 5, Name = "paymentTermId", Type = "number", Label = "Payment Term" , Field = "paymentTermId" });
            builder.HasData(new ComponentFormControl { Id = 30, ComponentFormId = 5, Name = "validityPeriodId", Type = "number", Label = "Validity Period" , Field = "validityPeriodId" });
            builder.HasData(new ComponentFormControl { Id = 31, ComponentFormId = 5, Name = "priceNoteId", Type = "number", Label = "Price Note" , Field = "priceNoteId" });
            builder.HasData(new ComponentFormControl { Id = 32, ComponentFormId = 6, Name = "numberOfBranches", Type = "number", Label = "Number of Branches" , Field = "numberOfBranches" });
            builder.HasData(new ComponentFormControl { Id = 33, ComponentFormId = 6, Name = "permissionRequired", Type = "boolean", Label = "Permission Required" , Field = "permissionRequired" });
            builder.HasData(new ComponentFormControl { Id = 34, ComponentFormId = 6, Name = "note", Type = "text", Label = "Notes" , Field = "note" });
            builder.HasData(new ComponentFormControl { Id = 35, ComponentFormId = 6, Name = "description", Type = "text", Label = "Description" , Field = "description" });
            builder.HasData(new ComponentFormControl { Id = 36, ComponentFormId = 6, Name = "effectiveDate", Type = "date", Label = "Effective Date" , Field = "effectiveDate" });
            builder.HasData(new ComponentFormControl { Id = 37, ComponentFormId = 6, Name = "status", Type = "text", Label = "Status" , Field = "status", DefaultValue = "Draft" });
        }
    }
}

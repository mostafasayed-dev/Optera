using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class DataTableColumnConfig : IEntityTypeConfiguration<DataTableColumn>
    {
        public void Configure(EntityTypeBuilder<DataTableColumn> builder)
        {
            builder.Ignore(p => p.Status);
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.Updator);
            //countries - list
            builder.HasData(
                new DataTableColumn { Id = 1, DataTableId = 1, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 2, DataTableId = 1, Name = "name", Text = "Country Name", Sortable = true, Visible = true, Order = 1 },
                new DataTableColumn { Id = 3, DataTableId = 1, Name = "name_OtherLanguage", Text = "Country Name (Other Lang.)", Sortable = true, Visible = true, Order = 2 },
                new DataTableColumn { Id = 4, DataTableId = 1, Name = "status", Text = "Status", Sortable = true, Visible = true, Order = 3 }
                );
            //cities - list
            builder.HasData(
                new DataTableColumn { Id = 5, DataTableId = 2, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 6, DataTableId = 2, Name = "name", Text = "City Name", Sortable = true, Visible = true, Order = 1 },
                new DataTableColumn { Id = 7, DataTableId = 2, Name = "name_OtherLanguage", Text = "City Name (Other Lang.)", Sortable = true, Visible = true, Order = 2 },
                new DataTableColumn { Id = 8, DataTableId = 2, Name = "countryName", Text = "Country", Sortable = true, Visible = true, Order = 3 },
                new DataTableColumn { Id = 9, DataTableId = 2, Name = "status", Text = "Status", Sortable = true, Visible = true, Order = 4 }
                );
            //regions - list
            builder.HasData(
                new DataTableColumn { Id = 10, DataTableId = 3, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 11, DataTableId = 3, Name = "name", Text = "Region Name", Sortable = true, Visible = true, Order = 1 },
                new DataTableColumn { Id = 12, DataTableId = 3, Name = "name_OtherLanguage", Text = "Region Name (Other Lang.)", Sortable = true, Visible = true, Order = 2 },
                new DataTableColumn { Id = 13, DataTableId = 3, Name = "cityName", Text = "City", Sortable = true, Visible = true, Order = 3 },
                new DataTableColumn { Id = 14, DataTableId = 3, Name = "cityId", Text = "City ID", Sortable = true, Visible = false, Order = 4 },
                new DataTableColumn { Id = 15, DataTableId = 3, Name = "countryName", Text = "Country", Sortable = true, Visible = true, Order = 5 },
                new DataTableColumn { Id = 16, DataTableId = 3, Name = "status", Text = "Status", Sortable = true, Visible = true, Order = 6 }
                );
            //categories-list
            builder.HasData(
                new DataTableColumn { Id = 17, DataTableId = 4, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 18, DataTableId = 4, Name = "name", Text = "Category Name", Sortable = true, Visible = true, Order = 1 },
                new DataTableColumn { Id = 19, DataTableId = 4, Name = "description", Text = "Description", Sortable = true, Visible = true, Order = 2 },
                new DataTableColumn { Id = 20, DataTableId = 4, Name = "status", Text = "Status", Sortable = true, Visible = true, Order = 3 }
                );
            //categories-items-list
            builder.HasData(
                new DataTableColumn { Id = 21, DataTableId = 5, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 22, DataTableId = 5, Name = "name", Text = "Category Item Name", Sortable = true, Visible = true, Order = 1 },
                new DataTableColumn { Id = 23, DataTableId = 5, Name = "name_OtherLanguage", Text = "Category Item Name (Other Lang.)", Sortable = true, Visible = true, Order = 2 },
                new DataTableColumn { Id = 24, DataTableId = 5, Name = "categoryName", Text = "Category Name", Sortable = true, Visible = true, Order = 3 },
                new DataTableColumn { Id = 25, DataTableId = 5, Name = "categoryId", Text = "Category ID", Sortable = true, Visible = false, Order = 4 },
                new DataTableColumn { Id = 26, DataTableId = 5, Name = "status", Text = "Status", Sortable = true, Visible = true, Order = 5 }
                );
            //quotations-list
            builder.HasData(
                new DataTableColumn { Id = 27, DataTableId = 6, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 28, DataTableId = 6, Name = "code", Text = "Code", Sortable = true, Visible = true, Order = 1 },
                new DataTableColumn { Id = 29, DataTableId = 6, Name = "customer.name", Text = "Customer Name", Sortable = true, Visible = true, Order = 2 },
                new DataTableColumn { Id = 30, DataTableId = 6, Name = "customer.brandName", Text = "Brand Name", Sortable = true, Visible = true, Order = 3 },
                new DataTableColumn { Id = 32, DataTableId = 6, Name = "effectiveDate", Text = "Effective Date", Sortable = true, Visible = true, Order = 5, Datatype = "date" },
                new DataTableColumn { Id = 33, DataTableId = 6, Name = "status", Text = "Status", Sortable = true, Visible = true, Order = 6 },
                new DataTableColumn { Id = 34, DataTableId = 6, Name = "employeeId", Text = "Employee Id", Sortable = true, Visible = false, Order = 7 }
                );
            //groups-list
            builder.HasData(
                new DataTableColumn { Id = 35, DataTableId = 7, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 36, DataTableId = 7, Name = "name", Text = "Group Name", Sortable = true, Visible = true, Order = 1 },
                new DataTableColumn { Id = 37, DataTableId = 7, Name = "normalizedName", Text = "Group Name (Normalized)", Sortable = true, Visible = true, Order = 2 }
                );

            //users-list
            builder.HasData(
                new DataTableColumn { Id = 38, DataTableId = 8, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 39, DataTableId = 8, Name = "userName", Text = "Username", Sortable = true, Visible = true, Order = 1 },
                new DataTableColumn { Id = 40, DataTableId = 8, Name = "employeeName", Text = "Employee Name", Sortable = true, Visible = true, Order = 2 },
                new DataTableColumn { Id = 41, DataTableId = 8, Name = "email", Text = "Email", Sortable = true, Visible = true, Order = 3 },
                new DataTableColumn { Id = 42, DataTableId = 8, Name = "emailConfirmed", Text = "Email Confirmed", Sortable = true, Visible = true, Order = 4 },
                new DataTableColumn { Id = 43, DataTableId = 8, Name = "locked", Text = "Locked", Sortable = true, Visible = true, Order = 5 }
                );
            //workflow-definitions-list
            builder.HasData(
                new DataTableColumn { Id = 44, DataTableId = 9, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 45, DataTableId = 9, Name = "name", Text = "Name", Sortable = true, Visible = true, Order = 1 },
                new DataTableColumn { Id = 46, DataTableId = 9, Name = "status", Text = "Status", Sortable = true, Visible = true, Order = 2 }
                );
            //workflow-steps-list
            builder.HasData(
                new DataTableColumn { Id = 47, DataTableId = 10, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 48, DataTableId = 10, Name = "workflowDefinitionId", Text = "Workflow Definition ID", Sortable = true, Visible = false, Order = 1 },
                new DataTableColumn { Id = 49, DataTableId = 10, Name = "workflowDefinitionName", Text = "Definition Name", Sortable = true, Visible = true, Order = 2 },
                new DataTableColumn { Id = 50, DataTableId = 10, Name = "name", Text = "Name", Sortable = true, Visible = true, Order = 3 },
                new DataTableColumn { Id = 51, DataTableId = 10, Name = "order", Text = "Order", Sortable = true, Visible = true, Order = 4 },
                new DataTableColumn { Id = 52, DataTableId = 10, Name = "isFinal", Text = "Final Step", Sortable = true, Visible = true, IsCheck = true, Order = 5 },
                new DataTableColumn { Id = 53, DataTableId = 10, Name = "status", Text = "Status", Sortable = true, Visible = true, Order = 6 }
                );
            //workflow-transitions-list
            builder.HasData(
                new DataTableColumn { Id = 54, DataTableId = 11, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = 55, DataTableId = 11, Name = "workflowDefinitionId", Text = "Workflow Definition ID", Sortable = true, Visible = false, Order = 1 },
                new DataTableColumn { Id = 56, DataTableId = 11, Name = "workflowDefinitionName", Text = "Definition Name", Sortable = true, Visible = true, Order = 2 },
                new DataTableColumn { Id = 57, DataTableId = 11, Name = "actionName", Text = "Action", Sortable = true, Visible = true, Order = 3 },
                new DataTableColumn { Id = 58, DataTableId = 11, Name = "fromStepName", Text = "From Step", Sortable = true, Visible = true, Order = 4 },
                new DataTableColumn { Id = 59, DataTableId = 11, Name = "fromStepId", Text = "From Step ID", Sortable = true, Visible = false, Order = 5 },
                new DataTableColumn { Id = 60, DataTableId = 11, Name = "toStepName", Text = "To Step", Sortable = true, Visible = true, Order = 6 },
                new DataTableColumn { Id = 61, DataTableId = 11, Name = "toStepId", Text = "To Step ID", Sortable = true, Visible = false, Order = 7 },
                new DataTableColumn { Id = 62, DataTableId = 11, Name = "targetStatus", Text = "Target Status", Sortable = true, Visible = true, Order = 8 },
                new DataTableColumn { Id = 63, DataTableId = 11, Name = "roleId", Text = "Role ID", Sortable = true, Visible = false, Order = 9 },
                new DataTableColumn { Id = 64, DataTableId = 11, Name = "roleName", Text = "Role", Sortable = true, Visible = true, Order = 10 },
                new DataTableColumn { Id = 65, DataTableId = 11, Name = "status", Text = "Status", Sortable = true, Visible = true, Order = 11 }
                );
        }
    }
}

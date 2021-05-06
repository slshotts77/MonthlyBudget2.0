using MonthlyBudget.Data;
using MonthlyBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Services
{
    public class DescriptionService
    {
        // Create
        public bool CreateDescription(DescriptionCreate model)
        {
            var entity = new Description()
            {
                DescriptionName = model.DescriptionName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Descriptions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get Main Page
        public List<DescriptionListItem> GetDescriptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx
                    .Descriptions
                    .Select(e => new DescriptionListItem
                    {
                        DescriptionId = e.DescriptionId,
                        DescriptionName = e.DescriptionName
                    }).ToList();
            }
        }

        // Get All Descriptions for Id
        public DescriptionDetail GetDescription(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Descriptions
                    .SingleOrDefault(e => e.DescriptionId == id);
                var description = new DescriptionDetail()
                {
                    DescriptionId = entity.DescriptionId,
                    DescriptionName = entity.DescriptionName,
                    Entries = entity.Entries.Select(e => new CheckingListItem()
                    {
                        CheckingId = e.CheckingId,
                        CheckingName = e.CheckingName,
                        MonthlyBill = e.MonthlyBill,
                        ChargeDate = e.ChargeDate,
                        DateCleared = e.DateCleared,
                        Cleared = e.Cleared,

                        UtilityComapny = e.UtilityCompany.UtilityCompanyId + " " + e.UtilityCompany.UtilityName,

                        Category = e.Category.CategoryId + " " + e.Category.CategoryName,

                        Description = e.Description.DescriptionId + " " + e.Description.DescriptionName,

                        PayingBy = e.PayingBy.PayById + " " + e.PayingBy.PayById
                    }).ToList()
                };

                return description;
            }
        }

        // Edit Description by Id
        public bool UpdateDescription(int id, DescriptionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Descriptions.SingleOrDefault(e => e.DescriptionId == id);
                entity.DescriptionName = model.DescriptionName;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete Entry by Id
        public bool DeleteDescription(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Descriptions.SingleOrDefault(e => e.DescriptionId == id);
                ctx.Descriptions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
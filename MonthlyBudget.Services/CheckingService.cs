using MonthlyBudget.Data;
using MonthlyBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Services
{
    public class CheckingService
    {
        private readonly Guid _userId;

        public CheckingService(Guid userId)
        {
            _userId = userId;
        }

        // Create
        public bool CreateChecking(CheckingCreate model)
        {
            var entity =
                new Checking()
                {
                    OwnerId = _userId,
                    CheckingName = model.CheckingName,
                    MonthlyBill = model.MonthlyBill,
                    ChargeDate = model.CheckingName,
                    DateCleared = model.DateCleared,
                    Cleared = model.Cleared,
                    CreatedUtc = DateTimeOffset.Now,
                    CategoryId = model.CategoryId,
                    UtilityCompanyId = model.UtilityCompanyId,
                    DescriptionId = model.DescriptionId,
                    PayingById = model.PayingById,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entries.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        // Get All
        public IEnumerable<CheckingListItem> GetEntries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Entries
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CheckingListItem
                                {
                                    CheckingId = e.CheckingId,
                                    CheckingName = e.CheckingName,
                                    MonthlyBill = e.MonthlyBill,
                                    ChargeDate = e.ChargeDate,
                                    DateCleared = e.DateCleared,
                                    Cleared = e.Cleared,

                                    UtilityComapny = e.UtilityCompanyId + " " + e.UtilityCompany.UtilityName,

                                    Category = e.CategoryId + " " + e.Category.CategoryName,

                                    Description = e.DescriptionId + " " + e.Description.DescriptionName,

                                    PayingBy = e.PayingById + " " + e.PayingBy.CashOrCard
                                });
                return query.ToArray();
            }
        }

        //Get By ID
        public CheckingDetail GetEntryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Entries
                        .Single(e => e.CheckingId == id && e.OwnerId == _userId);
                return
                    new CheckingDetail
                    {
                        CheckingId = entity.CheckingId,
                        CheckingName = entity.CheckingName,
                        MonthlyBill = entity.MonthlyBill,
                        ChargeDate = entity.ChargeDate,
                        DateCleared = entity.DateCleared,
                        Cleared = entity.Cleared,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        UtilityComapny = entity.UtilityCompany.UtilityCompanyId + " " + entity.UtilityCompany.UtilityName,
                        Category = entity.Category.CategoryId + " " + entity.Category.CategoryName,
                        Description = entity.Description.DescriptionId + " " + entity.Description.DescriptionName,
                        PayingBy = entity.PayingBy.PayById + " " + entity.PayingBy.PayById
                    };
            }
        }

        //Edit Checking by ID
        public bool UpdateEntry(CheckingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Entries
                        .Single(e => e.CheckingId == model.CheckingId && e.OwnerId == _userId);

                entity.CheckingName = model.CheckingName;
                entity.MonthlyBill = model.MonthlyBill;
                entity.ChargeDate = model.ChargeDate;
                entity.DateCleared = model.DateCleared;
                entity.Cleared = model.Cleared;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.UtilityCompanyId = model.UtilityCompanyId;
                entity.CategoryId = model.CategoryId;
                entity.DescriptionId = model.DescriptionId;
                entity.PayingById = model.PayingById;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Checking by ID
        public bool DeleteEntry(int checkingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Entries
                        .Single(e => e.CheckingId == checkingId && e.OwnerId == _userId);

                ctx.Entries.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
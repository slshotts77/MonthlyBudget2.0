using System;
using MonthlyBudget.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonthlyBudget.Data;

namespace MonthlyBudget.Services
{
    public class UtilityCompanyService
    {
        //private readonly Guid _userId;
        //public UtilityCompanyService(Guid userId)
        //{
        //    _userId = userId;
        //}

        // Create
        public bool CreateUtilityCompany(UtilityCompanyCreate model)
            {
                var entity =
                    new UtilityCompany()
                    {
                        //OwnerId = _userId,
                        UtilityName = model.UtilityName,
                        Website = model.Website,
                        UserLogin = model.UserLogin,
                        UserPassword = model.UserPassword,
                        PhoneNumber = model.PhoneNumber,
                    };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Companies.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }


        // Get Main Page
        public List<UtilityCompanyListItem> GetCompanies()
            {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx
                    .Companies
                    .Select(e => new UtilityCompanyListItem
                    {
                        UtilityCompanyId = e.UtilityCompanyId,
                        UtilityName = e.UtilityName,
                        Website = e.Website,
                        UserLogin = e.UserLogin,
                        UserPassword = e.UserPassword,
                        PhoneNumber = e.PhoneNumber
                    }).ToList();
            }
        }

        // Get All Utility Companies for Id
        public UtilityCompanyDetail GetUtilityCompany(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Companies
                    .SingleOrDefault(e => e.UtilityCompanyId == id);
                var utilityCompany = new UtilityCompanyDetail()
                {
                    UtilityCompanyId = entity.UtilityCompanyId,
                    UtilityName = entity.UtilityName,
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

                return utilityCompany;
            }
        }

        // Edit Utility Companies by Id
        public bool UpdateUtilityCompany(int id, UtilityCompanyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Companies.SingleOrDefault(e => e.UtilityCompanyId == id);
                entity.UtilityName = model.UtilityName;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete Utility Companies by Id
        public bool DeleteUtilityCompany(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Companies.SingleOrDefault(e => e.UtilityCompanyId == id);
                ctx.Companies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
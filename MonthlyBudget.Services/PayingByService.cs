using System;
using MonthlyBudget.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonthlyBudget.Data;

namespace MonthlyBudget.Services
{
    public class PayingByService
    {
        // Create
        public bool CreatePayingBy(PayingByCreate model)
        {
            var entity = new PayingBy()
            {
                CashOrCard = model.CashOrCard
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Payments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get Main Page
        public List<PayingByListItem> GetPayments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx
                    .Payments
                    .Select(e => new PayingByListItem
                    {
                        PayById = e.PayById,
                        CashOrCard = e.CashOrCard,
                        CashAmount = e.CashAmount,
                        CardType = e.CardType,
                        CardNumber = e.CardNumber,
                        NameOnCard = e.NameOnCard,
                        ExpirationDate = e.ExpirationDate,
                        SecurityCode = e.SecurityCode
                    }).ToList();
            }
        }

        // Get All Payments for Id
        public PayingByDetail GetPayingBy(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Payments
                    .SingleOrDefault(e => e.PayById == id);
                var payingBy = new PayingByDetail()
                {
                    PayById = entity.PayById,
                    CashOrCard = entity.CashOrCard,
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

                return payingBy;
            }
        }

        // Edit Payment by Id
        public bool UpdatePayingBy(int id, PayingByEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Payments.SingleOrDefault(e => e.PayById == id);
                entity.CashOrCard = model.CashOrCard;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete Payment by Id
        public bool DeletePayingBy(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Payments.SingleOrDefault(e => e.PayById == id);
                ctx.Payments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
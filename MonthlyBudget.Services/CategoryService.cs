using MonthlyBudget.Data;
using MonthlyBudget.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonthlyBudget.Services
{
    public class CategoryService
    {
        // Create
        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                CategoryName = model.CategoryName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get Main Page
        public List<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx
                    .Categories
                    .Select(e => new CategoryListItem
                    {
                        CategoryId = e.CategoryId,
                        CategoryName = e.CategoryName
                    }).ToList();
            }
        }

        // Get All Category for Id
        public CategoryDetail GetCategory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Categories
                    .SingleOrDefault(e => e.CategoryId == id);
                var category = new CategoryDetail()
                {
                    CategoryId = entity.CategoryId,
                    CategoryName = entity.CategoryName,
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

                return category;
            }
        }

        // Edit Entry by Id
        public bool UpdateCategory(int id, CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.SingleOrDefault(e => e.CategoryId == id);
                entity.CategoryName = model.CategoryName;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete Entry by Id
        public bool DeleteCategory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.SingleOrDefault(e => e.CategoryId == id);
                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
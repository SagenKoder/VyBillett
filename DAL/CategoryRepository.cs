using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> Get()
        {
            using (var db = new VyDbContext())
            {
                return db.Categories.ToList();
            }
        }

        public Category Get(int id)
        {
            using (var db = new VyDbContext())
            {
                return db.Categories.Single(i => i.CategoryId == id);
            }
        }

        public Category Get(string name)
        {
            using (var db = new VyDbContext())
            {
                return db.Categories.FirstOrDefault(c => c.CategoryName.Equals("Adult"));
            }
        }

        public bool Edit(int id, Category category)
        {
            using (var db = new VyDbContext())
            {
                // Finds the Station from the database
                // TODO: Test if this one work! The example wasn't clear
                var categoryToChange = db.Categories.First(s => s.CategoryId == id);
                if (categoryToChange == null)
                {
                    return false;
                }

                categoryToChange.CategoryName = category.CategoryName;
                categoryToChange.CategoryPrice = category.CategoryPrice;

                db.SaveChanges();
                return true;
            }
        }

        public bool Insert(Category category)
        {
            if (category.CategoryId == default)
            {
                return false;
            }
            if (category.CategoryName.Equals(""))
            {
                return false;
            }

            using (var db = new VyDbContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new VyDbContext())
            {
                var category = db.Categories.Find(id);
                if (category == null)
                {
                    return false;
                }
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
        }

    }
}

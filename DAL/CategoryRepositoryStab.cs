using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class CategoryRepositoryStab : ICategoryRepository
    {
        public List<Category> Get()
        {
            List<Category> categories = new List<Category>();

            var Adult = new Category { CategoryPrice = 120, CategoryName = "Adult" };
            var Student = new Category { CategoryPrice = 95, CategoryName = "Student" };
            var Child = new Category { CategoryPrice = 60, CategoryName = "Child" };

            categories.Add(Adult);
            categories.Add(Student);
            categories.Add(Child);

            return categories;
        }

        public Category Get(int id)
        {
            return new Category { CategoryId = id, CategoryPrice = 120, CategoryName = "Adult" };
        }

        public Category Get(string name)
        {
            return new Category { CategoryId = 5, CategoryPrice = 120, CategoryName = name }; ;
        }

        public bool Edit(int id, Category category)
        {
            category.CategoryId = id;
            return true;
        }

        public bool Insert(Category category)
        {
            category.CategoryId = 5;
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }

    }
}

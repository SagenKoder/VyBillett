using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICategoryRepository
    {
        List<Category> Get();
        Category Get(int id);
        Category Get(string name);
        bool Edit(int id, Category category);
        bool Insert(Category category);
        bool Delete(int id);
    }
}

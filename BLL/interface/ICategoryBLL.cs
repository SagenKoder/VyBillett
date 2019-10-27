using Model;
using System.Collections.Generic;

namespace BLL
{
    public interface ICategoryBLL
    {
        List<Category> Get();

        Category Get(int id);

        Category Get(string name);

        bool Edit(int id, Category category);

        bool Insert(Category category);

        bool Delete(int id);
    }
}

using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");

        public CategoryBLL()
        {
            _categoryRepository = new CategoryRepository();
        }

        public CategoryBLL(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> Get()
        {
            return _categoryRepository.Get();
        }

        public Category Get(int id)
        {
            return _categoryRepository.Get(id);
        }

        public Category Get(string name)
        {
            return _categoryRepository.Get(name);
        }

        public bool Edit(int id, Category category)
        {
            return _categoryRepository.Edit(id, category);
        }

        public bool Insert(Category category)
        {
            return _categoryRepository.Insert(category);
        }

        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }
    }
}

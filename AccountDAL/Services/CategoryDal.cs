using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Services
{
    public class CategoryDal : ICategoryDal
    {
        private readonly IMapper mapper;
        public CategoryDal(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public CategoryDTO CreateCategory(CategoryDTO category)
        {
            using (var entities = new TradingCompany2022TESTEntities())
            {
                var categoryDB = mapper.Map<Category>(category);
                entities.Categories.Add(categoryDB);
                entities.SaveChanges();
                return mapper.Map<CategoryDTO>(categoryDB);
            }
        }

        public List<CategoryDTO> GetAllСategories()
        {

            using (var entities = new TradingCompany2022TESTEntities())
            {
                var categories = entities.Categories.ToList();
                return mapper.Map<List<CategoryDTO>>(categories);
            }
        }

        public CategoryDTO UpdateCategory(CategoryDTO newCategory, int id)
        {
            using (var entities = new TradingCompany2022TESTEntities())
            { 
                var categoryToUpdate = entities.Categories.Find(id);
                if (categoryToUpdate != null)
                {
                    var newCategoryDB = mapper.Map<Category>(newCategory);
                    categoryToUpdate.Name = newCategoryDB.Name;
                    entities.SaveChanges();
                    return mapper.Map<CategoryDTO>(categoryToUpdate);
                }
                return null;
            }
        }

        public CategoryDTO DeleteCategory(int id)
        {
            using (var entities = new TradingCompany2022TESTEntities())
            {
                var categoryToDelete = entities.Categories.Find(id);
                if (categoryToDelete != null)
                {
                    entities.Categories.Remove(categoryToDelete);
                    entities.SaveChanges();
                    return mapper.Map<CategoryDTO>(categoryToDelete);
                }
                return null;
            }
        }
    }
}

using PROShoping.Models;
using Microsoft.AspNetCore.Mvc;
namespace PROShoping.Bl
{
    public interface ICategory
    {
        List<TbCategory> GetAll();
        TbCategory? GetById(int categoryId);
        bool Save(TbCategory category);
        bool Delete(int id);
    }
    public class ClsCategory : ICategory
    {
        LapShopContext context;
        public ClsCategory(LapShopContext cxe)
        {
            context = cxe;
        }

        public List<TbCategory> GetAll()
        {
            try
            {
               
                var lscategories = context.TbCategories.Where(a=>a.CurrentState==1).ToList();
                return lscategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAll Categories: " + ex.Message);

            }
        }

        public TbCategory? GetById(int categoryId)
        {
            try
            {
                
                var category = context.TbCategories.FirstOrDefault(c => c.CategoryId == categoryId && c.CurrentState==1);
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetById Category: " + ex.Message);
            }
        }
        public bool Save(TbCategory category)
        {
            try
            {
               
                if (category.CategoryId == 0)
                {
                    category.CreatedBy = "1";
                    category.CreatedDate = DateTime.Now;
                    context.TbCategories.Add(category);
                }
                else
                {
                    category.UpdatedBy = "1";
                    category.UpdatedDate = DateTime.Now;
                    context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Save Category: " + ex.Message);
            }
        }

       public bool Delete(int id)
        {
            try
            {
                var category = GetById(id);
                if (category != null)
                {
                    category.CurrentState = 0;
                    context.SaveChanges();
                  
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Delete Category: " + ex.Message);
            }


        }



    }
}

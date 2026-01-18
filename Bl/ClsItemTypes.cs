using PROShoping.Models;
using Microsoft.AspNetCore.Mvc;
namespace PROShoping.Bl
{
    public interface IClsTbItemTypes
    {
        List<TbItemType> GetAll();
        TbItemType? GetById(int itemTypesId);
        bool Save(TbItemType itemTypes);
        bool Delete(int id);
    }
    public class ClsTbItemTypes : IClsTbItemTypes
    {
        LapShopContext context;
        public ClsTbItemTypes(LapShopContext cxe)
        {
            context = cxe;
        }

        public List<TbItemType> GetAll()
        {
            try
            {
                var lscategories = context.TbItemTypes.Where(a => a.CurrentState == 1).ToList();
                return lscategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAll Categories: " + ex.Message);

            }
        }

        public TbItemType? GetById(int itemTypesId)
        {
            try
            {
                var litemTypes = context.TbItemTypes.FirstOrDefault(c => c.ItemTypeId == itemTypesId && c.CurrentState == 1);
                return litemTypes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetById itemTypes: " + ex.Message);
            }
        }
        public bool Save(TbItemType itemTypes)
        {
            try
            {
                if (itemTypes.ItemTypeId == 0)
                {
                    
                    context.TbItemTypes.Add(itemTypes);
                }
                else
                {
                 
                    context.Entry(itemTypes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Save itemTypes: " + ex.Message);
            }
        }

       public bool Delete(int id)
        {
            try
            {
                var itemTypes = GetById(id);
                if (itemTypes != null)
                {
                    itemTypes.CurrentState = 0;
                    context.SaveChanges();
                  
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Delete itemTypes: " + ex.Message);
            }


        }



    }
}

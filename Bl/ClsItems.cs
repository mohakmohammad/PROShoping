using Microsoft.EntityFrameworkCore;
using PROShoping.Models;

namespace PROShoping.Bl
{
    public interface IItems
    {
        public List<TbItem> GetAll();
     
        public List<VwItem> GetAllItemsDeta(int? categreId);
        public List<VwItem> GetRecommendedItems(int ItemId);
        public TbItem GetById(int ItemsId);
        public VwItem GetItemId(int ItemsId);
        public bool Save(TbItem sItems);
        public bool Delete(int id);
       
    }
    public class ClsItems : IItems
    {
        LapShopContext context;
        public ClsItems(LapShopContext cxe)
        {
            context = cxe;
        }
        public List<TbItem> GetAll()
        {
            try
            {
                var ocontext = context.TbItems.Where(a => a.CurrentState == 1).ToList();
                return ocontext;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAll Categories: " + ex.Message);

            }
        }
      

        public List<VwItem> GetAllItemsDeta(int? categreId)
        {
            try
            {
                var lscategories = context.VwItems.Where(a => (a.CategoryId == categreId || categreId == null || categreId == 0)
                && a.CurrentState == 1 && !string.IsNullOrEmpty(a.ItemName)).OrderByDescending(a => a.CreatedDate).ToList();
                return lscategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAll VwItem: " + ex.Message);

            }
        }

        public List<VwItem> GetRecommendedItems(int ItemId)
        {
            try
            {
                var item = GetById(ItemId);
                var lscategories = context.VwItems.Where(a => a.SalesPrice > item.SalesPrice-50 
                && a.SalesPrice < item.SalesPrice+50
                && a.CurrentState == 1).OrderByDescending(a => a.CreatedDate).ToList();
                return lscategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAll VwItem: " + ex.Message);

            }
        }

        public TbItem GetById(int ItemsId)
        {
            try
            {
                var ocontext = context.TbItems.FirstOrDefault(c => c.ItemId == ItemsId && c.CurrentState == 1);
                return ocontext;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetById Category: " + ex.Message);
            }
        }

        public VwItem GetItemId(int id)
        {
            try
            {
                var item = context.VwItems.FirstOrDefault(a => a.ItemId == id && a.CurrentState == 1);
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetById Category: " + ex.Message);
            }
        }
        public bool Save(TbItem sItems)
        {
            try
            {
                if (sItems.ItemId == 0)
                {
                    sItems.CurrentState = 1;


                    context.TbItems.Add(sItems);
                }
                else
                {

                    context.Entry(sItems).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Save ocontext: " + ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var idItems = GetById(id);
                if (idItems != null)
                {
                    idItems.CurrentState = 0;
                    context.Entry(idItems).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Delete ocontext: " + ex.Message);
            }


        }

    }
}

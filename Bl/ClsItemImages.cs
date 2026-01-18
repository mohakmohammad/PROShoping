using PROShoping.Models;

namespace PROShoping.Bl
{
    public interface IItemImages
    {
   
     public List<TbItemImage> GetByItemId(int ItemsId);
   

    }
    public class ClsItemImages : IItemImages
    {
        LapShopContext context;
        public ClsItemImages(LapShopContext cxe)
        {
            context = cxe;
        }


        public List<TbItemImage> GetByItemId(int ItemsId)
        {
            try
            {
                var ocontext = context.TbItemImages.Where(c => c.ItemId == ItemsId ).ToList();
                return ocontext;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetById Category: " + ex.Message);
            }
        }



    }
}

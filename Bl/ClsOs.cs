using PROShoping.Models;
using Microsoft.AspNetCore.Mvc;
namespace PROShoping.Bl
{

    public interface IClsOs
    {
        List<TbO> GetAll();
        TbO? GetById(int osId);
        bool Save(TbO osId);
        bool Delete(int id);
    }
    public class ClsOs : IClsOs
    {
        LapShopContext context;
        public ClsOs(LapShopContext cxe)
        {
            context = cxe;
        }

        public List<TbO> GetAll()
        {
            try
            {
                var lscategories = context.TbOs.Where(a => a.CurrentState == 1).ToList();
                return lscategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAll Categories: " + ex.Message);

            }
        }

        public TbO? GetById(int osId)
        {
            try
            {
                var losId = context.TbOs.FirstOrDefault(c => c.OsId == osId && c.CurrentState==1);
                return losId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetById osId: " + ex.Message);
            }
        }
        public bool Save(TbO osId)
        {
            try
            {
                if (osId.OsId == 0)
                {
                    
                    context.TbOs.Add(osId);
                }
                else
                {
                 
                    context.Entry(osId).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Save osId: " + ex.Message);
            }
        }

       public bool Delete(int id)
        {
            try
            {
                var osId = GetById(id);
                if (osId != null)
                {
                    osId.CurrentState = 0;
                    context.SaveChanges();
                  
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Delete osId: " + ex.Message);
            }


        }



    }
}

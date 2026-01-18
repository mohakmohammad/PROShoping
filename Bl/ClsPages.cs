using PROShoping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROShoping.Bl
{
    public interface IPages
    {
        public List<TbPages> GetAll();
        public TbPages GetById(int id);
        public bool Save(TbPages id);
              public bool Delete(int id);




    }
    public class ClsPages : IPages
    {
        private readonly LapShopContext context;

        public ClsPages(LapShopContext cxe)
        {
            context = cxe;
        }
        public List<TbPages> GetAll()
        {
            try
            {
                var lscategories = context.TbPages.Where(a => a.CurrentState == 1).ToList();
                return lscategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAll Categories: " + ex.Message);

            }
        }

        public TbPages GetById(int id)
        {
            try
            {
                var losId = context.TbPages.FirstOrDefault(c => c.PageId== id && c.CurrentState == 1);
                return losId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetById osId: " + ex.Message);
            }
        }
        public bool Save(TbPages id)
        {
            try
            {
                if (id.PageId== 0)
                {

                    context.TbPages.Add(id);
                }
                else
                {

                    context.Entry(id).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var pagId = GetById(id);
                if (pagId != null)
                {
                    pagId.CurrentState = 0;
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

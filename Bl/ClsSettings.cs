using PROShoping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface ISettings
    {
        public TbSettings GetAll();

        bool Save(TbSettings settings);

    }
    public class ClsSettings : ISettings
    {
        private readonly LapShopContext context;

        public ClsSettings(LapShopContext cxe)
        {
            context = cxe;
        }

        public TbSettings GetAll()
        {
            try
            {
                var lsSettings = context.TbSettings.FirstOrDefault();
                return lsSettings;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAll Settings: " + ex.Message);
            }
        }
        public bool Save(TbSettings settings)
        {
            try
            {
                context.Entry(settings).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Save Slider: " + ex.Message);
            }
        }








    }
}

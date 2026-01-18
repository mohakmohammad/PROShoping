using PROShoping.Models;
using Microsoft.AspNetCore.Mvc;

namespace PROShoping.Bl
{
    public interface IClsSlider
    {
        List<TbSlider> GetAll();
        TbSlider? GetById(int sliderId);
        bool Save(TbSlider slider);
        bool Delete(int id);
    }

    public class ClsSlider : IClsSlider
    {
        private readonly LapShopContext context;

        public ClsSlider(LapShopContext cxe)
        {
            context = cxe;
        }

        // جلب كل السلايدات الفعالة
        public List<TbSlider> GetAll()
        {
            try
            {
                return context.TbSliders
                    .Where(s => s.CurrentState == 1)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAll Sliders: " + ex.Message);
            }
        }

        // جلب سلايدر حسب الـID
        public TbSlider? GetById(int sliderId)
        {
            try
            {
                return context.TbSliders
                    .FirstOrDefault(s => s.SliderId == sliderId && s.CurrentState == 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetById SliderId: " + ex.Message);
            }
        }

        // إضافة أو تعديل سلايدر
        public bool Save(TbSlider slider)
        {
            try
            {
                if (slider.SliderId == 0)
                {
                    slider.CurrentState = 1; // تأكد إنه مفعل
                    slider.CreatedDate = DateTime.Now;
                    context.TbSliders.Add(slider);
                }
                else
                {
                    slider.UpdatedDate = DateTime.Now;
                    context.Entry(slider).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Save Slider: " + ex.Message);
            }
        }

        // حذف السلايدر (تغيير الحالة فقط)
        public bool Delete(int id)
        {
            try
            {
                var slider = GetById(id);
                if (slider != null)
                {
                    slider.CurrentState = 0;
                    slider.UpdatedDate = DateTime.Now;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Delete Slider: " + ex.Message);
            }
        }
    }
}

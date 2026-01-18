using Microsoft.AspNetCore.Mvc;
using PROShoping.Bl;
using PROShoping.Models;

namespace PROShoping.Controllers
{
    public class HomeController : Controller
    {
         IItems olitems;
        IClsSlider oSliderBl;
        ICategory oCategory;



        public HomeController(IItems item, IClsSlider slider, ICategory oCategory)
        {
            olitems = item;
            oSliderBl = slider;  // تمريره عن طريق DI
            this.oCategory = oCategory;
        }

        public IActionResult Index()
        {
            VmHomePage vmHomePage = new VmHomePage();

            // المنتجات
            var allItems = olitems.GetAllItemsDeta(null).ToList();
            vmHomePage.lstAllItems = allItems.OrderBy(x => Guid.NewGuid()).Take(12).ToList();
            vmHomePage.lstRecommendedItems = allItems.OrderBy(x => Guid.NewGuid()).Take(20).ToList();
            vmHomePage.lstNewItems = allItems.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
            vmHomePage.lstFreeDelivry = allItems.OrderBy(x => Guid.NewGuid()).Take(16).ToList();
            // الفئات   
            vmHomePage.lstCategories = oCategory.GetAll().OrderBy(x => Guid.NewGuid()).Take(4).ToList();


            // ✅ جلب السلايدر من قاعدة البيانات
            vmHomePage.lstSliders = oSliderBl.GetAll();


            return View(vmHomePage);
        }
    }
}

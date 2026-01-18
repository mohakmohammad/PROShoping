using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROShoping.Bl;
using PROShoping.Models;
using PROShoping.Utiletes;
using System.Threading.Tasks;

namespace PROShoping.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin,Data Entry")]
    [Area("admin")]
    public class CategoriesController : Controller
    {
        public CategoriesController(ICategory category)
        {
            blcategory = category;
        }
        ICategory blcategory ;
        public IActionResult List()
        {
            
            var lscategories = blcategory.GetAll();
            return View(lscategories);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? categoryId)
        {
            var category = new TbCategory();
            if (categoryId !=null)
            {
               
                category = blcategory.GetById(Convert.ToInt32(categoryId));

            }
            return View(category);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbCategory category,List<IFormFile> Files)
        {
          
            // هل النموذج صحيح
            if (!ModelState.IsValid)
                return View("Edit", category);
            category.ImageName = await Helpar.UploadImage(Files, "Categories");
            blcategory.Save(category);

            

            return RedirectToAction("List");
        }

        public IActionResult Delete(int? categoryId)
        {
             blcategory.Delete(Convert.ToInt32(categoryId));
           
            return RedirectToAction("List");
        }

        


    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROShoping.Bl;
using PROShoping.Models;
using PROShoping.Utiletes;

namespace PROShoping.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Data Entry")]
    [Area("admin")]
    public class ItemsController : Controller
    {
        public ItemsController(ICategory IoCategories, IItems IoItems , IClsTbItemTypes IoitemTypes , IClsOs IoOs)
        {
            oCategories = IoCategories;
            oItems = IoItems;
            oitemTypes = IoitemTypes;
            oOs = IoOs;


        }

        IItems oItems ;
        ICategory oCategories;
        IClsOs oOs ;
        IClsTbItemTypes oitemTypes ;

        public IActionResult List()
        {

            ViewBag.listCategories = oCategories.GetAll();
            var lsItems = oItems.GetAllItemsDeta(null);
            return View(lsItems);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? Itemid)
        {
            var oItem = new Models.TbItem();
            ViewBag.lstCategories = oCategories.GetAll();
            ViewBag.lstItemTypes = oitemTypes.GetAll();
            ViewBag.lstOs =oOs.GetAll();


            if (Itemid != null && Itemid != 0)
            {
                oItem = oItems.GetById((int)Itemid);
            }
            return View(oItem);


        }
        public IActionResult Search(int id) 
        {
            ViewBag.listCategories = oCategories.GetAll();
            var lsItems = oItems.GetAllItemsDeta(id);
            return View("List", lsItems);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbItem leItems, List<IFormFile> Files)
        {

            // هل النموذج صحيح
            if (!ModelState.IsValid)
                return View("Edit", leItems);
            leItems.ImageName = await Helpar.UploadImage(Files, "Items");
            oItems.Save(leItems);



            return RedirectToAction("List");
        }
        public IActionResult Delet(int? itemId)
        {
            oItems.Delete(Convert.ToInt32(itemId));

            return RedirectToAction("List");
        }

    }
}

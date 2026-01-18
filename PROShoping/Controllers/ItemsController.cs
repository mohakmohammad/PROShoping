using Microsoft.AspNetCore.Mvc;
using PROShoping.Bl;
using PROShoping.Models;
using System.ComponentModel;

namespace PROShoping.Controllers
{
    public class ItemsController : Controller
    {
        IItems oiItems;
        IItemImages oItemImages;
        public ItemsController(IItems iItem, IItemImages iItemImages)
        {
            oiItems = iItem;
            oItemImages = iItemImages;
        }
        public IActionResult ItemDetails(int id)
        {
            var oVwItem = oiItems.GetItemId(id);

            VmItemDetails vm = new VmItemDetails();
            vm.Item = oVwItem;
            vm.lstRecommendedItems = oiItems.GetRecommendedItems(id).OrderBy(x => Guid.NewGuid()).Take(6).ToList();
            vm.lstItemImages = oItemImages.GetByItemId(id);



            return View(vm);
        }
        public IActionResult ItemsList()
        {
           

            return View();
        }
    }
}

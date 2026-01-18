using Bl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROShoping.Bl;

namespace PROShoping.Controllers
{
    public class PagesController : Controller
    {
        IPages oClsPage;
        public PagesController(IPages page)
        {
            oClsPage=page;
        }
        // GET: PagesController
        public ActionResult Index(int pageId)
        {
            var page=oClsPage.GetById(pageId);
            return View(page);
        }
    }
}

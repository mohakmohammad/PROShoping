using Bl;
using Microsoft.AspNetCore.Mvc;
using PROShoping.Models;


namespace PROShoping.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SettingController : ControllerBase
    {
        ISettings _oClsSettings;
        public SettingController(ISettings oClsSettings)
        {
            _oClsSettings= oClsSettings;
        }
        [HttpGet]
        public TbSettings Get()
        {
            var oSettingAll = _oClsSettings.GetAll();
            return oSettingAll;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

   

      
    }
}

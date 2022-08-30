using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Przeglądarka_struktury_dyskowej.Models;
using System.Configuration;
using Microsoft.AspNetCore.StaticFiles;

namespace Przeglądarka_struktury_dyskowej.Controllers
{
    [ApiController]
    [Route("Data")]
    public class DictionaryController : Controller
    {
        
        private Data data = new Data();
        private string root = ConfigurationManager.AppSettings["root"];
        // GET: DictionaryController
        [HttpGet]
        [Route("Get")]
        public JsonResult Get()
        {
            return Json(data.GetValues(root));
        }

        [HttpPost]
        [Route("GetDictData")]
        public JsonResult GetDictData(string dictName)
        {
            return Json(data.GetValues(root+@"\"+dictName));
        }

        [HttpPost]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string name, string dictName)
        {
            if (ModelState.IsValid | String.IsNullOrEmpty(name))
            {
                try
                {
                    string fileName;
                    if (String.IsNullOrEmpty(dictName)) fileName = root + @"\" + name;
                    else fileName = root + @"\" + dictName + @"\" + name;
                    var file = await System.IO.File.ReadAllBytesAsync(fileName);
                    new FileExtensionContentTypeProvider().TryGetContentType(name, out string fileType);
                    return File(file, fileType, name);
                }
                catch
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}

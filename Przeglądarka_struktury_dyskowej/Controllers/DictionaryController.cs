using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Przeglądarka_struktury_dyskowej.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Net.Http.Headers;
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

        

       
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult Get()
        {
            return Ok(data.GetValues(root));
        }

        [HttpPost]
        [Route("GetDictData")]
        public IActionResult GetDictData(string dictName)
        {
            return Ok(data.GetValues(root+@"\"+dictName));
        }

        [HttpPost]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string name, string dictName)
        {
            if (ModelState.IsValid | !String.IsNullOrEmpty(name))
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
        [HttpPost]
        [Route("DeleteFile")]
        public IActionResult DeleteFile(string name, string dictName,bool isDict)
        {
            if (!String.IsNullOrEmpty(name))
            {
                try
                {
                    if (!String.IsNullOrEmpty(dictName))
                    {
                        if (isDict)
                        {
                            if (String.IsNullOrEmpty(data.GetValues(root + @"\" + dictName).ToString()))
                            {
                                System.IO.File.Delete(root + @"\" + dictName + @"\" + name);
                                return GetDictData(dictName);
                            }
                            else
                            {
                                return BadRequest("have file inside");
                            }
                        }
                        else
                        {
                            System.IO.File.Delete(root + @"\" + dictName + @"\" + name);
                            return GetDictData(dictName);
                        }
                    }
                    else
                    {
                        if (isDict)
                        {
                            if (String.IsNullOrEmpty(data.GetValues(root + @"\" + dictName).ToString()))
                            {
                                System.IO.File.Delete(root + @"\" + name);
                                return GetDictData(dictName);
                            }
                            else
                            {
                                return BadRequest("have file inside");
                            }
                        }
                        else
                        {
                            System.IO.File.Delete(root + @"\" + name);
                            return GetDictData(dictName);
                        }
                    }
                }
                catch
                {
                    return BadRequest();
                }
            }
            return BadRequest("Must have name");
        }

        
    }
}

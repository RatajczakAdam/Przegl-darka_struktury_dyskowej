using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Przeglądarka_struktury_dyskowej.Models;
using Microsoft.Extensions.Options;

namespace Przeglądarka_struktury_dyskowej.Controllers
{
    [ApiController]
    [Route("Data")]
    public class DictionaryController : Controller
    {
        
        private Data data = new Data();
        // GET: DictionaryController
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return data.GetValues("");
        }
        //// GET: DictionaryController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: DictionaryController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DictionaryController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DictionaryController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DictionaryController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DictionaryController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DictionaryController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

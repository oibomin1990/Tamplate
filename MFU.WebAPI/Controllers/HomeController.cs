using MFU.Models;
using MFU.Models.ValidationRules;
using MFU.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MFU.WebAPI.Controllers
{
    public class HomeController : BaseController
    {
        private DocumentCategoryService documentCategoryService;
        
        public HomeController()
        {
            documentCategoryService = new DocumentCategoryService(); 
        }
        public ActionResult ChangeLanguage(string lang)
        {
            CultureInfo ci = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(ci.Name);

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //var documentCategorys = documentCategoryService.GetAll();
            var documentCategorys = new List<DocumentCategory>();
            return View(documentCategorys);
        }

        public ActionResult Details(int id)
        {
            return View(documentCategoryService.GetById(id));
        }

        public ActionResult Create()
        {
            DocumentCategory documentCategory = new DocumentCategory();
            documentCategory.CreatedDate = DateTime.Now;
            documentCategory.ModifiedDate = DateTime.Now;

            return View(documentCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocumentCategory documentCategory)
        {
            documentCategory.Id = int.MaxValue;
            ValidateModel<DocumentCategory>(documentCategory, new DocumentCategoryValidator());
            if (ModelState.IsValid)
            {
                documentCategoryService.Insert(documentCategory);
                return RedirectToAction("Index");
            }

            return View(documentCategory);
        }

        public ActionResult Edit(int id)
        {
            return View(documentCategoryService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DocumentCategory documentCategory)
        {
            try
            {
                ValidateModel<DocumentCategory>(documentCategory, new DocumentCategoryValidator());
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var oldDocumentCategory = documentCategoryService.GetById(id);
                if (oldDocumentCategory == null)
                {
                    return View();
                }

                documentCategoryService.Update(documentCategory);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(documentCategoryService.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, DocumentCategory documentCategory)
        {
            try
            {
                documentCategory = documentCategoryService.GetById(id);
                if (documentCategory == null)
                {
                    return View();
                }

                documentCategoryService.Delete(documentCategory);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListDropdown()
        {
            return View();
        }
    }
}

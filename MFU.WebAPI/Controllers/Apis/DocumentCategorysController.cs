using System;
using System.Collections.Generic;
using System.Web.Http;
using MFU.Models;
using MFU.Service;
using MFU.Models.ValidationRules;
using System.Web.Mvc;

namespace MFU.WebAPI.Controllers
{
    public class DocumentCategorysController : BaseApiController
    {
        private DocumentCategoryService documentCategoryService = new DocumentCategoryService();

        public DocumentCategorysController()
        {
        }

        // GET api/documentCategorys
        public IEnumerable<DocumentCategory> Get()
        {
            return documentCategoryService.GetAll();
        }

        // GET api/documentCategorys/5
        public DocumentCategory Get(int id)
        {
            return documentCategoryService.GetById(id);
        }

        public IHttpActionResult Put(int id, DocumentCategory documentCategory)
        {
            ValidateModel<DocumentCategory>(documentCategory, new DocumentCategoryValidator());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentCategory.Id)
            {
                return BadRequest();
            }

            documentCategoryService.Update(documentCategory);
            return Ok(documentCategory);
        }

        public IHttpActionResult Post(DocumentCategory documentCategory)
        {
            ValidateModel<DocumentCategory>(documentCategory, new DocumentCategoryValidator());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            documentCategoryService.Insert(documentCategory);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var documentCategory = documentCategoryService.GetById(id);
            if (documentCategory == null)
            {
                return NotFound();
            }

            documentCategoryService.Delete(documentCategory);

            return Ok(documentCategory);
        }
    }
}
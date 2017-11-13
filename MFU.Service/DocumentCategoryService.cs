using MFU.DataAccess.Repository;
using MFU.Models;
using System.Collections.Generic;

namespace MFU.Service
{
    public class DocumentCategoryService
    {
        private DocumentCategoryRepository documentCategoryRepository = new DocumentCategoryRepository();
        public DocumentCategoryService()
        {
        }

        public IEnumerable<DocumentCategory> GetAll()
        {
            //documentCategoryRepository.GetAllWithSqlScript();
            //documentCategoryRepository.GetAll();
            //documentCategoryRepository.GetAllWithSqlScriptByLoadDetail();
            //documentCategoryRepository.InsertAndRollback();
            return documentCategoryRepository.GetAllWithSqlScriptByLoadDetail();
        }

        public IEnumerable<DocumentCategory> GetAllWithPaged(int page = 1)
        {
            return documentCategoryRepository.GetAllWithPaged(page);
        }

        public DocumentCategory GetById(int id)
        {
            //documentCategoryRepository.GetWithSqlScriptById(id);
            return documentCategoryRepository.GetById(id);
        }

        public DocumentCategory Insert(DocumentCategory documentCategory)
        {
            try
            {
                documentCategory = documentCategoryRepository.Add(documentCategory);
            }
            catch (System.Exception)
            {
                throw;
            }
            return documentCategory;
        }

        public bool Update(DocumentCategory documentCategory)
        {
            bool result;
            try
            {
                documentCategoryRepository.Update(documentCategory);
                result = true;
            }
            catch (System.Exception)
            {
                result = false;
                throw;
            }
            return result;
        }

        public bool Delete(DocumentCategory documentCategory)
        {
            bool result;
            try
            {
                documentCategoryRepository.Delete(documentCategory);
                result = true;
            }
            catch (System.Exception)
            {
                result = false;
                throw;
            }
            return result;
        }
    }
}
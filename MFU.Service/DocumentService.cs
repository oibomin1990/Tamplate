using MFU.DataAccess.Repository;
using MFU.Models;
using System.Collections.Generic;

namespace MFU.Service
{
    public class DocumentService
    {
        private DocumentRepository documentRepository = new DocumentRepository();
        public DocumentService()
        {
        }
        public IEnumerable<Document> GetAll()
        {
            return documentRepository.GetAll();
        }
        public Document GetById(int id)
        {
            return documentRepository.GetById(id);
        }
    }
}

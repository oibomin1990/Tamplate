using MFU.DataAccess;
using MFU.DataAccess.Repository;
using MFU.Models;
using System.Collections.Generic;

namespace MFU.Service
{
    public class RequestService
    {
        private RequestRepository requestRepository = new RequestRepository(DatabaseSource.Oracle);
        public RequestService()
        {
        }
        public IEnumerable<Request> GetAll()
        {
            return requestRepository.GetAllRequest();
        }
        public Request GetById(int id)
        {
            return requestRepository.GetRequestById(id);
        }

        public Request AddRequest()
        {
            return requestRepository.AddRequest();
        }

        public Request UpdateRequest(decimal id)
        {
            return requestRepository.UpdateRequest(id);
        }

        public void DeleteRequest(decimal id)
        {
            requestRepository.DeleteRequest(id);
        }
    }
}

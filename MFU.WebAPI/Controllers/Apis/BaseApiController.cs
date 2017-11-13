using FluentValidation;
using FluentValidation.Results;
using System.Web.Http;

namespace MFU.WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        [NonAction]
        public void ValidateModel<T>(T model, AbstractValidator<T> validator)
        {
            var result = validator.Validate(model);
            foreach (ValidationFailure failer in result.Errors)
            {
                ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
            }
        }
    }
}
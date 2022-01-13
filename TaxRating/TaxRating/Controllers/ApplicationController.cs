using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TaxRating.Controllers
{
    [ApiController]
    public abstract class ApplicationController : ControllerBase
    {
        private readonly INotificator _notificator;

        public ApplicationController(INotificator notificador)
        {
            _notificator = notificador;
        }

        protected bool ValidOperation()
        {
            return !_notificator.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            bool isValid = retrieveValueFromTypeObject(result);
            if (ValidOperation())
            {
                switch (returnStatusCode())
                {
                    case "GET":
                        return isValid ? returnOk(result) : returnNotFound(result);

                    case "POST":
                        return returnCreated(result);

                    case "PUT":
                        return isValid ? returnNoContent() : returnNotFound(result);

                    case "DELETE":
                        return isValid ? returnNoContent() : returnNotFound(result);
                }
            }

            return returnBadRequest(result);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyErrorWhenModelIsInvalid(modelState);
            return CustomResponse();
        }

        protected void NotifyErrorWhenModelIsInvalid(ModelStateDictionary modelState)
        {
            foreach (var item in modelState)
            {
                var key = item.Key;
                var errors = item.Value.Errors;

                foreach (var err in errors)
                {
                    HasErrors(err.Exception == null ? err.ErrorMessage : err.Exception.Message, key);
                }

            }
        }

        protected void HasErrors(string message, string fieldName)
        {
            _notificator.Handle(new Notification(message, fieldName));
        }

        private string returnStatusCode()
        {
            return HttpContext.Request.Method;
        }

        /// <summary>
        /// GET 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private OkObjectResult returnOk(object result)
        {
            return Ok(result);
        }


        /// <summary>
        ///  POST
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private CreatedResult returnCreated(object result)
        {
            return Created("", result);

        }


        /// <summary>
        /// PUT / DELETE
        /// </summary>
        /// <returns></returns>
        private NoContentResult returnNoContent()
        {
            return NoContent();
        }

        /// <summary>
        /// GET 
        /// </summary>
        /// <returns></returns>
        private NotFoundObjectResult returnNotFound(Object result)
        {
            return NotFound(new ApiResponse<object>
            {
                Data = null,
                Succeeded = retrieveValueFromTypeObject(result),
                Message = retrieveMessageFromTypeObject(result),
                Notifications = _notificator.GetNotifications(),
            });
        }

        /// <summary>
        /// POST / PUT
        /// </summary>
        /// <returns></returns>
        private BadRequestObjectResult returnBadRequest(object result)
        {
            return BadRequest(new ApiResponse<object>
            {
                Data = null,
                Succeeded = retrieveValueFromTypeObject(result),
                Message = retrieveMessageFromTypeObject(result),
                Notifications = _notificator.GetNotifications(),
            });
        }

        /// <summary>
        /// Return value from property using reflection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool retrieveValueFromTypeObject(object value)
        {
            var property = "Succeeded";
            var propertyInfo = value.GetType().GetProperty(property);
            var result = propertyInfo.GetValue(value, null);

            return (bool)result;
        }

        /// <summary>
        /// Return value from property using reflection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string retrieveMessageFromTypeObject(object value)
        {
            var property = "Message";
            var propertyInfo = value.GetType().GetProperty(property);
            var result = propertyInfo.GetValue(value, null);

            return (string)result;
        }

    }
}

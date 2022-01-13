using Domain.Helpers;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Services
{
    public abstract class NotificationService
    {
        private readonly INotificator _notificator;

        protected NotificationService(INotificator notificador)
        {
            _notificator = notificador;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage, error.PropertyName);
            }
        }

        protected void Notify(string message, string fieldName)
        {
            _notificator.Handle(new Notification(message, fieldName));
        }

        protected bool ExecuteValidation<TV, TE>(TV tValidate, TE tEntity) where TV : AbstractValidator<TE>
        {
            var validator = tValidate.Validate(tEntity);
            if (validator.IsValid) return true;
            Notify(validator);
            return false;
        }
    }
}

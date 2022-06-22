using System;
using System.Collections.Generic;
using System.Linq;

namespace RentRide.Foundation.Services
{
    public sealed class RegistrationResult
    {
        private readonly ICollection<string> _errorMessages;

        public ICollection<string> ErrorMessages
        {
            get
            {
                if(!IsSuccessfull)
                {
                    return _errorMessages;
                }

                throw new InvalidOperationException("Successfull");
            }
        }
        public bool IsSuccessfull { get; }

        public RegistrationResult(ICollection<string> errorMessages, bool isSuccessfull)
        {
            _errorMessages = errorMessages;
            IsSuccessfull = isSuccessfull;
        }

        public static RegistrationResult RegistrationSuccessful()
        {
            return new RegistrationResult(null, true);
        }

        public static RegistrationResult RegistrationFailed(ICollection<string> errorMessages)
        {
            if (errorMessages == null || !errorMessages.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(errorMessages), "No error messages");
            }

            return new RegistrationResult(errorMessages, false);
        }
    }
}
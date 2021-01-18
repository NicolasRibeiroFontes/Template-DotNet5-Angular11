using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Template.CrossCutting.ExceptionHandler.Extensions;

namespace Template.Application.Services
{
    public static class ValidationService
    {
        public static void ValidEmail(string email)
        {
            if (!email.Contains("@") || !email.Contains("."))
                throw new ApiException("The e-mail is invalid", HttpStatusCode.BadRequest);
        }

        public static void ValidPassword(string password, string confirm)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm))
                throw new ApiException("Password and Confirm Password are required fields", HttpStatusCode.BadRequest);

            if (password.Length < 8)
                throw new ApiException("Password must contains more than 8 characters.", HttpStatusCode.BadRequest);

            if (!password.Equals(confirm))
                throw new ApiException("Password doesn't match", HttpStatusCode.BadRequest);

            if (password.Where(p => char.IsLetter(p)).Count() == 0)
                throw new ApiException("Password must contains 1 letter at least.", HttpStatusCode.BadRequest);

            if (password.Where(p => char.IsDigit(p)).Count() == 0)
                throw new ApiException("Password must contains 1 number at least.", HttpStatusCode.BadRequest);

            if (!Regex.IsMatch(password, (@"[^a-zA-Z0-9]")))
                throw new ApiException("Password must contains 1 special character at least.", HttpStatusCode.BadRequest);

        }

        public static void ValidIdNoRequired(int id)
        {
            if (id != 0)
                throw new ApiException("Post method doesn't accept field ID", HttpStatusCode.BadRequest);
        }

        public static void ValidIdRequired(int id)
        {
            if (id == 0)
                throw new ApiException("Put method must have ID field", HttpStatusCode.BadRequest);
        }
    }
}

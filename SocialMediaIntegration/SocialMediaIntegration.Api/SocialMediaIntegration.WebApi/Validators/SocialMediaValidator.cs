using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMediaIntegration.WebApi.Validators
{
    public static class SocialMediaValidator
    {
        public static void TagValidator(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentException("Invalid Tag");
            }
        }
    }
}
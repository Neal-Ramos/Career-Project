using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.commons.DTOs
{
    public class VerifyOtpDto
    {
        public string AccessToken {get; set;} = null!;
        public string RefreshToken {get; set;} = null!;
    }
}
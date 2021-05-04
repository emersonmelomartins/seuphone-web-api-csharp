using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seuphone.Api.Models;

namespace Seuphone.Api.IServices
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
    }
}

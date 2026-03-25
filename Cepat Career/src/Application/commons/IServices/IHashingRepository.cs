using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.commons.IServices
{
    public interface IHashingRepository
    {
        Task<string> HashString(string str);
    }
}
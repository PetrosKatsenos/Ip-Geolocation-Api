using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraries.Interfaces
{
    public interface IHttpHelper
    {
        Task<T> GetAsync<T>(string url) where T : class;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraries
{
    public static class IPValidation
    {
        public static bool IsIP(this string ip)
        {
            return IPAddress.TryParse(ip, out var result);
        }
    }
}

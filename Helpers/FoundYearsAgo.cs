using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandWebApi.Helpers
{
    public static class FoundYearsAgo
    {
        public static int GetYearsAgo(this DateTime dateTime)
        {
            var CurrentDate = DateTime.Now.Year;
            var YearsAgo = CurrentDate - dateTime.Year;
            return YearsAgo;   
        }
    }
}

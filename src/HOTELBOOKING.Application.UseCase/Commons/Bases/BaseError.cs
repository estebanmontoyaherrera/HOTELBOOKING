using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.Commons.Bases
{
    public class BaseError
    {
        public string? PropertyName { get; set; }
        public string? ErrorMessage { get; set; }

    }
}

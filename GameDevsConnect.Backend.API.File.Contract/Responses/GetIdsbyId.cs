using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevsConnect.Backend.API.File.Contract.Responses
{
    public class GetIdsbyId(string message, bool status, string[] ids)
    {
        public string Message { get; set; } = message;
        public bool Status { get; set; } = status;
        public string[] Ids { get; set; } = ids;
    }
}

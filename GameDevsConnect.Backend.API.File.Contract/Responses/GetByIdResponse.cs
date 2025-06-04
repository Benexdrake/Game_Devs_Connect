using GameDevsConnect.Backend.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevsConnect.Backend.API.File.Contract.Responses
{
    public class GetByIdResponse(string message, bool status, FileModel file)
    {
        public string Message { get; set; } = message;
        public bool Status { get; set; } = status;
        public FileModel File { get; set; } = file;
    }
}

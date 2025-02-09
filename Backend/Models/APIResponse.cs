﻿namespace Backend.Models
{
    public class APIResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; }
        public object Data { get; set; }

        public APIResponse(string message, bool status)
        {
            Message = message;
            Status = status;
        }

        public APIResponse(string message, bool status, object data)
        {
            Message = message;
            Status = status;
            Data = data;
        }
    }
}

using System;
using System.Collections.Generic;
using BasketAppApi.Domain.Entities;

namespace BasketAppApi.Application.Common.Models
{
    public class ResponseObject
    {
        public ReturnCode ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
    }

    public enum ReturnCode
    {
        Success = 1,
        Warning = 2,
        Error = 3
    }
}
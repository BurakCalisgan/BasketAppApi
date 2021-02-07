using System;

namespace BasketAppApi.Application.Common.Exceptions
{
    public class CustomException : Exception
    {
          public CustomException(String message)
         : base(message)
     { }
    }
}
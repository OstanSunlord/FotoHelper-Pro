﻿using System;
using System.Runtime.Serialization;

namespace FotoHelper_Pro
{
    [Serializable]
    internal class ValidateException : Exception
    {
        public ValidateException()
        {
        }

        public ValidateException(string message) : base(message)
        {
        }

        public ValidateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
﻿using System;
using System.Runtime.Serialization;

namespace HoursUpdatingTool
{
    [Serializable]
    internal class InvalidTimeException : Exception
    {
        public InvalidTimeException()
        {
        }

        public InvalidTimeException(string message) : base(message)
        {
        }

        public InvalidTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
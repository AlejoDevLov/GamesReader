using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesReader.Exceptions;

public class InvalidJsonFormatException : Exception
{
    public InvalidJsonFormatException()
    {
    }
    public InvalidJsonFormatException(string? message) : base(message)
    {
    }
    public InvalidJsonFormatException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

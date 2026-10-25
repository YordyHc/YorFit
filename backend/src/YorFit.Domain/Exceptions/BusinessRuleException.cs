using System;
using System.Collections.Generic;
using System.Text;

namespace YorFit.Domain.Exceptions;

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string mensaje) : base(mensaje)
    {
    }
}
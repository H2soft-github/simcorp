using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpShared.Exceptions
{
    public class DomainException : Exception
    {
        public virtual string Code { get; } = string.Empty;

        protected DomainException(string message)
            : base(message) { }
    }
}

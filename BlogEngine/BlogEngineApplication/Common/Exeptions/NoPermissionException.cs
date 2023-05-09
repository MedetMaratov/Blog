using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Common.Exeptions
{
    public class NotPermissionException : Exception
    {
        public NotPermissionException(string message) : base(message) { }
    }
}

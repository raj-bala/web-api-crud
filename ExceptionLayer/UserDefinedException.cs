using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLayer
{
    public class UserDefinedException
    {
        
        public class GetListException : Exception
        {
            public GetListException()
            {
            }

            public GetListException(string message) : base(message)
            {
            }

            public GetListException(string message, Exception innerException) : base(message, innerException)
            {
            }

            
        }
        public class DataException : Exception
        {
            public DataException()
            {
            }

            public DataException(string message) : base(message)
            {
            }

            public DataException(string message, Exception innerException) : base(message, innerException)
            {
            }

          
        }
    }
}

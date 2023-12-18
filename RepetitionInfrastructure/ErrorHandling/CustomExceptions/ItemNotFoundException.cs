using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepetitionInfrastructure.ErrorHandling.CustomExceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() { }
        public ItemNotFoundException(string nullItemName) : base($"\"{nullItemName}\" is not found") { }
    }
}

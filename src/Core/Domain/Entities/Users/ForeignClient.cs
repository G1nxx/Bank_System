using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class ForeignClient : Client
    {
        public string Policy { get; private set; }
        public string RegistrationId { get; private set; }
    }
}

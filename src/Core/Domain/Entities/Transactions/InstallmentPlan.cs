using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    internal interface IInstallmentPlan : ITransaction
    {
        public enum Duration
        {
            _1M,
            _3M,
            _6M,
            _12M,
            _18M,
            _24M,
            _36M
        }
    }
}

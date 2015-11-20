using DMS.SharedKernel.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.SharedKernel.Infrastructure.Data
{
    public interface IObjectWithState
    {
        State State { get; set; }
    }
}

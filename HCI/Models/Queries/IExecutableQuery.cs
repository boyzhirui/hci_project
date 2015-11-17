using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI.Models.Queries
{
    public interface IExecutableQuery
    {
        Func<Group, bool> GetLambda();
    }
}

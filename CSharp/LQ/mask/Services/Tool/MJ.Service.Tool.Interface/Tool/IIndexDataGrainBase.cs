using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Interface.Tool
{
    public interface IIndexDataGrainBase
    {
        [Transaction(TransactionOption.Suppress)]
        Task CommitState();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundredMSRest.Lib.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IRestRequest<T,R>
    {
        StringContent GetData(T t);
        Task<R> RequestAsync();
    }
}

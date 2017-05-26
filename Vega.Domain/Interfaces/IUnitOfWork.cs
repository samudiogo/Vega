using System;
using System.Threading.Tasks;

namespace Vega.Domain.Interfaces
{
    public interface IUnitOfWork//:IDisposable
    {
        Task CompleteAsync();
    }
}
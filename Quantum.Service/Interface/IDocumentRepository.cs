using Quantum.Service.Model;
using System;
using System.Threading.Tasks;

namespace Quantum.Service.Interface
{
    public interface IDocumentRepository
    {
        Task<Document> Get(Guid id);
    }
}

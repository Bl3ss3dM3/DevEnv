using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantum.Service.Interface;
using Quantum.Service.Model;

namespace Quantum.Service.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Document> Get(Guid id)
        {
            return await _context.Documents.Where(d => d.Id == id).FirstOrDefaultAsync();
        }
    }
}
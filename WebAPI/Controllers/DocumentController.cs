using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quantum.Service.Interface;
using Quantum.Service.ViewModel;
using WebAPI.Interface;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {

        private readonly IDocumentRepository _repository;
        private readonly IPdfService _pdfService;
        private readonly ILogger<DocumentController> _logger;

        public DocumentController(IDocumentRepository repository, IPdfService pdfService, ILogger<DocumentController> logger)
        {
            _repository = repository;
            _pdfService = pdfService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var document = await _repository.Get(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpPost("pdf")]
        public async Task<IActionResult> GetPDF([FromBody] RequestPDFVM model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var document = await _repository.Get(model.TemplateId);
            if (document == null)
            {
                return NotFound();
            }

            var htmlTemplate = _pdfService.GetTemplate(model, document.Content);
            byte[] pdf = _pdfService.ConvertToPdf(htmlTemplate);
            return File(pdf, "application/pdf");
        }
    }
}

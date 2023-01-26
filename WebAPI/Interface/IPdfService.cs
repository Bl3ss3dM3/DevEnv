
using Quantum.Service.ViewModel;

namespace WebAPI.Interface
{
    public interface IPdfService
    {
        string GetTemplate(RequestPDFVM model, string template);
        byte[] ConvertToPdf(string content);
    }
}
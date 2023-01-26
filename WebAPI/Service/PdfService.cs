using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Quantum.Service.ViewModel;
using WebAPI.Interface;

namespace WebAPI.Service
{
    public class PdfService : IPdfService
    {
        public string GetTemplate(RequestPDFVM model, string template)
        {
            var html = template;
            html = html.Replace("{{templateId}}", model.TemplateId.ToString());
            html = html.Replace("{{oneToOneData.dba}}", GetOneToOneData(model.OneToOneData, "dba"));
            html = html.Replace("{{oneToOneData.Address1}}", GetOneToOneData(model.OneToOneData, "Address1"));
            html = html.Replace("{{oneToOneData.Address2}}", GetOneToOneData(model.OneToOneData, "Address2"));
            html = html.Replace("{{oneToOneData.City, State Zip}}", GetOneToOneData(model.OneToOneData, "City, State Zip"));
            html = html.Replace("{{oneToOneData.ContactEmail}}", GetOneToOneData(model.OneToOneData, "ContactEmail"));
            html = html.Replace("{{oneToOneData.MID}}", GetOneToOneData(model.OneToOneData, "MID"));
            html = html.Replace("{{oneToOneData.StatementDate}}", GetOneToOneData(model.OneToOneData, "StatementDate"));
            html = html.Replace("{{oneToOneData.StartDate}}", GetOneToOneData(model.OneToOneData, "StartDate"));
            html = html.Replace("{{oneToOneData.EndDate}}", GetOneToOneData(model.OneToOneData, "EndDate"));
            html = html.Replace("{{oneToOneData.OutstandingScore}}", GetOneToOneData(model.OneToOneData, "OutstandingScore"));
            html = html.Replace("{{oneToOneData.Extra}}", GetOneToOneData(model.OneToOneData, "Extra"));

            // foreach (var table in model.TableData)
            // {
            //     var headers = string.Join("", table.headers.Select(header => $"<th>{header}</th>"));
            //     var rows = string.Join("", table.data.Select(row => $"<tr><td>{row.Date}</td><td>{row.Description}</td><td>{row.ExtraField1}</td><td>{row.ExtraField2}</td><td>{row.ExtraField3}</td></tr>"));
            //     tables.Append($"<h2>{table.name}</h2><table><tr>{headers}</tr>{rows}</table>");
            // }
            // html = html.Replace("{% for table in tableData %}{% endfor %}", tables.ToString());

            return html;
        }

        public byte[] ConvertToPdf(string content)
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document();
                PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                document.Add(new Paragraph(content));
                document.Close();
                return memoryStream.ToArray();
            }
        }

        private string GetOneToOneData(List<Dictionary<string, string>> model, string key)
        {
            var data = model.Where(d => d.ContainsKey("dba1")).Select(d => d["dba1"]).FirstOrDefault();
            return string.IsNullOrEmpty(data) ? "" : data;
        }
    }
}
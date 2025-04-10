using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Controllers
{
    public class FacturaController
    {

        public bool generarPdf(Model.Factura f)
        {
            QuestPDF.Settings.License = LicenseType.Enterprise;
            QuestPDF.Fluent.Document.Create(document =>
            {
                document.Page(page =>
                {
                    //TODO: basarme en los ejemplos de fact
                    page.Size(PageSizes.A4);
                    page.Header().Text("adasd");
                    page.Content().Text("a");
                    page.Footer().Text("A");
                }
                );
            }
            ).GeneratePdf("Cosa.pdf");
            return true;
        }
    }
}

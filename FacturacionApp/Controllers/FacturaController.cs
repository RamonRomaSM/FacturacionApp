using FacturacionApp.Model;
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

        public bool generarPdf(Model.Factura f, string rutaArchivo)
        {
          
            QuestPDF.Settings.License = LicenseType.Community;
            var documento = new DocumentoFactura(f);
            documento.GeneratePdf(rutaArchivo);
            return true;
        }
    }
    // Clase interna que implementa IDocument para generar el PDF
    class DocumentoFactura : IDocument
    {
        private Factura Factura { get; }

        public DocumentoFactura(Factura factura)
        {
            Factura = factura;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().Element(ComposeFooter);
                });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                // Datos del emisor de la factura
                row.RelativeItem().Column(column =>
                {
                    column
                        .Item().Text("FACTURA")
                        .FontSize(20)
                        .Bold()
                        .FontColor(Colors.Blue.Medium);

                    column.Item().Text("EMISOR:").Bold().FontSize(12);

                    column.Item().Text(Factura.nombreFacturante)
                        .Bold()
                        .FontSize(14);

                    column.Item().Text(text =>
                    {
                        text.Span("CIF: ").Bold();
                        text.Span(Factura.cifFacturante);
                    });

                    column.Item().Text(Factura.domicilioFacturante);
                });

                // Fecha y número de factura
                row.RelativeItem().Column(column =>
                {
                    column.Item().AlignRight().Text($"Fecha: {DateTime.Now:dd/MM/yyyy}")
                        .Bold();

                    column.Item().AlignRight().Text($"Nº Factura: {Factura.numeroFactura}");
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(20).Column(column =>
            {
                // Datos del cliente
                column.Item().PaddingBottom(10).Column(clienteColumn =>
                {
                    clienteColumn.Item().Text("CLIENTE:").Bold().FontSize(12);
                    clienteColumn.Item().Text(Factura.nombreFacturado).Bold();
                    clienteColumn.Item().Text($"CIF: {Factura.cifFacturado}");
                    clienteColumn.Item().Text(Factura.domicilioFacturado);
                });

                // Tabla de conceptos e importes
                column.Item().Table(table =>
                {
                    // Definir columnas
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3); // Concepto
                        columns.RelativeColumn();  // Importe
                    });

                    // Cabecera de la tabla
                    table.Header(header =>
                    {
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Concepto").Bold();
                        header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Importe").Bold().AlignRight();
                    });

                    // Contenido de la tabla
                    foreach (var linea in Factura.lineas)
                    {
                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(linea.concepto);
                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{linea.importeNeto:N2} €").AlignRight();
                    }
                });

                // Totales
                column.Item().AlignRight().PaddingTop(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    // Calcular subtotal
                    double subtotal = Factura.lineas.Sum(l => l.importeBruto);

                    // Calcular IVA (21%)
                    double iva = subtotal * 0.21;

                    // Calcular total
                    double total = subtotal + iva;

                    table.Cell().Padding(5).Text("Subtotal:").Bold().AlignRight();
                    table.Cell().Padding(5).Text($"{subtotal:N2} €").AlignRight();

                    table.Cell().Padding(5).Text("IVA (21%):").Bold().AlignRight();
                    table.Cell().Padding(5).Text($"{iva:N2} €").AlignRight();

                    table.Cell().BorderTop(1).Padding(5).Text("TOTAL:").Bold().FontSize(12).AlignRight();
                    table.Cell().BorderTop(1).Padding(5).Text($"{total:N2} €").Bold().FontSize(12).AlignRight();
                    table.Cell().Padding(5).Text($"Retención ({Factura.retencion}%):").Bold().AlignRight();
                    table.Cell().Padding(5).Text($"-{Factura.totalRetencion:N2} €").AlignRight();
                });
            });
        }

        void ComposeFooter(IContainer container)
        {
            container.AlignCenter().Text(text =>
            {
                text.Span("Página ").FontSize(10);
                text.CurrentPageNumber().FontSize(10);
                text.Span(" de ").FontSize(10);
                text.TotalPages().FontSize(10);
            });
        }
    }
}

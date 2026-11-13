using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection.Metadata;
using Viajecitos_WebCliente.Models;

namespace Viajecitos_WebCliente.Servicios
{
    public class FacturaPdfService
    {
        public static byte[] GenerarPdf(FacturaViewModel factura)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            var document = QuestPDF.Fluent.Document.Create(container =>

            {
                container.Page(page =>
                {
                    page.Margin(40);
                    page.Size(PageSizes.A4);

                    page.Header()
                        .Text($"Factura N° {factura.IdFactura}")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                    page.Content().Column(col =>
                    {
                        col.Spacing(10);

                        col.Item().Text($"Fecha: {factura.FechaFactura:yyyy-MM-dd HH:mm}");
                        col.Item().Text($"Empleado: {factura.Empleado}");
                        col.Item().Text($"Usuario: {factura.NombreUsuario} {factura.ApellidoUsuario} - Teléfono: {factura.TelefonoUsuario}");
                        col.Item().Text($"Instrucción de pago: {factura.MetodoPago}");
                        col.Item().Text($"Descripción: {factura.Descripcion}");

                        col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"Cantidad de boletos: {factura.CantidadBoletos}");
                            row.RelativeItem().Text($"Tarifa unitaria: {factura.TarifaUnitario:C}");
                        });

                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"Subtotal: {factura.TotalParcial:C}");
                            row.RelativeItem().Text($"Impuesto (15%): {factura.Impuesto:C}");
                            row.RelativeItem().Text($"Total: {factura.TotalFinal:C}").Bold().FontColor(Colors.Green.Darken2);
                        });
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text("Gracias por su compra en Viajecitos SA").FontSize(12).FontColor(Colors.Grey.Darken2);
                });
            });

            return document.GeneratePdf();
        }
    }
}

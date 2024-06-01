using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using rowingmaterialweb.Frontend.Repositories;

namespace rowingmaterialweb.Frontend.Pages
{
    public partial class Home
    {
        [Inject] private IJSRuntime JS { get; set; } = null!;

        private async Task CrearPdf()
        {
            
            await JS.InvokeVoidAsync("GenerarPDF",
                "prueba.pdf",
                "Luis Núñez",
                "Gonzalo Prieto",
                "17157729",
                "Espora 2052 - Lat:-31.123456 - Long:-64.345645",
                "2024-06-01 12:54:22"
                

    // Equipo.Latitud,
    // Equipo.Longitud
    );
        }

        private static void CrearPdf2()
        {
            // Must have write permissions to the path folder
            PdfWriter writer = new PdfWriter("D:\\pdf\\demo.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Add Header
            Paragraph header = new Paragraph("HEADER")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);
            document.Add(header);

            // Add SubHeader
            Paragraph subheader = new Paragraph("SUB HEADER")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(15);
            document.Add(subheader);

            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            // Add image
            //Image img = new Image(ImageDataFactory
            //   .Create(@"C:\Luis.jpg"))
            //   .SetTextAlignment(TextAlignment.CENTER);
            //document.Add(img);

            // Table
            Table table = new Table(2, false);
            Cell cell11 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("State"));
            Cell cell12 = new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Capital"));

            Cell cell21 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("New York"));
            Cell cell22 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Albany"));

            Cell cell31 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("New Jersey"));
            Cell cell32 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Trenton"));

            Cell cell41 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("California"));
            Cell cell42 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Sacramento"));

            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell21);
            table.AddCell(cell22);
            table.AddCell(cell31);
            table.AddCell(cell32);
            table.AddCell(cell41);
            table.AddCell(cell42);
            document.Add(table);

            // Page numbers
            int n = pdf.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String
                   .Format("page" + i + " of " + n)),
                    559, 806, i, TextAlignment.RIGHT,
                    VerticalAlignment.TOP, 0);
            }

            document.Close();
        }


    }
}
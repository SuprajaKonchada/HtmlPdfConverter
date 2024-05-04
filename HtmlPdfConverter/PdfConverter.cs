using DinkToPdf;
using DinkToPdf.Contracts;
using Razor.Templating.Core;

namespace HtmlPdfConverter;

public class PdfConverter : IPdfConverter
{
    private readonly IConverter _converter;

    public PdfConverter(IConverter converter)
    {
        _converter = converter;
    }

    public async Task<byte[]> ConvertHtmlToPdfAsync(string partialViewPath, object model)
    {
        // Render the partial view to HTML using Razor.Templating
        string htmlContent = await RazorTemplateEngine.RenderAsync(partialViewPath, model);

        // Create a new HtmlToPdfDocument and configure the global settings
        var document = new HtmlToPdfDocument
        {
            GlobalSettings = new GlobalSettings
            {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait
            }
        };

        // Create an ObjectSettings instance
        var objectSettings = new ObjectSettings
        {
            HtmlContent = htmlContent,
            WebSettings = new WebSettings
            {
                DefaultEncoding = "utf-8"
            },
            // Configure header settings
            HeaderSettings = new HeaderSettings
            {
                FontName = "Arial",
                FontSize = 9,
                Line = true,
                Center = "Cognine"
            },
            // Configure footer settings
            FooterSettings = new FooterSettings
            {
                FontName = "Arial",
                FontSize = 9,
                Line = true,
                Center = "Page [page] of [toPage]"
            }
        };

        // Add the object settings to the document
        document.Objects.Add(objectSettings);

        // Convert the HTML content to PDF using the IConverter instance
        byte[] pdfBytes = _converter.Convert(document);

        return pdfBytes;
    }
}


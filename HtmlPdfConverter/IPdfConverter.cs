using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlPdfConverter;

    /// <summary>
    /// Interface defining the contract for converting HTML content into PDF files.
    /// </summary>
    public interface IPdfConverter
    {
        /// <summary>
        /// Converts the specified partial view and model into a PDF.
        /// </summary>
        /// <param name="partialViewPath">The path to the partial view to be rendered.</param>
        /// <param name="model">The model to be passed to the view.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the PDF bytes.</returns>
        Task<byte[]> ConvertHtmlToPdfAsync(string partialViewPath, object model);
    }



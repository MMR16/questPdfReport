﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using QuestPDFTest;
using System.Net;

namespace QuestPdfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestPdfController : ControllerBase
    {

        [HttpGet]
        public IActionResult GenerateReport()
        {
            var document = new TransactionsReport();
            // Generate the PDF document in memory
            var pdfBytes = document.GeneratePdf();

            // Return the PDF as a file
            return File(pdfBytes, "application/pdf", $"Report_{Guid.NewGuid().ToString().Substring(6,6)}.pdf");
        }
    }
}

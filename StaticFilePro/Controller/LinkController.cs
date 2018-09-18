using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace StaticFilePro.Controller
{
    public class LinkController : ControllerBase
    {
        public IActionResult GetFile()
        {
            return DownloadFile("Test.xls");
        }
        private FileResult DownloadFile(string fileName)
        {
            IFileProvider provider = new PhysicalFileProvider(@"D:\Edward\Forums\Test");

            IFileInfo fileInfo = provider.GetFileInfo(fileName);
            var readStream = fileInfo.CreateReadStream();
            return File(readStream, "application/vnd.ms-excel");
        }
    }
}
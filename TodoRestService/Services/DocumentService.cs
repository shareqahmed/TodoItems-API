using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;
using TodoRestService.Models;
using TodoRestService.ViewModels;

namespace TodoRestService.Services
{
    public class DocumentService : IDocumentService
    {

        private IServiceProvider provider;
        private readonly TodoContext _context;
        private IWebHostEnvironment _webHostEnvioroment;
        public DocumentService(IServiceProvider DocumentServiceProvider, TodoContext Context, IWebHostEnvironment WebHostEnvioroment)
        {
            provider = DocumentServiceProvider;
            _context = Context;
            _webHostEnvioroment = WebHostEnvioroment;

        }



        public async Task<string> UploadImage([FromForm] ToDoItemBaseViewModel ViewItem)
        {

            try
            {

                if (ViewItem.ImageFile.Length > 0)

                {

                    if (string.IsNullOrWhiteSpace(_webHostEnvioroment.WebRootPath))
                    {
                        _webHostEnvioroment.WebRootPath = System.IO.Path.Combine(Directory.GetCurrentDirectory());
                        // _webHostEnvioroment.WebRootPath =  System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath());
                    }
                    string path = _webHostEnvioroment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (FileStream FileStream = System.IO.File.Create(path + ViewItem.ImageFile.FileName))
                    {
                        ViewItem.ImageFile.CopyTo(FileStream);

                        FileStream.Flush();

                        return "Uploaded";

                    }
                }

                else
                {
                    return "Not uploaded";

                }

            }
            catch (Exception ex)

            {
                return ex.Message;
            }

            // we can put rest of upload logic here.

        }



    }
}

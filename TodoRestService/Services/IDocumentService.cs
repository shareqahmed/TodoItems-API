using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoRestService.ViewModels;

namespace TodoRestService.Services
{
    public interface IDocumentService
    {
        Task<string> UploadImage([FromForm] ToDoItemBaseViewModel ViewItem);
    }
}
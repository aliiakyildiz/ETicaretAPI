using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Services
{
    public interface IFileService
    {
        Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files);///path: wwwroot' dan sonraki yolu belirtecek.
        Task<bool> CopyFileAsync(string path, IFormFile file);
    }
}

using System.Runtime.InteropServices;

namespace MoviesAPI.Helper
{
    public class FileStorageService : IFileStorageServie
    {
        private readonly IWebHostEnvironment environment;
        private readonly IHttpContextAccessor contextAccessor;

        public FileStorageService(IWebHostEnvironment environment, IHttpContextAccessor contextAccessor)
        {
            this.environment = environment;
            this.contextAccessor = contextAccessor;
        }
        public Task DeleteFile(string fileRoute, string containerName)
        {
            if (string.IsNullOrEmpty(fileRoute))
            {
                return Task.CompletedTask;
            }
            var fileName = Path.GetFileName(fileRoute);
            var directory = Path.Combine(environment.WebRootPath, containerName, fileName);

            if (File.Exists(directory))
            {
                File.Delete(directory);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditFile(string containerName, IFormFile file, string fileRoute)
        {
            await DeleteFile(containerName, fileRoute);
            return await SaveFile(containerName, file);
        }

        public async Task<string> SaveFile(string containerName, IFormFile file)
        {
            var extentsion = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extentsion}";

            string folder = Path.Combine(environment.WebRootPath, containerName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string route = Path.Combine(folder, fileName);

            using(var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var content = stream.ToArray();
                await File.WriteAllBytesAsync(route, content);
            }

            var url = $"{contextAccessor.HttpContext.Request.Scheme}://{contextAccessor.HttpContext.Request.Host}";
            var routeForDB = Path.Combine(url, containerName, fileName).Replace('\\', '/');
            return routeForDB;
            
        }
    }
}

namespace MoviesAPI.Helper
{
    public interface IFileStorageServie
    {
        Task DeleteFile(string fileRoute, string containerName);
        Task<string> SaveFile(string containerName, IFormFile file);
        Task<string> EditFile(string containerName, IFormFile file, string fileRoute);
    }
}

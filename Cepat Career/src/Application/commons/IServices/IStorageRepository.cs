namespace Application.commons.IServices
{
    public interface IStorageRepository
    {
        Task<UploadResponse> UploadAsync(
            string FileName,
            string Name,
            string ContentType,
            Stream Content
        );
    }
}
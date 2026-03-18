namespace Application.commons.IServices
{
    public interface IStorageRepository
    {
        Task<UploadAsyncDto> UploadAsync(
            string FileName,
            string Name,
            string ContentType,
            Stream Content
        );
    }
}
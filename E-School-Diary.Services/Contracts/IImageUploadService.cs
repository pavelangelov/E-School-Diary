using CloudinaryDotNet;

namespace E_School_Diary.Services.Contracts
{
    public interface IImageUploadService
    {
        Cloudinary GetUploader();
    }
}

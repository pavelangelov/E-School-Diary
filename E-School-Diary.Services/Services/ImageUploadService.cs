using CloudinaryDotNet;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;

namespace E_School_Diary.Services
{
    public class ImageUploadService : IImageUploadService
    {
        public Cloudinary GetUploader()
        {
            var account = new Account()
            {
                Cloud = CloudinaryConfigs.Cloud,
                ApiKey = CloudinaryConfigs.ApiKey,
                ApiSecret = CloudinaryConfigs.ApiSecret
            };

            var cloudinary = new Cloudinary(account);

            return cloudinary;
        }
    }
}

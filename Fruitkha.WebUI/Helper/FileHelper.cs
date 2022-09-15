namespace Fruitkha.WebUI.Helper
{
    public static class FileHelper
    {
        public static async Task<string> UploadImage(IFormFile ImageUrl, IWebHostEnvironment _env)
        {
            var filePath = "/uploads/" + Guid.NewGuid() + "_" + ImageUrl.FileName;

            using (var fileStream = new FileStream(_env.WebRootPath + filePath, FileMode.Create))
            {
                await ImageUrl.CopyToAsync(fileStream);
            }
                return filePath;
        }
    }
}

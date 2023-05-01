namespace MVC_Project.Helper
{
	public class ConvertImgToString
	{
		private IWebHostEnvironment webHostEnvironment;
		public ConvertImgToString(IWebHostEnvironment webHostEnvironment)
		{
			this.webHostEnvironment = webHostEnvironment;
		}
		public async Task<string> ConvertImg(IFormFile ImageUrl)
		{
			var uploadDir = @"image/Sneaker";
			var fileName = Path.GetFileNameWithoutExtension(ImageUrl.FileName);
			var extension = Path.GetExtension(ImageUrl.FileName);
			var webRootPath = webHostEnvironment.WebRootPath;
			fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
			var path = Path.Combine(webRootPath, uploadDir, fileName);
			await ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
			return fileName;
		}

		public void DeleteImg(string ImageUrl)
		{
            var uploadDir = @"image/Sneaker";
            string imagePath = Path.Combine(webHostEnvironment.WebRootPath,uploadDir, ImageUrl);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }
	}
}

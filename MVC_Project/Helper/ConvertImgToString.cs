using Microsoft.AspNetCore.Hosting;

namespace MVC_Project.Helper
{
	public class ConvertImgToString
	{
		private IWebHostEnvironment webHostEnvironment;
		public ConvertImgToString(IWebHostEnvironment webHostEnvironment)
		{
			this.webHostEnvironment = webHostEnvironment;
		}
		public async Task<string> ConvertImg(IFormFile ImageUrl,string folder)
		{
			var uploadDir = @"image/"+folder;
			var fileName = Path.GetFileNameWithoutExtension(ImageUrl.FileName);
			var extension = Path.GetExtension(ImageUrl.FileName);
			var webRootPath = webHostEnvironment.WebRootPath;
			fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
			var path = Path.Combine(webRootPath, uploadDir, fileName);
			await ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
			return fileName;
		}

		public bool DeleteImg(string ImageUrl,string folder)
		{
            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "image", folder, ImageUrl);
				
            if (System.IO.File.Exists(filePath))
            {
				using (var stream = new FileStream(filePath, FileMode.Open))
				{
					stream.Close();
					System.IO.File.Delete(filePath);
					return true;
				}
			}

			return false;
        }
	}
}

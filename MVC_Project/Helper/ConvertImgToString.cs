namespace MVC_Project.Helper
{
	public class ConvertImgToString
	{
		private IWebHostEnvironment webHostEnvironment;
		public ConvertImgToString(IWebHostEnvironment webHostEnvironment)
		{
			this.webHostEnvironment = webHostEnvironment;
		}
		public async Task<string> ConvertImg(IFormFile ImageUrl) {
			var uploadDir = @"images/employees";
			var fileName = Path.GetFileNameWithoutExtension(ImageUrl.FileName);
			var extension = Path.GetExtension(ImageUrl.FileName);
			var webRootPath = webHostEnvironment.WebRootPath;
			fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
			var path = Path.Combine(webRootPath, uploadDir, fileName);
			await ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
			return "/" + uploadDir + "/" + fileName;
		}
	}
}

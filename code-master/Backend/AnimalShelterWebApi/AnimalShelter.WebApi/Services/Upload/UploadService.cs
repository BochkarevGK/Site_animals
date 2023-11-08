namespace AnimalShelter.WebApi.Services.Upload;

public class UploadService : IUploadService
{
	public async Task<string> SaveFileAsync(string base64, string id, string folderPath)
	{
		var data = base64.Split(',');
		if (data.Length != 2)
		{
			throw new Exception("Invalid base64 format");
		}

		var extension = data[0].Split(';')[0].Split('/')[1];
		var imageBytes = Convert.FromBase64String(data[1]);
		
		var fileName = $"{id}.{extension}";

		var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath);
		CreateDirectory(directory);

		var uploadPath = Path.Combine(directory, fileName);
		await File.WriteAllBytesAsync(uploadPath, imageBytes);

		var filePath = Path.Combine(folderPath, fileName);
		return filePath;
	}

	private static void CreateDirectory(string directory)
	{
		if (Directory.Exists(directory) == false)
		{
			Directory.CreateDirectory(directory);
		}
	}
}
namespace AnimalShelter.WebApi.Services.Upload;

public interface IUploadService
{
	Task<string> SaveFileAsync(string base64, string id, string folderPath);
}
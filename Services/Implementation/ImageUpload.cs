using Services.Interface;

namespace Services.Implementation;
public class ImageUpload : IFileUpload
{
    public string FilePath()
    {
        var currentDir = Directory.GetCurrentDirectory();
        var parentDir = Directory.GetParent(currentDir).ToString();                      
        var wwwroot = parentDir + "\\client\\wwwroot\\images\\hamsters";
        return wwwroot;
    }
    public async Task Upload(byte[] file, string fileName)
    {
        Stream stream = new MemoryStream(file);
        var path = Path.Combine(FilePath(), fileName);
        FileStream fileStream = new FileStream(path, FileMode.CreateNew);
        stream.CopyTo(fileStream);
        fileStream.Close();
        stream.Close();
    }
}

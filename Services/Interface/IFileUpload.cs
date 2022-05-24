namespace Services.Interface;
public interface IFileUpload
{
    /// <summary>
    /// Upload file
    /// </summary>
    /// <param name="file">File to be uploaded</param>
    /// <param name="fileName">File name</param>
    /// <returns></returns>
    Task Upload(byte[] file, string fileName);

    /// <summary>
    /// The path to the file to be uploaded
    /// </summary>
    /// <returns></returns>
    string FilePath();
}

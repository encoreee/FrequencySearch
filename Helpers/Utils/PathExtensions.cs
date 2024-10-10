namespace Helpers.Utils;

public static class PathExtensions
{
    public static bool ValidateFilePath(this string path, bool validateRoot = false, bool validateDirectory = false, bool validateExtension = false)
    {
        if (string.IsNullOrEmpty(path))
        {
            return false;
        }

        string? root;
        string? directory;
        string? filename;
        try
        {
            root = Path.GetPathRoot(path);
            directory = Path.GetDirectoryName(path);
            filename = Path.GetFileName(path);
        }
        catch (ArgumentException)
        {
            return false;
        }

        if (validateRoot && string.IsNullOrEmpty(root))
        {
            return false;
        }

        if (validateDirectory && string.IsNullOrEmpty(directory))
        {
            return false;
        }

        if (validateExtension && string.IsNullOrEmpty(Path.GetExtension(filename)))
        {
            return false;
        }

        if (string.IsNullOrEmpty(filename))
        {
            return false;
        }

        if (filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
        {
            return false;
        }

        return true;
    }
}

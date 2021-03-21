
using System.IO;
using DotNetNuke.Services.FileSystem;

namespace TH.NUCE.Web
{
    public static class FileProvider
    {
        public static IFileInfo Upload(int PortalID, string FolderPath, string fileName, Stream ms)
        {
            IFolderInfo obj=new FolderInfo();
            obj =FolderManager.Instance.GetFolder(PortalID,FolderPath);
            return FileManager.Instance.AddFile(obj, fileName, ms, false);
        }
    }
}
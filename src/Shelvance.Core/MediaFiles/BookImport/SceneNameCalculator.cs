using System.IO;
using Shelvance.Common.Extensions;
using Shelvance.Core.Parser;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.MediaFiles.BookImport
{
    public static class SceneNameCalculator
    {
        public static string GetSceneName(LocalBook localEpisode)
        {
            var downloadClientInfo = localEpisode.DownloadClientBookInfo;

            if (downloadClientInfo != null && !downloadClientInfo.Discography)
            {
                return Parser.Parser.RemoveFileExtension(downloadClientInfo.ReleaseTitle);
            }

            var fileName = Path.GetFileNameWithoutExtension(localEpisode.Path.CleanFilePath());

            if (SceneChecker.IsSceneTitle(fileName))
            {
                return fileName;
            }

            var folderTitle = localEpisode.FolderTrackInfo?.ReleaseTitle;

            if (localEpisode.FolderTrackInfo?.Discography == false &&
                folderTitle.IsNotNullOrWhiteSpace() &&
                SceneChecker.IsSceneTitle(folderTitle))
            {
                return folderTitle;
            }

            return null;
        }
    }
}

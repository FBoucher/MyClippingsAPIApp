using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyClippingsAPIApp.Helpers
{
    public static class StorageHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContainerName"></param>
        /// <param name="Filename"></param>
        /// <returns></returns>
        public static Stream GetStreamFromStorage(string ContainerName, string Filename)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(ContainerName);
            var blockBlob = container.GetBlockBlobReference(Filename);

            using (var memoryStream = new MemoryStream())
            {

                blockBlob.DownloadToStream(memoryStream);
                byte[] byteArray = memoryStream.ToArray();

                MemoryStream stream = new MemoryStream(byteArray);
                return stream;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContainerName"></param>
        /// <param name="FileContent"></param>
        /// <returns></returns>
        public static string SaveResultToStorage(string ContainerName, string FileContent)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(ContainerName);

            var filename = "myclippings_" + DateTime.Now.ToString("yyyy-MM-dd") + ".json";
            var blockBlob = container.GetBlockBlobReference(filename);
            blockBlob.UploadText(FileContent);

            return filename;
        }
    }
}
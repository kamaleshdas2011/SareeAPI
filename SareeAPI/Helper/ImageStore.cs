using DataModel;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SareeAPI.Helper
{
    public class ImageStore
    {
        StorageClient storageClient;
        string bucketName;
        public ImageStore()
        {
            //GoogleCredential credential = GoogleCredential.GetApplicationDefaultAsync();
            string projectId = "My First Project";
            storageClient = StorageClient.Create();
            bucketName = projectId + "kd-prodimages";

        }
        public void GetImages()
        {
            var imgs = storageClient.GetBucket(bucketName);
        }
    }
}
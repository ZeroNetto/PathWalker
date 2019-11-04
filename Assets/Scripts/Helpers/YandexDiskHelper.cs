using System;
using System.Net;
using UnityEngine;

namespace Systems
{
    public class YandexDiskHelper
    {
        public static void SaveFile(string fileUri, string fileName = "path.txt")
        {
            var filePath = fileName;
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(new Uri($"https://getfile.dokpub.com/yandex/get/{fileUri}"), filePath);
                }
                catch (WebException e)
                {
                    throw new WebException("Something gone wrong at download file stage.", e);
                }
            }
        }
    }
}

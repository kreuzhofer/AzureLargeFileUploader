using System;
using System.IO;

namespace AzureLargeFileUploader
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 4)
            {
                Help();
                return -1;
            }

            var fileToUpload = args[0];
            if (!File.Exists(fileToUpload))
            {
                Console.WriteLine("File does not exist: "+fileToUpload);
                Help();
            }
            var containerName = args[1];
            var storageAccountName = args[2];
            var storageAccountKey = args[3];

            var connectionString = $"DefaultEndpointsProtocol=https;AccountName={storageAccountName};AccountKey={storageAccountKey}";

            LargeFileUploaderUtils.Log = Console.WriteLine;
            LargeFileUploaderUtils.UploadAsync(fileToUpload, connectionString, containerName, (sender, i) =>
            {
            });

            return 0;
        }

        private static void Help()
        {
            Console.WriteLine();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("Azure Large File Uploader, (C)2016 by Daniel Kreuzhofer (@dkreuzh), MIT License");
            Console.WriteLine("Source code is available at https://github.com/kreuzhofer/AzureLargeFileUploader");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("USAGE: AzureLargeFileUploader.exe <FileToUpload> <Container> <StorageAccountName> <StorageAccountKey>");
        }
    }
}
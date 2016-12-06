using System;
using System.IO;
using System.Threading.Tasks;

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

            Header();

            LargeFileUploaderUtils.Log = Console.WriteLine;
            var task = LargeFileUploaderUtils.UploadAsync(fileToUpload, connectionString, containerName, (sender, i) =>
            {
            });
            Task.WaitAll(task);

            return 0;
        }

        private static void Header()
        {
            Console.WriteLine("********************************************************************************************************************");
            Console.WriteLine("Azure Large File Uploader, (C)2016 by Daniel Kreuzhofer (@dkreuzh), Christian Geuer-Pollmann (@chgeuer), MIT License");
            Console.WriteLine("Source code is available at https://github.com/kreuzhofer/AzureLargeFileUploader");
            Console.WriteLine("********************************************************************************************************************");
        }

        private static void Help()
        {
            Console.WriteLine();
            Header();
            Console.WriteLine("USAGE: AzureLargeFileUploader.exe <FileToUpload> <Container> <StorageAccountName> <StorageAccountKey>");
        }
    }
}
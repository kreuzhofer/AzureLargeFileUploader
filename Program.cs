using System;
using System.IO;

namespace AzureLargeFileUploader
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 3)
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
            var connectionString = args[2];

            LargeFileUploaderUtils.UploadAsync(fileToUpload, connectionString, containerName, (sender, i) =>
            {
                Console.WriteLine(i);
            });

            Console.ReadLine();
            return 0;
        }

        private static void Help()
        {
            Console.WriteLine();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("Azure Large File Uploader, (C)2016 by Daniel Kreuzhofer (@dkreuzh), MIT License");
            Console.WriteLine("Source code is available at https://github.com/kreuzhofer/AzureLargeFileUploader");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("USAGE: AzureLargeFileUploader.exe <FileToUpload> <Container> <ConnectionString>");
        }
    }
}
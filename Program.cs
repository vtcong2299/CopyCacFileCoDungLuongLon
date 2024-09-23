using System;
using System.IO;

namespace CopyCacFileCoDungLuongLon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap dia chi duong dan file nguon: ");
            string? sourcePath = Console.ReadLine();
            Console.WriteLine("Nhap dia chi duong dan file dich: ");
            string? destinationPath = Console.ReadLine();

            FileInfo source = new FileInfo(sourcePath);
            FileInfo des = new FileInfo(destinationPath);
            try
            {
                CopyFileUsingFileInfo(source, des);
                Console.WriteLine("Sao chep thanh cong");
            }
            catch (IOException e)
            {
                Console.WriteLine("Khong the copy");
                Console.Error.WriteLine(e.Message);
            }
        }

        private static void CopyFileUsingFileInfo(FileInfo source, FileInfo des)
        {
            source.CopyTo(des.FullName, true);
        }

        private static void CopyFileUsingStream(FileInfo source, FileInfo des)
        {
            StreamReader? reader = null;
            StreamWriter? writer = null;
            try
            {
                reader = new StreamReader(source.FullName);
                writer = new StreamWriter(des.FullName);
                Char[] buffer = new Char[1024];
                int length;
                while((length = reader.Read(buffer)) > 0)
                {
                    writer.Write(buffer, 0, length);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                writer.Close();
                writer.Dispose();
            }
        }
    }
}
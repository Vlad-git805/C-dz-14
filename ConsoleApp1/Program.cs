using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            int chois;
            do
            {
                Console.Clear();
                DirectoryInfo dir = new DirectoryInfo(path);

                Console.WriteLine("Directory: \t{0}", dir.FullName);
                Console.WriteLine("CreationTime: {0}", dir.CreationTime);
                Console.WriteLine("Extension: {0}", dir.Extension);
                Console.WriteLine("LastAccessTime: {0}", dir.LastAccessTime);
                Console.WriteLine("LastWriteTime: {0}", dir.LastWriteTime);
                Console.WriteLine("Name: {0}", dir.Name);

                Console.WriteLine("Directories ----------------------");
                foreach (var d in dir.GetDirectories())
                {
                    Console.WriteLine($"Directory: {d.Name}  time:  {d.CreationTime} atr: {d.Attributes}");
                }
                Console.WriteLine("Files --------------------------");
                foreach (var file in dir.GetFiles())
                {
                    Console.WriteLine($"File: {file.Name}  time:  {file.CreationTime} atr: {file.Attributes}");
                }


                Console.WriteLine("1 - go to folder");
                Console.WriteLine("2 - create directory");
                Console.WriteLine("3 - delete directory");
                Console.WriteLine("4 - show file info");
                Console.WriteLine("6 - delete file");
                Console.WriteLine("7 - moving file");
                Console.WriteLine("5 - go back");
                Console.WriteLine("8 - exit");
                chois = int.Parse(Console.ReadLine());

                switch (chois)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter name of folder");
                            Console.Write("->");
                            string next = Console.ReadLine();
                            path = Path.Combine(path, next);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter name");
                            Console.Write("->");
                            string subpath = Console.ReadLine();
                            if (!dir.Exists)
                            {
                                dir.Create();
                            }
                            dir.CreateSubdirectory(subpath);
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter name");
                            Console.Write("->");
                            string dirName = Console.ReadLine();
                            path = Path.Combine(path, dirName);
                            try
                            {

                                dir.Delete(true);
                                Console.WriteLine("Directiry was deleted");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Enter name of directory");
                            Console.Write("->");
                            string next = Console.ReadLine();
                            foreach (var file in dir.GetFiles())
                            {
                                if (file.Name == next) { Console.WriteLine($"File: {file.Name}  time:  {file.CreationTime} atr: {file.Attributes}"); }
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 5:
                        {
                            if (dir.Exists)
                            {
                                dir.Delete();
                            }
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("Enter new Path");
                            Console.Write("->");
                            string newPath = Console.ReadLine();
                            if (dir.Exists)
                            {
                                dir.MoveTo(newPath);

                            }
                        }
                        break;
                    case 7:
                        {
                            string next = "..";
                            path = Path.Combine(path, next);
                        }
                        break;
                    case 8:
                        {
                            chois = 8;
                        }
                        break;
                }

            } while (chois != 8);


        }
    }
}

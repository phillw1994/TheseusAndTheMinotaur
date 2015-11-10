using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TheseusAndTheMinotaur
{
    class Filer
    {
        string AppFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        string DocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string Directory = "";
        public string levelString;
        public string levelName;
        public string levelDescription;
        public string author;
        public string fileName;
        public bool fileOpened;

        public Filer(string directory)
        {
            this.Directory = directory + "\\";
            bool exists = System.IO.Directory.Exists(AppFolder + Directory);

            if (!exists)
                System.IO.Directory.CreateDirectory(AppFolder + Directory);
        }

        public void OpenFile()
        {
            
        }

        public bool isFileOpen()
        {
            return this.fileOpened;
        }

        public string[] getFileData()
        {
            string[] fileData = { this.levelName, this.levelDescription, this.author, this.levelString };
            return fileData;
        }

        public void closeFile()
        {
            this.levelString = "";
            this.levelName = "";
            this.levelDescription = "";
            this.author = "";
            this.fileName = "";
            this.fileOpened = false;
        }


    public string CreateFile(string fileName)
        {
            File.WriteAllText(AppFolder + Directory + fileName, string.Empty);
            return AppFolder + Directory + fileName;
        }

        public void AppendFile(string fileName, string text)
        {
            File.AppendAllText(AppFolder + Directory + fileName, text);
        }

        public void WriteToFile(string fileName, string[] text)
        {
            File.WriteAllLines(AppFolder + Directory + fileName, text);
        }

        public void DeleteFile(string fileName)
        {
            File.Delete(AppFolder + Directory + fileName);
        }
    }
}

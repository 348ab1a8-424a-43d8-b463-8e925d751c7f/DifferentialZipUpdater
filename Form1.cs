using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifferentialZipUpdater
{
    public partial class Form1: Form
    {
        string targetFilePath = "";
        string targetFolderPath = "";

        // Possibly can just leave static if location doesn't change.
        string preVersionZipFilePath = @"D:\\TestEnv\\PreviousVersion\PreviousVersion.zip";

        public Form1()
        {
            InitializeComponent(); // Initialized UI Component
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Updater.ZipPreviousVersion(targetFolderPath);
        }

        private void revertButton_Click(object sender, EventArgs e)
        {
            Updater.revertVersion(preVersionZipFilePath, targetFolderPath);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Hard Code Path for testing
            Updater.CompareFolderToZipContents(targetFolderPath, @"D:\TestEnv\Archive\Files.Zip");
        }

        private void forceUpdateButton_Click(object sender, EventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFolderDialog = new OpenFileDialog();
            browseFolderDialog.InitialDirectory = "c:\\";
            browseFolderDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; // TO DO: Change filetype to only .EXE
            browseFolderDialog.FilterIndex = 2;
            browseFolderDialog.RestoreDirectory = true;

            if (browseFolderDialog.ShowDialog() == DialogResult.OK)
            {
                // Get target file
                targetFilePath = browseFolderDialog.FileName; // Get the path of the specified file
                folderPathUrl.Text = targetFilePath; // Set text box to selected file path
                targetFolderPath = Path.GetDirectoryName(targetFilePath); // Get the absolute path from file path.

                // For debugging, comment when done.
                // MessageBox.Show("Folder PATH: " + targetFolderPath);
            }
        }
    }

    // Updater
    public class Updater
    {
        /// <summary>
        /// Zips up a folder.
        /// <param name="targetFolder"></param>
        /// </summary>
        public static void ZipPreviousVersion(string targetFolder)
        {
            // Create a directory first for Previous Version.
            // Cannot zip to same directory being zipped as it's in use.
            string preVersionFolderPath = "D:\\TestEnv\\PreviousVersion";
            try
            {
                if (!Directory.Exists(preVersionFolderPath))
                {
                    Directory.CreateDirectory(preVersionFolderPath);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The process failed: {0}", e.ToString());
            }

            // Create a Zip file for PreviousVersion
            // If it exists, delete then create.
            // If it doesn't exist, just create.

            if (File.Exists(preVersionFolderPath + "\\PreviousVersion.zip"))
            {
                File.Delete(preVersionFolderPath + "\\PreviousVersion.zip");
                ZipFile.CreateFromDirectory(targetFolder, preVersionFolderPath + "\\PreviousVersion.zip");
            }
            else
            {
                ZipFile.CreateFromDirectory(targetFolder, preVersionFolderPath + "\\PreviousVersion.zip");
            }

        }

        /// <summary>
        /// Reverts to Previous Version by extracting contents from PreviousVersion.zip to destination folder.
        /// <param name="sourceZipFile"></param>
        /// <param name="destFolder"></param>
        /// </summary>
        public static void revertVersion(string sourceZipFile, string destFolder)
        {
            // Delete directory then recreate the directory - Fastest option
            Directory.Delete(destFolder, true);
            Directory.CreateDirectory(destFolder);

            // Extract contents from PreviousVersion to Folder
            ZipFile.ExtractToDirectory(sourceZipFile, destFolder);
        }

        /// <summary>
        /// Compares the contents of a folder to entries in a Zip file.
        /// <param name="sourceFolder"></param>
        /// <param name="sourceZipFile"></param>
        /// </summary>
        public static void CompareFolderToZipContents(string sourceFolder, string sourceZipFile)
        {
            // Search folder for files
            Updater search = new Updater();
            List<string> folderFilePaths = search.GetAllRelativeFolderFilePaths(sourceFolder);

            // Remove D:\TestEnv\
            List<string> cleanedFolderFilePaths = new List<string>();
            foreach (var paths in folderFilePaths)
            {
                cleanedFolderFilePaths.Add(paths.Replace("D:\\TestEnv\\", ""));
            }

            // Track all entrys from sourceZipFile
            List<ZipArchiveEntry> zipEntries = search.GetAllZipEntries(sourceZipFile);

            // Convert ZipEntry File Paths to Window File Path Style
            List<string> cleanZipEntries = new List<string>();
            foreach (var entry in zipEntries)
            {
                cleanZipEntries.Add(entry.FullName.Replace("/", "\\"));
            }

            // Check what is missing in Zip File & what is missing in Folder
            var missingInZip = cleanedFolderFilePaths.Except(cleanZipEntries, StringComparer.OrdinalIgnoreCase).ToList();
            var missingInFolder = cleanZipEntries.Except(cleanedFolderFilePaths, StringComparer.OrdinalIgnoreCase).ToList();

            // DEBUGGING
            string strF = "";
            string strE = "";
            string strC = "";
            string strMz = "";
            string strMf = "";
            foreach (var sf in folderFilePaths)
            {
                strF += sf + "\n";
            }
            foreach (var en in zipEntries)
            {
                strE += en + "\n";
            }
            foreach (var en in cleanZipEntries)
            {
                strC += en + "\n";
            }
            foreach (var en in missingInZip)
            {
                strMz += en + "\n";
            }
            foreach (var en in missingInFolder)
            {
                strC += en + "\n";
            }
            //MessageBox.Show("Source Folder Paths:\n" + strF + "\nZip Entry Paths:\n" + strE + "\n Cleaned Zip Entry Paths:\n" + strC);
            //MessageBox.Show("Source Folder Paths:\n" + strF +"\nCleaned Zip Entry Paths:\n" + strC + "\nMissing in ZIP:\n" + strMz + "\nMissing in Folder:\n" + strMf);
            MessageBox.Show("\nMissing in ZIP:\n" + strMz + "\nMissing in Folder:\n" + strMf);
        }


        /// <summary>
        /// Gets all relative folder file paths for all files in the current directory and subdirectories.
        /// <param name="targetFolder"></param>
        /// </summary>
        public List<string> GetAllRelativeFolderFilePaths(string targetFolder)
        {
            List<string> relFolderFilePaths = new List<string>(Directory.EnumerateFiles(targetFolder, "*", SearchOption.AllDirectories));
            return relFolderFilePaths;
        }

        /// <summary>
        /// Gets all Zip Entries as a list.
        /// <param name="targetZip"></param>
        /// </summary>
        public List<ZipArchiveEntry> GetAllZipEntries(string targetZip)
        {
            List<ZipArchiveEntry> zipEntries = new List<ZipArchiveEntry>();

            using (ZipArchive archive = ZipFile.OpenRead(targetZip))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (string.IsNullOrEmpty(entry.Name)) // Skip folder entries
                        continue;

                    zipEntries.Add(entry);
                }
            }
            return zipEntries;
        }
    }
}

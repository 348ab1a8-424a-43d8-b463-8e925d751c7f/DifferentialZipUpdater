using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public Form1()
        {
            InitializeComponent(); // Initialized UI Component
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

        }

        private void revertButton_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void forceUpdateButton_Click(object sender, EventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFolderDialog = new OpenFileDialog();
            browseFolderDialog.InitialDirectory = "c:\\";
            browseFolderDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            browseFolderDialog.FilterIndex = 2;
            browseFolderDialog.RestoreDirectory = true;

            if (browseFolderDialog.ShowDialog() == DialogResult.OK)
            {
                // Get target file
                targetFilePath = browseFolderDialog.FileName; // Get the path of the specified file
                folderPathUrl.Text = targetFilePath; // Set text box to selected file path

                var targetFileInfo = new FileInfo(targetFilePath);

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
        /// Zips up a folder. Requires PATH to target folder to be zipped.
        /// <param name="targetFolder">Single parameter.</param>
        /// </summary>
        public void ZipFolder(string targetFolder)
        {

        }
    }
}

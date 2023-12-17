using SimpleCrypt.Functions.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SimpleCrypt.Views
{
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
            FileLogs.SetLogViewer(log_textbox);
            extentions_comboBox.SelectedItem = "(All Files)";
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            item_file_path_list_box.DragEnter += item_file_path_list_box_DragEnter;
            item_file_path_list_box.DragDrop += item_file_path_list_box_DragDrop;

            switch (Properties.Settings.Default.password_checkbox_setting)
            {
                case true:
                    save_password_checkbox.Checked = true;
                    break;

                case false:
                    save_password_checkbox.Checked = false;
                    break;
            }
        }

        private void save_password_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            switch (save_password_checkbox.Checked)
            {
                case true: // Sets the saved password into encryption password box
                    Properties.Settings.Default.password_checkbox_setting = true;
                    encryption_password_textbox.Text = Properties.Settings.Default.encryption_password_saved;
                    break;

                case false:
                    Properties.Settings.Default.password_checkbox_setting = false;
                    encryption_password_textbox.Text = "";
                    break;
            }
            Properties.Settings.Default.Save();
        }

        private void encryption_password_textbox_TextChanged(object sender, EventArgs e)
        {
            switch (save_password_checkbox.Checked)
            {
                case true: // Saves password from encryption password box
                    Properties.Settings.Default.encryption_password_saved = encryption_password_textbox.Text;
                    break;

                case false:
                    Properties.Settings.Default.encryption_password_saved = "";
                    break;
            }
            Properties.Settings.Default.Save();
        }
        
        private void item_file_path_list_box_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Process the file paths (in this example, adding them to a ListBox)
            foreach (string file in files)
            {
                // Check if it's a directory
                if (Directory.Exists(file))
                {
                    // Add the folder path to the ListBox
                    item_file_path_list_box.Items.Add(file);
                }
                else if (File.Exists(file))
                {
                    // Add the file path to the ListBox
                    item_file_path_list_box.Items.Add(file);
                }
            }
        }
    
        private void item_file_path_list_box_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Allow the drop
                e.Effect = DragDropEffects.Copy;
            }
        }


        // Gets Folders Contents 

        //private void ProcessDirectory(string targetDirectory)
        //{
        //    // Process the list of files found in the directory
        //    string[] fileEntries = Directory.GetFiles(targetDirectory);
        //    foreach (string fileName in fileEntries)
        //    {
        //        item_file_path_list_box.Items.Add(fileName);
        //    }

        //    // Recursively process subdirectories
        //    string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        //    foreach (string subdirectory in subdirectoryEntries)
        //    {
        //        ProcessDirectory(subdirectory);
        //    }
        //}

        private void remove_item_button_Click(object sender, EventArgs e)
        {
            int selectedIndex = item_file_path_list_box.SelectedIndex;
            bool Item = selectedIndex != -1;
            if (Item)
            {
                item_file_path_list_box.Items.RemoveAt(selectedIndex);
                item_file_path_list_box.SelectedIndex = ((selectedIndex < item_file_path_list_box.Items.Count) ? selectedIndex : (selectedIndex - 1));
                item_file_path_list_box.Focus();
            }
        }

        private async void encrypt_button_Click(object sender, EventArgs e)
        {
            var count = 0;
            var paths = item_file_path_list_box.Items;

            if (!string.IsNullOrEmpty(encryption_password_textbox.Text))
            {
                if (aes_checkbox.Checked == false && TripleDES_checkbox.Checked == false && DES_checkbox.Checked == false)
                {
                    MessageBox.Show("Please Choose an Encryption Method");
                }
                else
                {
                    if (aes_checkbox.Checked)
                    {
                        FileLogs.Log("Encryption Started.");
                        if (paths != null && paths.Count > 0)
                        {
                            foreach (string path in paths)
                            {

                                if (File.Exists(path)) // Is File 
                                {
                                    if (path.CheckExtension(extentions_comboBox.Text.ParseExtensions()))
                                    {
                                        try
                                        {
                                            await path.EncryptFileAsync(encryption_password_textbox.Text, "AES");
                                            FileLogs.Log(path + " Encrypted.");
                                            count++;

                                            if (delete_orginal_files_checkbox.Checked)
                                                File.Delete(path);
                                        }
                                        catch (Exception ex)
                                        {

                                            FileLogs.Log(path + " " + ex.Message);
                                        }
                                    }
                                }
                                if (Directory.Exists(path)) // Is Folder
                                {
                                    var followSubDirs = follow_sub_folders_checkbox.Checked ? true : false;

                                    var allfiles = path.GetFolderFilesPaths(followSubDirs);

                                    foreach (var file in allfiles)
                                    {
                                        if (file.CheckExtension(extentions_comboBox.Text.ParseExtensions()))
                                        {
                                            if (!file.EndsWith(".aes"))
                                            {
                                                try
                                                {
                                                    await file.EncryptFileAsync(encryption_password_textbox.Text, "AES");
                                                    FileLogs.Log(file + " Encrypted.");
                                                    count++;

                                                    if (delete_orginal_files_checkbox.Checked)
                                                        File.Delete(file);
                                                }
                                                catch (Exception ex)
                                                {

                                                    FileLogs.Log(file + " " + ex.Message);
                                                }
                                            }
                                            else
                                            {
                                                FileLogs.Log(file + " Ignored.");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        FileLogs.Log($"Finished : {count} File(s) Encrypted.");
                    }
                    if (DES_checkbox.Checked)
                    {
                        FileLogs.Log("Encryption Started.");
                        if (paths != null && paths.Count > 0)
                        {
                            foreach (string path in paths)
                            {

                                if (File.Exists(path)) // Is File 
                                {
                                    if (path.CheckExtension(extentions_comboBox.Text.ParseExtensions()))
                                    {
                                        try
                                        {
                                            await path.EncryptFileAsync(encryption_password_textbox.Text, "DES");
                                            FileLogs.Log(path + " Encrypted.");
                                            count++;

                                            if (delete_orginal_files_checkbox.Checked)
                                                File.Delete(path);
                                        }
                                        catch (Exception ex)
                                        {

                                            FileLogs.Log(path + " " + ex.Message);
                                        }
                                    }
                                }
                                if (Directory.Exists(path)) // Is Folder
                                {
                                    var followSubDirs = follow_sub_folders_checkbox.Checked ? true : false;

                                    var allfiles = path.GetFolderFilesPaths(followSubDirs);

                                    foreach (var file in allfiles)
                                    {
                                        if (file.CheckExtension(extentions_comboBox.Text.ParseExtensions()))
                                        {
                                            if (!file.EndsWith(".des"))
                                            {
                                                try
                                                {
                                                    await file.EncryptFileAsync(encryption_password_textbox.Text, "DES");
                                                    FileLogs.Log(file + " Encrypted.");
                                                    count++;

                                                    if (delete_orginal_files_checkbox.Checked)
                                                        File.Delete(file);
                                                }
                                                catch (Exception ex)
                                                {

                                                    FileLogs.Log(file + " " + ex.Message);
                                                }
                                            }
                                            else
                                            {
                                                FileLogs.Log(file + " Ignored.");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        FileLogs.Log($"Finished : {count} File(s) Encrypted.");
                    }
                    if (TripleDES_checkbox.Checked)
                    {
                        FileLogs.Log("Encryption Started.");
                        if (paths != null && paths.Count > 0)
                        {
                            foreach (string path in paths)
                            {

                                if (File.Exists(path)) // Is File 
                                {
                                    if (path.CheckExtension(extentions_comboBox.Text.ParseExtensions()))
                                    {
                                        try
                                        {
                                            await path.EncryptFileAsync(encryption_password_textbox.Text, "3DES");
                                            FileLogs.Log(path + " Encrypted.");
                                            count++;

                                            if (delete_orginal_files_checkbox.Checked)
                                                File.Delete(path);
                                        }
                                        catch (Exception ex)
                                        {

                                            FileLogs.Log(path + " " + ex.Message);
                                        }
                                    }
                                }
                                if (Directory.Exists(path)) // Is Folder
                                {
                                    var followSubDirs = follow_sub_folders_checkbox.Checked ? true : false;

                                    var allfiles = path.GetFolderFilesPaths(followSubDirs);

                                    foreach (var file in allfiles)
                                    {
                                        if (file.CheckExtension(extentions_comboBox.Text.ParseExtensions()))
                                        {
                                            if (!file.EndsWith(".3des"))
                                            {
                                                try
                                                {
                                                    await file.EncryptFileAsync(encryption_password_textbox.Text, "3DES");
                                                    FileLogs.Log(file + " Encrypted.");
                                                    count++;

                                                    if (delete_orginal_files_checkbox.Checked)
                                                        File.Delete(file);
                                                }
                                                catch (Exception ex)
                                                {

                                                    FileLogs.Log(file + " " + ex.Message);
                                                }
                                            }
                                            else
                                            {
                                                FileLogs.Log(file + " Ignored.");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        FileLogs.Log($"Finished : {count} File(s) Encrypted.");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Please Enter A Encryption Password");
            }
        }

        private void add_files_button_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Select your File(s)";
                fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.Multiselect = true;
                fileDialog.SupportMultiDottedExtensions = true;
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    var files = fileDialog.FileNames;

                    if (files != null && files.Length > 0)
                    {
                        foreach (var filePath in files)
                        {
                            var items = item_file_path_list_box.Items;
                            if (!items.Contains(filePath))
                                item_file_path_list_box.Items.Add(filePath);
                            else
                                FileLogs.Log(filePath + " is already exist in the list.");
                        }
                    }
                }
            }
        }

        private void add_folder_button_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select A Folder";
                folderDialog.ShowNewFolderButton = true;
                folderDialog.RootFolder = Environment.SpecialFolder.Desktop;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    var folderPath = folderDialog.SelectedPath;
                    if (!String.IsNullOrEmpty(folderPath))
                    {
                        var items = item_file_path_list_box.Items;
                        if (!items.Contains(folderPath))
                            item_file_path_list_box.Items.Add(folderPath);
                        else
                            FileLogs.Log(folderPath + " is already exist in the list.");
                    }
                }
            }
        }

        private async void decrypt_button_Click(object sender, EventArgs e)
        {
            var count = 0;
            var paths = item_file_path_list_box.Items;

            if (!string.IsNullOrEmpty(encryption_password_textbox.Text))
            {
                if (aes_checkbox.Checked == false && TripleDES_checkbox.Checked == false && DES_checkbox.Checked == false)
                {
                    MessageBox.Show("Please Choose an Decryption Method");
                }
                else
                {
                    if (aes_checkbox.Checked)
                    {
                        FileLogs.Log("Decryption Started.");

                        if (paths.Count > 0)
                        {
                            foreach (string path in paths)
                            {

                                if (File.Exists(path) && path.EndsWith(".aes")) // Is Encrypted File 
                                {
                                    try
                                    {
                                        await path.DecryptFileAsync(encryption_password_textbox.Text, "AES");
                                        FileLogs.Log(path + " Decrypted.");
                                        count++;

                                        if (delete_orginal_files_checkbox.Checked)
                                            File.Delete(path);
                                    }
                                    catch (Exception ex)
                                    {
                                        FileLogs.Log(path + " " + ex.Message);
                                        if (File.Exists(path.RemoveExtension()))
                                            File.Delete(path.RemoveExtension());
                                    }
                                }
                                if (Directory.Exists(path)) // Is Folder
                                {
                                    var followSubDirs = follow_sub_folders_checkbox.Checked ? true : false;

                                    var allfiles = path.GetFolderFilesPaths(followSubDirs);

                                    foreach (var file in allfiles)
                                    {
                                        if (file.RemoveExtension().CheckExtension(extentions_comboBox.Text.ParseExtensions()))
                                        {
                                            if (file.EndsWith(".aes"))
                                            {
                                                try
                                                {
                                                    await file.DecryptFileAsync(encryption_password_textbox.Text, "AES");
                                                    FileLogs.Log(file + " Decrypted.");
                                                    count++;

                                                    if (delete_orginal_files_checkbox.Checked)
                                                        File.Delete(file);
                                                }
                                                catch (Exception ex)
                                                {
                                                    FileLogs.Log(file + " " + ex.Message);
                                                    if (File.Exists(file.RemoveExtension()))
                                                        File.Delete(file.RemoveExtension());
                                                }
                                            }

                                        }
                                        else
                                        {
                                            FileLogs.Log(file + " Ignored.");
                                        }
                                    }
                                }
                            }
                        }
                        FileLogs.Log($"Finished : {count} File(s) Decrypted.");
                    }
                    if (DES_checkbox.Checked)
                    {
                        FileLogs.Log("Decryption Started.");

                        if (paths.Count > 0)
                        {
                            foreach (string path in paths)
                            {

                                if (File.Exists(path) && path.EndsWith(".des")) // Is Encrypted File 
                                {
                                    try
                                    {
                                        await path.DecryptFileAsync(encryption_password_textbox.Text, "DES");
                                        FileLogs.Log(path + " Decrypted.");
                                        count++;

                                        if (delete_orginal_files_checkbox.Checked)
                                            File.Delete(path);
                                    }
                                    catch (Exception ex)
                                    {
                                        FileLogs.Log(path + " " + ex.Message);
                                        if (File.Exists(path.RemoveExtension()))
                                            File.Delete(path.RemoveExtension());
                                    }


                                }
                                if (Directory.Exists(path)) // Is Folder
                                {
                                    var followSubDirs = follow_sub_folders_checkbox.Checked ? true : false;

                                    var allfiles = path.GetFolderFilesPaths(followSubDirs);

                                    foreach (var file in allfiles)
                                    {
                                        if (file.RemoveExtension().CheckExtension(extentions_comboBox.Text.ParseExtensions()))
                                        {
                                            if (file.EndsWith(".des"))
                                            {
                                                try
                                                {
                                                    await file.DecryptFileAsync(encryption_password_textbox.Text, "DES");
                                                    FileLogs.Log(file + " Decrypted.");
                                                    count++;

                                                    if (delete_orginal_files_checkbox.Checked)
                                                        File.Delete(file);
                                                }
                                                catch (Exception ex)
                                                {
                                                    FileLogs.Log(file + " " + ex.Message);
                                                    if (File.Exists(file.RemoveExtension()))
                                                        File.Delete(file.RemoveExtension());
                                                }
                                            }

                                        }
                                        else
                                        {
                                            FileLogs.Log(file + " Ignored.");
                                        }
                                    }
                                }
                            }
                        }
                        FileLogs.Log($"Finished : {count} File(s) Decrypted.");
                    }
                    if (TripleDES_checkbox.Checked)
                    {
                        FileLogs.Log("Decryption Started.");

                        if (paths.Count > 0)
                        {
                            foreach (string path in paths)
                            {

                                if (File.Exists(path) && path.EndsWith(".3des")) // Is Encrypted File 
                                {
                                    try
                                    {
                                        await path.DecryptFileAsync(encryption_password_textbox.Text, "3DES");
                                        FileLogs.Log(path + " Decrypted.");
                                        count++;

                                        if (delete_orginal_files_checkbox.Checked)
                                            File.Delete(path);
                                    }
                                    catch (Exception ex)
                                    {
                                        FileLogs.Log(path + " " + ex.Message);
                                        if (File.Exists(path.RemoveExtension()))
                                            File.Delete(path.RemoveExtension());
                                    }
                                }
                                if (Directory.Exists(path)) // Is Folder
                                {
                                    var followSubDirs = follow_sub_folders_checkbox.Checked ? true : false;

                                    var allfiles = path.GetFolderFilesPaths(followSubDirs);

                                    foreach (var file in allfiles)
                                    {
                                        if (file.RemoveExtension().CheckExtension(extentions_comboBox.Text.ParseExtensions()))
                                        {
                                            if (file.EndsWith(".3des"))
                                            {
                                                try
                                                {
                                                    await file.DecryptFileAsync(encryption_password_textbox.Text, "3DES");
                                                    FileLogs.Log(file + " Decrypted.");
                                                    count++;

                                                    if (delete_orginal_files_checkbox.Checked)
                                                        File.Delete(file);
                                                }
                                                catch (Exception ex)
                                                {
                                                    FileLogs.Log(file + " " + ex.Message);
                                                    if (File.Exists(file.RemoveExtension()))
                                                        File.Delete(file.RemoveExtension());
                                                }
                                            }

                                        }
                                        else
                                        {
                                            FileLogs.Log(file + " Ignored.");
                                        }
                                    }
                                }
                            }
                        }
                        FileLogs.Log($"Finished : {count} File(s) Decrypted.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter A Decryption Password");
            }
        }
        private void save_logs_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Loads Faster ;)
                switch (string.IsNullOrEmpty(log_textbox.Text))
                {
                    case true:
                        MessageBox.Show("No logs found.");
                        break;

                    case false:
                        {
                            using (var saveFileDialog = new SaveFileDialog())
                            {
                                saveFileDialog.Title = "Select your File(s)";
                                saveFileDialog.CheckFileExists = false; // Allow the user to specify a new file
                                saveFileDialog.CheckPathExists = true;
                                saveFileDialog.SupportMultiDottedExtensions = true;
                                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                                    {
                                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                                        {
                                            writer.Write(log_textbox.Text);
                                        }
                                        MessageBox.Show("Text saved to file successfully!");
                                    }
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void creator_label_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Nova-Squad");
        }
    }
}



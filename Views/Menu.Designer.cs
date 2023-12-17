namespace SimpleCrypt.Views
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.encrypt_button = new System.Windows.Forms.Button();
            this.decrypt_button = new System.Windows.Forms.Button();
            this.save_password_checkbox = new System.Windows.Forms.CheckBox();
            this.save_logs_button = new System.Windows.Forms.Button();
            this.file_path_group_box = new System.Windows.Forms.GroupBox();
            this.remove_item_button = new System.Windows.Forms.Button();
            this.add_files_button = new System.Windows.Forms.Button();
            this.add_folder_button = new System.Windows.Forms.Button();
            this.item_file_path_list_box = new System.Windows.Forms.ListBox();
            this.setting_group_box = new System.Windows.Forms.GroupBox();
            this.delete_orginal_files_checkbox = new System.Windows.Forms.CheckBox();
            this.follow_sub_folders_checkbox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.extentions_comboBox = new System.Windows.Forms.ComboBox();
            this.aes_checkbox = new System.Windows.Forms.CheckBox();
            this.TripleDES_checkbox = new System.Windows.Forms.CheckBox();
            this.DES_checkbox = new System.Windows.Forms.CheckBox();
            this.creator_label = new System.Windows.Forms.Label();
            this.encryption_password_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.log_textbox = new System.Windows.Forms.TextBox();
            this.file_path_group_box.SuspendLayout();
            this.setting_group_box.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // encrypt_button
            // 
            this.encrypt_button.Location = new System.Drawing.Point(9, 280);
            this.encrypt_button.Name = "encrypt_button";
            this.encrypt_button.Size = new System.Drawing.Size(192, 31);
            this.encrypt_button.TabIndex = 2;
            this.encrypt_button.Text = "Encrypt";
            this.encrypt_button.UseVisualStyleBackColor = true;
            this.encrypt_button.Click += new System.EventHandler(this.encrypt_button_Click);
            // 
            // decrypt_button
            // 
            this.decrypt_button.Location = new System.Drawing.Point(233, 280);
            this.decrypt_button.Name = "decrypt_button";
            this.decrypt_button.Size = new System.Drawing.Size(192, 31);
            this.decrypt_button.TabIndex = 3;
            this.decrypt_button.Text = "Decrypt";
            this.decrypt_button.UseVisualStyleBackColor = true;
            this.decrypt_button.Click += new System.EventHandler(this.decrypt_button_Click);
            // 
            // save_password_checkbox
            // 
            this.save_password_checkbox.AutoSize = true;
            this.save_password_checkbox.Location = new System.Drawing.Point(6, 78);
            this.save_password_checkbox.Name = "save_password_checkbox";
            this.save_password_checkbox.Size = new System.Drawing.Size(153, 17);
            this.save_password_checkbox.TabIndex = 4;
            this.save_password_checkbox.Text = "Save Encryption Password";
            this.save_password_checkbox.UseVisualStyleBackColor = true;
            this.save_password_checkbox.CheckedChanged += new System.EventHandler(this.save_password_checkbox_CheckedChanged);
            // 
            // save_logs_button
            // 
            this.save_logs_button.Location = new System.Drawing.Point(9, 332);
            this.save_logs_button.Name = "save_logs_button";
            this.save_logs_button.Size = new System.Drawing.Size(80, 23);
            this.save_logs_button.TabIndex = 5;
            this.save_logs_button.Text = "Save Logs";
            this.save_logs_button.UseVisualStyleBackColor = true;
            this.save_logs_button.Click += new System.EventHandler(this.save_logs_button_Click);
            // 
            // file_path_group_box
            // 
            this.file_path_group_box.Controls.Add(this.remove_item_button);
            this.file_path_group_box.Controls.Add(this.add_files_button);
            this.file_path_group_box.Controls.Add(this.add_folder_button);
            this.file_path_group_box.Controls.Add(this.item_file_path_list_box);
            this.file_path_group_box.Location = new System.Drawing.Point(9, 12);
            this.file_path_group_box.Name = "file_path_group_box";
            this.file_path_group_box.Size = new System.Drawing.Size(416, 134);
            this.file_path_group_box.TabIndex = 8;
            this.file_path_group_box.TabStop = false;
            this.file_path_group_box.Text = "File Path";
            // 
            // remove_item_button
            // 
            this.remove_item_button.Location = new System.Drawing.Point(323, 94);
            this.remove_item_button.Name = "remove_item_button";
            this.remove_item_button.Size = new System.Drawing.Size(80, 23);
            this.remove_item_button.TabIndex = 6;
            this.remove_item_button.Text = "Remove";
            this.remove_item_button.UseVisualStyleBackColor = true;
            this.remove_item_button.Click += new System.EventHandler(this.remove_item_button_Click);
            // 
            // add_files_button
            // 
            this.add_files_button.Location = new System.Drawing.Point(6, 94);
            this.add_files_button.Name = "add_files_button";
            this.add_files_button.Size = new System.Drawing.Size(75, 23);
            this.add_files_button.TabIndex = 4;
            this.add_files_button.Text = "Add Files";
            this.add_files_button.UseVisualStyleBackColor = true;
            this.add_files_button.Click += new System.EventHandler(this.add_files_button_Click);
            // 
            // add_folder_button
            // 
            this.add_folder_button.Location = new System.Drawing.Point(87, 94);
            this.add_folder_button.Name = "add_folder_button";
            this.add_folder_button.Size = new System.Drawing.Size(80, 23);
            this.add_folder_button.TabIndex = 5;
            this.add_folder_button.Text = "Add Folder";
            this.add_folder_button.UseVisualStyleBackColor = true;
            this.add_folder_button.Click += new System.EventHandler(this.add_folder_button_Click);
            // 
            // item_file_path_list_box
            // 
            this.item_file_path_list_box.AllowDrop = true;
            this.item_file_path_list_box.FormattingEnabled = true;
            this.item_file_path_list_box.Location = new System.Drawing.Point(6, 19);
            this.item_file_path_list_box.MaximumSize = new System.Drawing.Size(397, 69);
            this.item_file_path_list_box.MinimumSize = new System.Drawing.Size(397, 69);
            this.item_file_path_list_box.Name = "item_file_path_list_box";
            this.item_file_path_list_box.Size = new System.Drawing.Size(397, 69);
            this.item_file_path_list_box.TabIndex = 0;
            // 
            // setting_group_box
            // 
            this.setting_group_box.Controls.Add(this.delete_orginal_files_checkbox);
            this.setting_group_box.Controls.Add(this.follow_sub_folders_checkbox);
            this.setting_group_box.Controls.Add(this.save_password_checkbox);
            this.setting_group_box.Location = new System.Drawing.Point(9, 153);
            this.setting_group_box.Name = "setting_group_box";
            this.setting_group_box.Size = new System.Drawing.Size(192, 121);
            this.setting_group_box.TabIndex = 9;
            this.setting_group_box.TabStop = false;
            this.setting_group_box.Text = "Settings";
            // 
            // delete_orginal_files_checkbox
            // 
            this.delete_orginal_files_checkbox.AutoSize = true;
            this.delete_orginal_files_checkbox.Location = new System.Drawing.Point(6, 32);
            this.delete_orginal_files_checkbox.Name = "delete_orginal_files_checkbox";
            this.delete_orginal_files_checkbox.Size = new System.Drawing.Size(117, 17);
            this.delete_orginal_files_checkbox.TabIndex = 6;
            this.delete_orginal_files_checkbox.Text = "Delete Orginal Files";
            this.delete_orginal_files_checkbox.UseVisualStyleBackColor = true;
            // 
            // follow_sub_folders_checkbox
            // 
            this.follow_sub_folders_checkbox.AutoSize = true;
            this.follow_sub_folders_checkbox.Location = new System.Drawing.Point(6, 55);
            this.follow_sub_folders_checkbox.Name = "follow_sub_folders_checkbox";
            this.follow_sub_folders_checkbox.Size = new System.Drawing.Size(115, 17);
            this.follow_sub_folders_checkbox.TabIndex = 5;
            this.follow_sub_folders_checkbox.Text = "Follow Sub Folders";
            this.follow_sub_folders_checkbox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.extentions_comboBox);
            this.groupBox1.Controls.Add(this.aes_checkbox);
            this.groupBox1.Controls.Add(this.TripleDES_checkbox);
            this.groupBox1.Controls.Add(this.DES_checkbox);
            this.groupBox1.Location = new System.Drawing.Point(233, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 121);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Extensions";
            // 
            // extentions_comboBox
            // 
            this.extentions_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extentions_comboBox.FormattingEnabled = true;
            this.extentions_comboBox.Items.AddRange(new object[] {
            "(All Files)",
            "(Audio) mp3 wav acc ogg amr wma",
            "(Code) cs vb java py rb cpp html css js",
            "(Compresed) zip rar 7z tar gzip",
            "(Documents) pdf txt rtf doc docx ppt pptx xls xlsx",
            "(Images) jpg jpeg png gif bmp",
            "(Videos) avi flv mov mp4 mpg rm rmvb mkv swf vob wmv 3g2 3gp asf ogv"});
            this.extentions_comboBox.Location = new System.Drawing.Point(67, 92);
            this.extentions_comboBox.Name = "extentions_comboBox";
            this.extentions_comboBox.Size = new System.Drawing.Size(121, 21);
            this.extentions_comboBox.TabIndex = 7;
            // 
            // aes_checkbox
            // 
            this.aes_checkbox.AutoSize = true;
            this.aes_checkbox.Location = new System.Drawing.Point(6, 19);
            this.aes_checkbox.Name = "aes_checkbox";
            this.aes_checkbox.Size = new System.Drawing.Size(47, 17);
            this.aes_checkbox.TabIndex = 6;
            this.aes_checkbox.Text = "AES";
            this.aes_checkbox.UseVisualStyleBackColor = true;
            // 
            // TripleDES_checkbox
            // 
            this.TripleDES_checkbox.AutoSize = true;
            this.TripleDES_checkbox.Location = new System.Drawing.Point(6, 42);
            this.TripleDES_checkbox.Name = "TripleDES_checkbox";
            this.TripleDES_checkbox.Size = new System.Drawing.Size(74, 17);
            this.TripleDES_checkbox.TabIndex = 5;
            this.TripleDES_checkbox.Text = "TripleDES";
            this.TripleDES_checkbox.UseVisualStyleBackColor = true;
            // 
            // DES_checkbox
            // 
            this.DES_checkbox.AutoSize = true;
            this.DES_checkbox.Location = new System.Drawing.Point(6, 65);
            this.DES_checkbox.Name = "DES_checkbox";
            this.DES_checkbox.Size = new System.Drawing.Size(48, 17);
            this.DES_checkbox.TabIndex = 4;
            this.DES_checkbox.Text = "DES";
            this.DES_checkbox.UseVisualStyleBackColor = true;
            // 
            // creator_label
            // 
            this.creator_label.AutoSize = true;
            this.creator_label.ForeColor = System.Drawing.Color.Black;
            this.creator_label.Location = new System.Drawing.Point(101, 454);
            this.creator_label.Name = "creator_label";
            this.creator_label.Size = new System.Drawing.Size(217, 13);
            this.creator_label.TabIndex = 11;
            this.creator_label.Text = "Created by: https://github.com/Nova-Squad";
            this.creator_label.Click += new System.EventHandler(this.creator_label_Click);
            // 
            // encryption_password_textbox
            // 
            this.encryption_password_textbox.Location = new System.Drawing.Point(303, 332);
            this.encryption_password_textbox.Name = "encryption_password_textbox";
            this.encryption_password_textbox.Size = new System.Drawing.Size(122, 20);
            this.encryption_password_textbox.TabIndex = 12;
            this.encryption_password_textbox.TextChanged += new System.EventHandler(this.encryption_password_textbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(217, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Encryption Key -";
            // 
            // log_textbox
            // 
            this.log_textbox.Location = new System.Drawing.Point(9, 361);
            this.log_textbox.Multiline = true;
            this.log_textbox.Name = "log_textbox";
            this.log_textbox.ReadOnly = true;
            this.log_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log_textbox.Size = new System.Drawing.Size(416, 85);
            this.log_textbox.TabIndex = 14;
            // 
            // Menu
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(433, 480);
            this.Controls.Add(this.log_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.encryption_password_textbox);
            this.Controls.Add(this.creator_label);
            this.Controls.Add(this.save_logs_button);
            this.Controls.Add(this.encrypt_button);
            this.Controls.Add(this.decrypt_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.setting_group_box);
            this.Controls.Add(this.file_path_group_box);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(449, 519);
            this.MinimumSize = new System.Drawing.Size(449, 519);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimpleCrypt";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.file_path_group_box.ResumeLayout(false);
            this.setting_group_box.ResumeLayout(false);
            this.setting_group_box.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button encrypt_button;
        private System.Windows.Forms.Button decrypt_button;
        private System.Windows.Forms.CheckBox save_password_checkbox;
        private System.Windows.Forms.Button save_logs_button;
        private System.Windows.Forms.GroupBox file_path_group_box;
        private System.Windows.Forms.Button remove_item_button;
        private System.Windows.Forms.Button add_files_button;
        private System.Windows.Forms.Button add_folder_button;
        private System.Windows.Forms.ListBox item_file_path_list_box;
        private System.Windows.Forms.GroupBox setting_group_box;
        private System.Windows.Forms.CheckBox delete_orginal_files_checkbox;
        private System.Windows.Forms.CheckBox follow_sub_folders_checkbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox aes_checkbox;
        private System.Windows.Forms.CheckBox TripleDES_checkbox;
        private System.Windows.Forms.CheckBox DES_checkbox;
        private System.Windows.Forms.Label creator_label;
        private System.Windows.Forms.TextBox encryption_password_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox log_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox extentions_comboBox;
    }
}
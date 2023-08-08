namespace Columbus
{
    partial class SearchView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            btnSearch = new Button();
            btnCopy = new Button();
            btnCancelSearch = new Button();
            checkedListBoxImages = new CheckedListBox();
            chkBoxSelectAll = new CheckBox();
            txtSearchKeyword = new TextBox();
            splitContainer1 = new SplitContainer();
            statusStrip1 = new StatusStrip();
            lbl_progress = new ToolStripStatusLabel();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            groupBox1 = new GroupBox();
            progressBar = new ProgressBar();
            txtFolderPath = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Dock = DockStyle.Top;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Margin = new Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(223, 320);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.FlatStyle = FlatStyle.System;
            btnSearch.Location = new Point(988, 19);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(88, 28);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCopy.FlatStyle = FlatStyle.System;
            btnCopy.Location = new Point(879, 538);
            btnCopy.Margin = new Padding(4, 3, 4, 3);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(222, 31);
            btnCopy.TabIndex = 7;
            btnCopy.Text = "Save";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnCancelSearch
            // 
            btnCancelSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelSearch.Enabled = false;
            btnCancelSearch.FlatStyle = FlatStyle.System;
            btnCancelSearch.Location = new Point(1007, 110);
            btnCancelSearch.Margin = new Padding(4, 3, 4, 3);
            btnCancelSearch.Name = "btnCancelSearch";
            btnCancelSearch.Size = new Size(69, 28);
            btnCancelSearch.TabIndex = 8;
            btnCancelSearch.Text = "Stop";
            btnCancelSearch.UseVisualStyleBackColor = true;
            btnCancelSearch.Click += btnCancelSearch_Click;
            // 
            // checkedListBoxImages
            // 
            checkedListBoxImages.CheckOnClick = true;
            checkedListBoxImages.Dock = DockStyle.Fill;
            checkedListBoxImages.FormattingEnabled = true;
            checkedListBoxImages.Location = new Point(0, 0);
            checkedListBoxImages.Margin = new Padding(4, 3, 4, 3);
            checkedListBoxImages.Name = "checkedListBoxImages";
            checkedListBoxImages.Size = new Size(848, 320);
            checkedListBoxImages.TabIndex = 9;
            checkedListBoxImages.SelectedIndexChanged += checkedListBoxImages_SelectedIndexChanged;
            // 
            // chkBoxSelectAll
            // 
            chkBoxSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chkBoxSelectAll.AutoSize = true;
            chkBoxSelectAll.Location = new Point(21, 190);
            chkBoxSelectAll.Margin = new Padding(4, 3, 4, 3);
            chkBoxSelectAll.Name = "chkBoxSelectAll";
            chkBoxSelectAll.Size = new Size(74, 19);
            chkBoxSelectAll.TabIndex = 11;
            chkBoxSelectAll.Text = "Select All";
            chkBoxSelectAll.UseVisualStyleBackColor = true;
            chkBoxSelectAll.CheckedChanged += chkBoxSelectAll_CheckedChanged;
            // 
            // txtSearchKeyword
            // 
            txtSearchKeyword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchKeyword.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchKeyword.Location = new Point(7, 22);
            txtSearchKeyword.Margin = new Padding(4, 3, 4, 3);
            txtSearchKeyword.Name = "txtSearchKeyword";
            txtSearchKeyword.PlaceholderText = "Find...";
            txtSearchKeyword.Size = new Size(973, 21);
            txtSearchKeyword.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BackColor = SystemColors.Control;
            splitContainer1.Location = new Point(18, 212);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(statusStrip1);
            splitContainer1.Panel1.Controls.Add(checkedListBoxImages);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox);
            splitContainer1.Size = new Size(1083, 320);
            splitContainer1.SplitterDistance = 848;
            splitContainer1.SplitterWidth = 12;
            splitContainer1.TabIndex = 14;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lbl_progress });
            statusStrip1.Location = new Point(0, 298);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(848, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbl_progress
            // 
            lbl_progress.Name = "lbl_progress";
            lbl_progress.Size = new Size(0, 17);
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(7, 74);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(92, 19);
            checkBox1.TabIndex = 16;
            checkBox1.Text = "Unique Only";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.Anchor = AnchorStyles.Left;
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(7, 49);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(73, 19);
            checkBox2.TabIndex = 17;
            checkBox2.Text = "Top Only";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(progressBar);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(txtSearchKeyword);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(btnCancelSearch);
            groupBox1.Location = new Point(18, 44);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(1083, 143);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Keyword Search";
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(7, 116);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(993, 18);
            progressBar.TabIndex = 18;
            progressBar.Visible = false;
            // 
            // txtFolderPath
            // 
            txtFolderPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFolderPath.BorderStyle = BorderStyle.FixedSingle;
            txtFolderPath.Location = new Point(18, 10);
            txtFolderPath.Margin = new Padding(4, 3, 4, 3);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.PlaceholderText = "Browse...";
            txtFolderPath.Size = new Size(1084, 23);
            txtFolderPath.TabIndex = 1;
            txtFolderPath.Text = "C:\\Users\\antho\\OneDrive\\Documents";
            // 
            // SearchView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 581);
            Controls.Add(txtFolderPath);
            Controls.Add(groupBox1);
            Controls.Add(splitContainer1);
            Controls.Add(chkBoxSelectAll);
            Controls.Add(btnCopy);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SearchView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IconFinder | v1.0.2 (02.08.23) AL";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button btnSearch;
        private Button btnCopy;
        private Button btnCancelSearch;
        private CheckedListBox checkedListBoxImages;
        private CheckBox chkBoxSelectAll;
        private TextBox txtSearchKeyword;
        private SplitContainer splitContainer1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private GroupBox groupBox1;
        private TextBox txtFolderPath;
        private ProgressBar progressBar;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbl_progress;
    }
}
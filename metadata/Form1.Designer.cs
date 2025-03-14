namespace metadata
{
    partial class Form1
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
            txtOsuLink = new Label();
            tbxOsuLink = new TextBox();
            btnSearch = new Button();
            btnReset = new Button();
            txtTitle = new Label();
            tbxTitle = new TextBox();
            btnTitleCopy = new Button();
            txtDesc = new Label();
            btnDescCopy = new Button();
            tbxDesc = new TextBox();
            txtTags = new Label();
            btnTagsCopy = new Button();
            tbxTags = new TextBox();
            txtHint = new Label();
            SuspendLayout();
            // 
            // txtOsuLink
            // 
            txtOsuLink.AutoSize = true;
            txtOsuLink.Font = new Font("Microsoft JhengHei UI", 12F);
            txtOsuLink.Location = new Point(20, 20);
            txtOsuLink.Name = "txtOsuLink";
            txtOsuLink.Size = new Size(76, 20);
            txtOsuLink.TabIndex = 0;
            txtOsuLink.Text = "osu! Link";
            // 
            // tbxOsuLink
            // 
            tbxOsuLink.Font = new Font("Microsoft JhengHei UI", 8.25F);
            tbxOsuLink.Location = new Point(102, 20);
            tbxOsuLink.Name = "tbxOsuLink";
            tbxOsuLink.Size = new Size(314, 21);
            tbxOsuLink.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(341, 47);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "搜尋";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(341, 424);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 3;
            btnReset.Text = "重置";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // txtTitle
            // 
            txtTitle.AutoSize = true;
            txtTitle.Font = new Font("Microsoft JhengHei UI", 12F);
            txtTitle.Location = new Point(55, 101);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(41, 20);
            txtTitle.TabIndex = 4;
            txtTitle.Text = "Title";
            // 
            // tbxTitle
            // 
            tbxTitle.BackColor = SystemColors.Info;
            tbxTitle.Font = new Font("Microsoft JhengHei UI", 8.25F);
            tbxTitle.Location = new Point(102, 100);
            tbxTitle.Multiline = true;
            tbxTitle.Name = "tbxTitle";
            tbxTitle.ReadOnly = true;
            tbxTitle.Size = new Size(282, 46);
            tbxTitle.TabIndex = 5;
            // 
            // btnTitleCopy
            // 
            btnTitleCopy.Location = new Point(390, 99);
            btnTitleCopy.Name = "btnTitleCopy";
            btnTitleCopy.Size = new Size(26, 23);
            btnTitleCopy.TabIndex = 6;
            btnTitleCopy.Text = "C";
            btnTitleCopy.UseVisualStyleBackColor = true;
            btnTitleCopy.Click += btnTitleCopy_Click;
            // 
            // txtDesc
            // 
            txtDesc.AutoSize = true;
            txtDesc.Font = new Font("Microsoft JhengHei UI", 12F);
            txtDesc.Location = new Point(51, 153);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(45, 20);
            txtDesc.TabIndex = 7;
            txtDesc.Text = "Desc";
            // 
            // btnDescCopy
            // 
            btnDescCopy.Location = new Point(390, 152);
            btnDescCopy.Name = "btnDescCopy";
            btnDescCopy.Size = new Size(26, 23);
            btnDescCopy.TabIndex = 9;
            btnDescCopy.Text = "C";
            btnDescCopy.UseVisualStyleBackColor = true;
            btnDescCopy.Click += btnDescCopy_Click;
            // 
            // tbxDesc
            // 
            tbxDesc.BackColor = SystemColors.Info;
            tbxDesc.Font = new Font("Microsoft JhengHei UI", 8.25F);
            tbxDesc.Location = new Point(102, 152);
            tbxDesc.Multiline = true;
            tbxDesc.Name = "tbxDesc";
            tbxDesc.ReadOnly = true;
            tbxDesc.ScrollBars = ScrollBars.Vertical;
            tbxDesc.Size = new Size(282, 108);
            tbxDesc.TabIndex = 8;
            // 
            // txtTags
            // 
            txtTags.AutoSize = true;
            txtTags.Font = new Font("Microsoft JhengHei UI", 12F);
            txtTags.Location = new Point(51, 267);
            txtTags.Name = "txtTags";
            txtTags.Size = new Size(44, 20);
            txtTags.TabIndex = 10;
            txtTags.Text = "Tags";
            // 
            // btnTagsCopy
            // 
            btnTagsCopy.Location = new Point(390, 266);
            btnTagsCopy.Name = "btnTagsCopy";
            btnTagsCopy.Size = new Size(26, 23);
            btnTagsCopy.TabIndex = 12;
            btnTagsCopy.Text = "C";
            btnTagsCopy.UseVisualStyleBackColor = true;
            btnTagsCopy.Click += btnTagsCopy_Click;
            // 
            // tbxTags
            // 
            tbxTags.BackColor = SystemColors.Info;
            tbxTags.Font = new Font("Microsoft JhengHei UI", 8.25F);
            tbxTags.Location = new Point(102, 266);
            tbxTags.Multiline = true;
            tbxTags.Name = "tbxTags";
            tbxTags.ReadOnly = true;
            tbxTags.ScrollBars = ScrollBars.Vertical;
            tbxTags.Size = new Size(282, 108);
            tbxTags.TabIndex = 11;
            // 
            // txtHint
            // 
            txtHint.AutoSize = true;
            txtHint.Location = new Point(101, 384);
            txtHint.Name = "txtHint";
            txtHint.Size = new Size(0, 15);
            txtHint.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 459);
            Controls.Add(txtHint);
            Controls.Add(btnTagsCopy);
            Controls.Add(tbxTags);
            Controls.Add(txtTags);
            Controls.Add(btnDescCopy);
            Controls.Add(tbxDesc);
            Controls.Add(txtDesc);
            Controls.Add(btnTitleCopy);
            Controls.Add(tbxTitle);
            Controls.Add(txtTitle);
            Controls.Add(btnReset);
            Controls.Add(btnSearch);
            Controls.Add(tbxOsuLink);
            Controls.Add(txtOsuLink);
            Name = "Form1";
            Text = "Youtube Metadata Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtOsuLink;
        private TextBox tbxOsuLink;
        private Button btnSearch;
        private Button btnReset;
        private Label txtTitle;
        private TextBox tbxTitle;
        private Button btnTitleCopy;
        private Label txtDesc;
        private Button btnDescCopy;
        private TextBox tbxDesc;
        private Label txtTags;
        private Button btnTagsCopy;
        private TextBox tbxTags;
        private Label txtHint;
    }
}

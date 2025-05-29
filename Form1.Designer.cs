namespace StellarisNanotechHelper
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
            search_button = new Button();
            textBox_filePath = new TextBox();
            output_box = new TextBox();
            label1 = new Label();
            buttom_browse = new Button();
            progressBar1 = new ProgressBar();
            English = new LinkLabel();
            Chinese = new LinkLabel();
            label2 = new Label();
            SuspendLayout();
            // 
            // search_button
            // 
            search_button.Location = new Point(29, 37);
            search_button.Margin = new Padding(2, 2, 2, 2);
            search_button.Name = "search_button";
            search_button.Size = new Size(148, 67);
            search_button.TabIndex = 0;
            search_button.Text = "search";
            search_button.UseVisualStyleBackColor = true;
            search_button.Click += search_button_Click;
            // 
            // textBox_filePath
            // 
            textBox_filePath.Location = new Point(29, 134);
            textBox_filePath.Margin = new Padding(2, 2, 2, 2);
            textBox_filePath.Name = "textBox_filePath";
            textBox_filePath.Size = new Size(90, 23);
            textBox_filePath.TabIndex = 1;
            // 
            // output_box
            // 
            output_box.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            output_box.Location = new Point(216, 14);
            output_box.Margin = new Padding(2, 2, 2, 2);
            output_box.Multiline = true;
            output_box.Name = "output_box";
            output_box.ReadOnly = true;
            output_box.ScrollBars = ScrollBars.Both;
            output_box.Size = new Size(316, 234);
            output_box.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 117);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 3;
            label1.Text = "FilePath";
            // 
            // buttom_browse
            // 
            buttom_browse.Location = new Point(122, 134);
            buttom_browse.Margin = new Padding(2, 2, 2, 2);
            buttom_browse.Name = "buttom_browse";
            buttom_browse.Size = new Size(55, 23);
            buttom_browse.TabIndex = 4;
            buttom_browse.Text = "Browse";
            buttom_browse.UseVisualStyleBackColor = true;
            buttom_browse.Click += buttom_browse_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(29, 161);
            progressBar1.Margin = new Padding(2, 2, 2, 2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(148, 19);
            progressBar1.TabIndex = 5;
            // 
            // English
            // 
            English.AutoSize = true;
            English.BackColor = Color.Transparent;
            English.Location = new Point(29, 12);
            English.Margin = new Padding(2, 0, 2, 0);
            English.Name = "English";
            English.Size = new Size(45, 15);
            English.TabIndex = 6;
            English.TabStop = true;
            English.Text = "English";
            English.LinkClicked += English_LinkClicked;
            // 
            // Chinese
            // 
            Chinese.AutoSize = true;
            Chinese.BackColor = Color.Transparent;
            Chinese.Location = new Point(95, 12);
            Chinese.Margin = new Padding(2, 0, 2, 0);
            Chinese.Name = "Chinese";
            Chinese.Size = new Size(33, 15);
            Chinese.TabIndex = 7;
            Chinese.TabStop = true;
            Chinese.Text = "中文";
            Chinese.LinkClicked += Chinese_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(80, 12);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(10, 15);
            label2.TabIndex = 8;
            label2.Text = "|";
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(label2);
            Controls.Add(English);
            Controls.Add(Chinese);
            Controls.Add(progressBar1);
            Controls.Add(buttom_browse);
            Controls.Add(label1);
            Controls.Add(output_box);
            Controls.Add(textBox_filePath);
            Controls.Add(search_button);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "StellarisNanotechHelper";
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button search_button;
        private TextBox textBox_filePath;
        private TextBox output_box;
        private Label label1;
        private Button buttom_browse;
        private ProgressBar progressBar1;
        private LinkLabel English;
        private LinkLabel Chinese;
        private Label label2;
    }
}

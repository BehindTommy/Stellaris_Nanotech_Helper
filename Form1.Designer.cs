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
            SuspendLayout();
            // 
            // search_button
            // 
            search_button.Location = new Point(41, 62);
            search_button.Name = "search_button";
            search_button.Size = new Size(211, 111);
            search_button.TabIndex = 0;
            search_button.Text = "search";
            search_button.UseVisualStyleBackColor = true;
            search_button.Click += search_button_Click;
            // 
            // textBox_filePath
            // 
            textBox_filePath.Location = new Point(41, 194);
            textBox_filePath.Name = "textBox_filePath";
            textBox_filePath.Size = new Size(211, 31);
            textBox_filePath.TabIndex = 1;
            // 
            // output_box
            // 
            output_box.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            output_box.Location = new Point(309, 23);
            output_box.Multiline = true;
            output_box.Name = "output_box";
            output_box.ReadOnly = true;
            output_box.ScrollBars = ScrollBars.Both;
            output_box.Size = new Size(449, 388);
            output_box.TabIndex = 2;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(output_box);
            Controls.Add(textBox_filePath);
            Controls.Add(search_button);
            Name = "Form1";
            Text = "Form1";
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button search_button;
        private TextBox textBox_filePath;
        private TextBox output_box;
    }
}

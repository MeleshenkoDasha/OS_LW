namespace LR6_server
{
    partial class Server
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnColor1 = new Button();
            btnColor2 = new Button();
            btnColor3 = new Button();
            btnColor5 = new Button();
            btnColor6 = new Button();
            btnColor7 = new Button();
            btnColor8 = new Button();
            btnColor0 = new Button();
            btnColor4 = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            tbLogs = new TextBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 3, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel1.Location = new Point(-1, -1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 98F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.Size = new Size(784, 562);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 7;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel2.Controls.Add(btnColor1, 1, 1);
            tableLayoutPanel2.Controls.Add(btnColor2, 3, 1);
            tableLayoutPanel2.Controls.Add(btnColor3, 5, 1);
            tableLayoutPanel2.Controls.Add(btnColor5, 3, 3);
            tableLayoutPanel2.Controls.Add(btnColor6, 5, 3);
            tableLayoutPanel2.Controls.Add(btnColor7, 1, 5);
            tableLayoutPanel2.Controls.Add(btnColor8, 3, 5);
            tableLayoutPanel2.Controls.Add(btnColor0, 5, 5);
            tableLayoutPanel2.Controls.Add(btnColor4, 1, 3);
            tableLayoutPanel2.Location = new Point(252, 8);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            tableLayoutPanel2.Size = new Size(519, 544);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnColor1
            // 
            btnColor1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnColor1.BackColor = Color.Gray;
            btnColor1.Font = new Font("Cambria", 16.25F);
            btnColor1.Location = new Point(8, 8);
            btnColor1.Name = "btnColor1";
            btnColor1.Size = new Size(160, 168);
            btnColor1.TabIndex = 0;
            btnColor1.Text = "Изменить цвет на";
            btnColor1.UseVisualStyleBackColor = false;
            btnColor1.Click += btnColor1_Click;
            // 
            // btnColor2
            // 
            btnColor2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnColor2.BackColor = Color.Red;
            btnColor2.Font = new Font("Cambria", 16.25F);
            btnColor2.Location = new Point(179, 8);
            btnColor2.Name = "btnColor2";
            btnColor2.Size = new Size(160, 168);
            btnColor2.TabIndex = 1;
            btnColor2.Text = "Изменить цвет на";
            btnColor2.UseVisualStyleBackColor = false;
            btnColor2.Click += btnColor2_Click;
            // 
            // btnColor3
            // 
            btnColor3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnColor3.BackColor = Color.Orange;
            btnColor3.Font = new Font("Cambria", 16.25F);
            btnColor3.Location = new Point(350, 8);
            btnColor3.Name = "btnColor3";
            btnColor3.Size = new Size(160, 168);
            btnColor3.TabIndex = 2;
            btnColor3.Text = "Изменить цвет на";
            btnColor3.UseVisualStyleBackColor = false;
            btnColor3.Click += btnColor3_Click;
            // 
            // btnColor5
            // 
            btnColor5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnColor5.BackColor = Color.Green;
            btnColor5.Font = new Font("Cambria", 16.25F);
            btnColor5.Location = new Point(179, 187);
            btnColor5.Name = "btnColor5";
            btnColor5.Size = new Size(160, 168);
            btnColor5.TabIndex = 4;
            btnColor5.Text = "Изменить цвет на";
            btnColor5.UseVisualStyleBackColor = false;
            btnColor5.Click += btnColor5_Click;
            // 
            // btnColor6
            // 
            btnColor6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnColor6.BackColor = Color.Cyan;
            btnColor6.Font = new Font("Cambria", 16.25F);
            btnColor6.Location = new Point(350, 187);
            btnColor6.Name = "btnColor6";
            btnColor6.Size = new Size(160, 168);
            btnColor6.TabIndex = 5;
            btnColor6.Text = "Изменить цвет на";
            btnColor6.UseVisualStyleBackColor = false;
            btnColor6.Click += btnColor6_Click;
            // 
            // btnColor7
            // 
            btnColor7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnColor7.BackColor = Color.Blue;
            btnColor7.Font = new Font("Cambria", 16.25F);
            btnColor7.Location = new Point(8, 366);
            btnColor7.Name = "btnColor7";
            btnColor7.Size = new Size(160, 168);
            btnColor7.TabIndex = 6;
            btnColor7.Text = "Изменить цвет на";
            btnColor7.UseVisualStyleBackColor = false;
            btnColor7.Click += btnColor7_Click;
            // 
            // btnColor8
            // 
            btnColor8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnColor8.BackColor = Color.Purple;
            btnColor8.Font = new Font("Cambria", 16.25F);
            btnColor8.Location = new Point(179, 366);
            btnColor8.Name = "btnColor8";
            btnColor8.Size = new Size(160, 168);
            btnColor8.TabIndex = 7;
            btnColor8.Text = "Изменить цвет на";
            btnColor8.UseVisualStyleBackColor = false;
            btnColor8.Click += btnColor8_Click;
            // 
            // btnColor0
            // 
            btnColor0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnColor0.BackColor = Color.White;
            btnColor0.Font = new Font("Cambria", 16.25F);
            btnColor0.Location = new Point(350, 366);
            btnColor0.Name = "btnColor0";
            btnColor0.Size = new Size(160, 168);
            btnColor0.TabIndex = 8;
            btnColor0.Text = "Восстановить цвет";
            btnColor0.UseVisualStyleBackColor = false;
            btnColor0.Click += btnColor0_Click;
            // 
            // btnColor4
            // 
            btnColor4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnColor4.BackColor = Color.Yellow;
            btnColor4.Font = new Font("Cambria", 16.25F);
            btnColor4.Location = new Point(8, 187);
            btnColor4.Name = "btnColor4";
            btnColor4.Size = new Size(160, 168);
            btnColor4.TabIndex = 3;
            btnColor4.Text = "Изменить цвет на";
            btnColor4.UseVisualStyleBackColor = false;
            btnColor4.Click += btnColor4_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 98F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel3.Controls.Add(tbLogs, 1, 3);
            tableLayoutPanel3.Controls.Add(label1, 1, 1);
            tableLayoutPanel3.Location = new Point(10, 8);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 1.07526886F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 11.8279572F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 1.07526886F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 84.9462357F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 1.07526886F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(229, 544);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // tbLogs
            // 
            tbLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbLogs.Location = new Point(5, 77);
            tbLogs.Multiline = true;
            tbLogs.Name = "tbLogs";
            tbLogs.ReadOnly = true;
            tbLogs.Size = new Size(218, 456);
            tbLogs.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(5, 5);
            label1.Name = "label1";
            label1.Size = new Size(218, 64);
            label1.TabIndex = 5;
            label1.Text = "Работа сервера";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(tableLayoutPanel1);
            Name = "Server";
            Text = "Сервер";
            Load += Server_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnColor1;
        private Button btnColor2;
        private Button btnColor3;
        private Button btnColor4;
        private Button btnColor5;
        private Button btnColor6;
        private Button btnColor7;
        private Button btnColor8;
        private Button btnColor0;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        public TextBox tbLogs;
    }
}

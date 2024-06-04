namespace LR6_client
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnConnect = new Button();
            label2 = new Label();
            cb_listAdress = new ComboBox();
            tbLogs = new TextBox();
            lbl_change_color = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(lbl_change_color, 3, 1);
            tableLayoutPanel1.Location = new Point(1, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 98F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            tableLayoutPanel1.Size = new Size(883, 610);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 98F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            tableLayoutPanel2.Controls.Add(btnConnect, 1, 5);
            tableLayoutPanel2.Controls.Add(label2, 1, 1);
            tableLayoutPanel2.Controls.Add(cb_listAdress, 1, 3);
            tableLayoutPanel2.Controls.Add(tbLogs, 1, 8);
            tableLayoutPanel2.Location = new Point(11, 9);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 10;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 1.14942527F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.6436777F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 1.14942527F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.045977F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 1.14942527F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.9425287F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 1.14942527F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 1.14942527F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 57.4712639F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 1.14942527F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel2.Size = new Size(303, 591);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnConnect.Font = new Font("Cambria", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnConnect.Location = new Point(6, 142);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(290, 82);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Подключиться к серверу";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(6, 6);
            label2.Name = "label2";
            label2.Size = new Size(290, 74);
            label2.TabIndex = 1;
            label2.Text = "Адрес сервера";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cb_listAdress
            // 
            cb_listAdress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cb_listAdress.Font = new Font("Cambria", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cb_listAdress.FormattingEnabled = true;
            cb_listAdress.Items.AddRange(new object[] { "127.0.0.1" });
            cb_listAdress.Location = new Point(6, 89);
            cb_listAdress.Name = "cb_listAdress";
            cb_listAdress.Size = new Size(290, 36);
            cb_listAdress.TabIndex = 2;
            // 
            // tbLogs
            // 
            tbLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbLogs.Location = new Point(6, 242);
            tbLogs.Multiline = true;
            tbLogs.Name = "tbLogs";
            tbLogs.ReadOnly = true;
            tbLogs.Size = new Size(290, 333);
            tbLogs.TabIndex = 3;
            // 
            // lbl_change_color
            // 
            lbl_change_color.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_change_color.AutoSize = true;
            lbl_change_color.BackColor = Color.White;
            lbl_change_color.Font = new Font("Cambria", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbl_change_color.Location = new Point(328, 6);
            lbl_change_color.Name = "lbl_change_color";
            lbl_change_color.Size = new Size(541, 597);
            lbl_change_color.TabIndex = 0;
            lbl_change_color.Text = resources.GetString("lbl_change_color.Text");
            lbl_change_color.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 611);
            Controls.Add(tableLayoutPanel1);
            Name = "Client";
            Text = "Клиент";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lbl_change_color;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnConnect;
        private Label label2;
        private ComboBox cb_listAdress;
        private TextBox tbLogs;
    }
}

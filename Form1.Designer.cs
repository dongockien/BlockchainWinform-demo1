namespace BlockchainWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnTamper;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cboBlockIndex;
        private System.Windows.Forms.TextBox txtTamperData;
        private System.Windows.Forms.RichTextBox rtbBlocks;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSelectBlock;
        private System.Windows.Forms.Label lblNewData;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnTamper = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cboBlockIndex = new System.Windows.Forms.ComboBox();
            this.txtTamperData = new System.Windows.Forms.TextBox();
            this.rtbBlocks = new System.Windows.Forms.RichTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSelectBlock = new System.Windows.Forms.Label();
            this.lblNewData = new System.Windows.Forms.Label();

            // Form1
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(750, 380);
            this.Name = "Form1";
            this.Text = "Blockchain Demo (WinForms)";
            this.Controls.Add(this.lblSelectBlock);
            this.Controls.Add(this.lblNewData);
            this.Controls.Add(this.cboBlockIndex);
            this.Controls.Add(this.txtTamperData);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnTamper);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.rtbBlocks);
            this.Controls.Add(this.lblStatus);

            // btnGenerate
            this.btnGenerate.Location = new System.Drawing.Point(30, 20);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 30);
            this.btnGenerate.Text = "Tạo Blockchain";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            // cboBlockIndex
            this.cboBlockIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBlockIndex.Location = new System.Drawing.Point(30, 80);
            this.cboBlockIndex.Name = "cboBlockIndex";
            this.cboBlockIndex.Size = new System.Drawing.Size(150, 24);

            // txtTamperData
            this.txtTamperData.Location = new System.Drawing.Point(30, 130);
            this.txtTamperData.Name = "txtTamperData";
            this.txtTamperData.Size = new System.Drawing.Size(150, 22);

            // btnTamper
            this.btnTamper.Location = new System.Drawing.Point(30, 170);
            this.btnTamper.Name = "btnTamper";
            this.btnTamper.Size = new System.Drawing.Size(150, 30);
            this.btnTamper.Text = "Sửa dữ liệu";
            this.btnTamper.UseVisualStyleBackColor = true;
            this.btnTamper.Click += new System.EventHandler(this.btnTamper_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(30, 220);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 30);
            this.btnUpdate.Text = "Cập nhật chuỗi";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdateChain_Click);


            // rtbBlocks
            this.rtbBlocks.Location = new System.Drawing.Point(220, 20);
            this.rtbBlocks.Name = "rtbBlocks";
            this.rtbBlocks.ReadOnly = true;
            this.rtbBlocks.Size = new System.Drawing.Size(500, 260);
            this.rtbBlocks.Font = new System.Drawing.Font("Consolas", 10);
            this.rtbBlocks.BackColor = System.Drawing.Color.White;
            this.rtbBlocks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(220, 300);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 16);
            this.lblStatus.Text = "Trạng thái chuỗi:";

            // lblSelectBlock
            this.lblSelectBlock.AutoSize = true;
            this.lblSelectBlock.Location = new System.Drawing.Point(30, 60);
            this.lblSelectBlock.Name = "lblSelectBlock";
            this.lblSelectBlock.Size = new System.Drawing.Size(92, 16);
            this.lblSelectBlock.Text = "Chọn block:";

            // lblNewData
            this.lblNewData.AutoSize = true;
            this.lblNewData.Location = new System.Drawing.Point(30, 110);
            this.lblNewData.Name = "lblNewData";
            this.lblNewData.Size = new System.Drawing.Size(84, 16);
            this.lblNewData.Text = "Dữ liệu mới:";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

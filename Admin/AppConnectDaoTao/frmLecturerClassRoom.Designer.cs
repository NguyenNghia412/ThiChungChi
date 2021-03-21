namespace AppConnectDaoTao
{
    partial class frmLecturerClassRoom
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
            this.btnCUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLecturerCode = new System.Windows.Forms.TextBox();
            this.txtClassRoomCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCUpdate
            // 
            this.btnCUpdate.Location = new System.Drawing.Point(88, 81);
            this.btnCUpdate.Name = "btnCUpdate";
            this.btnCUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnCUpdate.TabIndex = 0;
            this.btnCUpdate.Text = "CUpdate";
            this.btnCUpdate.UseVisualStyleBackColor = true;
            this.btnCUpdate.Click += new System.EventHandler(this.btnCUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "LecturerCode";
            // 
            // txtLecturerCode
            // 
            this.txtLecturerCode.Location = new System.Drawing.Point(88, 29);
            this.txtLecturerCode.Name = "txtLecturerCode";
            this.txtLecturerCode.Size = new System.Drawing.Size(116, 20);
            this.txtLecturerCode.TabIndex = 2;
            // 
            // txtClassRoomCode
            // 
            this.txtClassRoomCode.Location = new System.Drawing.Point(88, 55);
            this.txtClassRoomCode.Name = "txtClassRoomCode";
            this.txtClassRoomCode.Size = new System.Drawing.Size(116, 20);
            this.txtClassRoomCode.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ClassRoomCode";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtClassRoomCode);
            this.groupBox1.Controls.Add(this.btnCUpdate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLecturerCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 110);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CapNhatHienTai";
            // 
            // frmLecturerClassRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 261);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLecturerClassRoom";
            this.Text = "frmLecturerClassRoom";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLecturerCode;
        private System.Windows.Forms.TextBox txtClassRoomCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
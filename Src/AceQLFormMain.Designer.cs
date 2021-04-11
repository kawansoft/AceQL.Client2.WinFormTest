/*
 * This filePath is part of AceQL C# Client SDK.
 * AceQL C# Client SDK: Remote SQL access over HTTP with AceQL HTTP.                                 
 * Copyright (C) 2020,  KawanSoft SAS
 * (http://www.kawansoft.com). All rights reserved.                                
 *                                                                               
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this filePath except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License. 
 */
namespace AceQL.Client.WinFormTest
{
    partial class AceQLFormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AceQLFormMain));
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.labelBlob = new System.Windows.Forms.Label();
            this.buttonInsertBlob = new System.Windows.Forms.Button();
            this.buttonSelectBlob = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonConnect.Location = new System.Drawing.Point(107, 125);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 27);
            this.buttonConnect.TabIndex = 9;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomer.Location = new System.Drawing.Point(99, 186);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(91, 24);
            this.labelCustomer.TabIndex = 13;
            this.labelCustomer.Text = "Customer";
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(154, 225);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 15;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_ClickAsync);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(60, 225);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(75, 23);
            this.buttonInsert.TabIndex = 14;
            this.buttonInsert.Text = "Insert";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_ClickAsync);
            // 
            // labelBlob
            // 
            this.labelBlob.AutoSize = true;
            this.labelBlob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBlob.Location = new System.Drawing.Point(120, 280);
            this.labelBlob.Name = "labelBlob";
            this.labelBlob.Size = new System.Drawing.Size(48, 24);
            this.labelBlob.TabIndex = 16;
            this.labelBlob.Text = "Blob";
            // 
            // buttonInsertBlob
            // 
            this.buttonInsertBlob.Location = new System.Drawing.Point(60, 318);
            this.buttonInsertBlob.Name = "buttonInsertBlob";
            this.buttonInsertBlob.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertBlob.TabIndex = 17;
            this.buttonInsertBlob.Text = "Insert";
            this.buttonInsertBlob.UseVisualStyleBackColor = true;
            this.buttonInsertBlob.Click += new System.EventHandler(this.buttonInsertBlob_ClickAsync);
            // 
            // buttonSelectBlob
            // 
            this.buttonSelectBlob.Location = new System.Drawing.Point(154, 318);
            this.buttonSelectBlob.Name = "buttonSelectBlob";
            this.buttonSelectBlob.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectBlob.TabIndex = 18;
            this.buttonSelectBlob.Text = "Select";
            this.buttonSelectBlob.UseVisualStyleBackColor = true;
            this.buttonSelectBlob.Click += new System.EventHandler(this.buttonSelectBlob_ClickAsync);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionStatus.Image = global::AceQL.Client2.WinFormTest.Properties.Resources.bullet_ball_red;
            this.labelConnectionStatus.Location = new System.Drawing.Point(190, 124);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(19, 29);
            this.labelConnectionStatus.TabIndex = 19;
            this.labelConnectionStatus.Text = " ";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(125, 396);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(29, 15);
            this.labelVersion.TabIndex = 20;
            this.labelVersion.Text = "v1.0";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AceQL.Client2.WinFormTest.Properties.Resources.aceql_narrow;
            this.pictureBox1.Location = new System.Drawing.Point(29, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // AceQLFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 420);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.buttonSelectBlob);
            this.Controls.Add(this.buttonInsertBlob);
            this.Controls.Add(this.labelBlob);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AceQLFormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AceQL Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Label labelBlob;
        private System.Windows.Forms.Button buttonInsertBlob;
        private System.Windows.Forms.Button buttonSelectBlob;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Label labelVersion;
    }
}


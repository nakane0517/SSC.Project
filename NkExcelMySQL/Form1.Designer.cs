namespace ExcelDB
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.EndColumn = new System.Windows.Forms.TextBox();
            this.LogPath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.EndRow = new System.Windows.Forms.TextBox();
            this.StartColumn = new System.Windows.Forms.TextBox();
            this.StartRow = new System.Windows.Forms.TextBox();
            this.TableName1 = new System.Windows.Forms.TextBox();
            this.SheetNo = new System.Windows.Forms.TextBox();
            this.DbFilePath1 = new System.Windows.Forms.TextBox();
            this.ExFilePath1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ExFilePath2 = new System.Windows.Forms.TextBox();
            this.DbFilePath2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SheetNo2 = new System.Windows.Forms.TextBox();
            this.TableName2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel ファイルパス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "シート番号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "開始行";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "終了行";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "開始列";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "終了列";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.EndColumn);
            this.groupBox1.Controls.Add(this.LogPath);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.EndRow);
            this.groupBox1.Controls.Add(this.StartColumn);
            this.groupBox1.Controls.Add(this.StartRow);
            this.groupBox1.Controls.Add(this.TableName1);
            this.groupBox1.Controls.Add(this.SheetNo);
            this.groupBox1.Controls.Add(this.DbFilePath1);
            this.groupBox1.Controls.Add(this.ExFilePath1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(28, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "【 Excel から MySQL に変換 】";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(37, 229);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 21);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "ログ出力";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(506, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 30);
            this.button2.TabIndex = 13;
            this.button2.Text = "開  始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(568, 226);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(43, 21);
            this.button8.TabIndex = 12;
            this.button8.Text = "File";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(568, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EndColumn
            // 
            this.EndColumn.Location = new System.Drawing.Point(367, 110);
            this.EndColumn.Name = "EndColumn";
            this.EndColumn.Size = new System.Drawing.Size(83, 24);
            this.EndColumn.TabIndex = 6;
            this.EndColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LogPath
            // 
            this.LogPath.Location = new System.Drawing.Point(167, 226);
            this.LogPath.Name = "LogPath";
            this.LogPath.Size = new System.Drawing.Size(365, 24);
            this.LogPath.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 141);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "DB 名";
            // 
            // EndRow
            // 
            this.EndRow.Location = new System.Drawing.Point(366, 82);
            this.EndRow.Name = "EndRow";
            this.EndRow.Size = new System.Drawing.Size(83, 24);
            this.EndRow.TabIndex = 4;
            this.EndRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartColumn
            // 
            this.StartColumn.Location = new System.Drawing.Point(169, 110);
            this.StartColumn.Name = "StartColumn";
            this.StartColumn.Size = new System.Drawing.Size(83, 24);
            this.StartColumn.TabIndex = 5;
            this.StartColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartRow
            // 
            this.StartRow.Location = new System.Drawing.Point(168, 82);
            this.StartRow.Name = "StartRow";
            this.StartRow.Size = new System.Drawing.Size(83, 24);
            this.StartRow.TabIndex = 3;
            this.StartRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TableName1
            // 
            this.TableName1.Location = new System.Drawing.Point(169, 166);
            this.TableName1.Name = "TableName1";
            this.TableName1.Size = new System.Drawing.Size(200, 24);
            this.TableName1.TabIndex = 9;
            // 
            // SheetNo
            // 
            this.SheetNo.Location = new System.Drawing.Point(167, 54);
            this.SheetNo.Name = "SheetNo";
            this.SheetNo.Size = new System.Drawing.Size(83, 24);
            this.SheetNo.TabIndex = 2;
            this.SheetNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DbFilePath1
            // 
            this.DbFilePath1.Location = new System.Drawing.Point(169, 138);
            this.DbFilePath1.Name = "DbFilePath1";
            this.DbFilePath1.Size = new System.Drawing.Size(365, 24);
            this.DbFilePath1.TabIndex = 7;
            // 
            // ExFilePath1
            // 
            this.ExFilePath1.Location = new System.Drawing.Point(168, 26);
            this.ExFilePath1.Name = "ExFilePath1";
            this.ExFilePath1.Size = new System.Drawing.Size(365, 24);
            this.ExFilePath1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 199);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(299, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "（テーブルが存在する時は上書きされます。）";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 169);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "テーブル名";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 33);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "DB 名";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(565, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 21);
            this.button3.TabIndex = 5;
            this.button3.Text = "File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.ExFilePath2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.DbFilePath2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.SheetNo2);
            this.groupBox2.Controls.Add(this.TableName2);
            this.groupBox2.Location = new System.Drawing.Point(31, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(632, 193);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "【 MySQL から Excel に変換 】";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(504, 147);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 30);
            this.button5.TabIndex = 7;
            this.button5.Text = "開  始";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 135);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "シート番号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 101);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Excel ファイルパス";
            // 
            // ExFilePath2
            // 
            this.ExFilePath2.Location = new System.Drawing.Point(164, 98);
            this.ExFilePath2.Name = "ExFilePath2";
            this.ExFilePath2.Size = new System.Drawing.Size(365, 24);
            this.ExFilePath2.TabIndex = 4;
            // 
            // DbFilePath2
            // 
            this.DbFilePath2.Location = new System.Drawing.Point(166, 30);
            this.DbFilePath2.Name = "DbFilePath2";
            this.DbFilePath2.Size = new System.Drawing.Size(365, 24);
            this.DbFilePath2.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(61, 72);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "テーブル名";
            // 
            // SheetNo2
            // 
            this.SheetNo2.Location = new System.Drawing.Point(164, 132);
            this.SheetNo2.Name = "SheetNo2";
            this.SheetNo2.Size = new System.Drawing.Size(83, 24);
            this.SheetNo2.TabIndex = 6;
            this.SheetNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TableName2
            // 
            this.TableName2.Location = new System.Drawing.Point(165, 65);
            this.TableName2.Name = "TableName2";
            this.TableName2.Size = new System.Drawing.Size(200, 24);
            this.TableName2.TabIndex = 3;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(667, 560);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(105, 30);
            this.button6.TabIndex = 2;
            this.button6.Text = "終  了";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(213, 575);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(248, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "Copyright 2018 Takayasu Nakane";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 600);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Excel MySQL 相互変換";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox EndColumn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox EndRow;
        private System.Windows.Forms.TextBox StartColumn;
        private System.Windows.Forms.TextBox StartRow;
        private System.Windows.Forms.TextBox TableName1;
        private System.Windows.Forms.TextBox SheetNo;
        private System.Windows.Forms.TextBox DbFilePath1;
        private System.Windows.Forms.TextBox ExFilePath1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ExFilePath2;
        private System.Windows.Forms.TextBox DbFilePath2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TableName2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox SheetNo2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox LogPath;
        private System.Windows.Forms.Button button8;
    }
}


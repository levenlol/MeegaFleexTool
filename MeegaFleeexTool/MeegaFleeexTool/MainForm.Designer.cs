namespace MeegaFleeexTool
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.downloadButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lunEntrataTextBox = new System.Windows.Forms.TextBox();
            this.lunUscitaTextBox = new System.Windows.Forms.TextBox();
            this.marUscitaTextBox = new System.Windows.Forms.TextBox();
            this.marEntrataTextBox = new System.Windows.Forms.TextBox();
            this.merUscitaTextBox = new System.Windows.Forms.TextBox();
            this.merEntrataTextBox = new System.Windows.Forms.TextBox();
            this.gioUscitaTextBox = new System.Windows.Forms.TextBox();
            this.gioEntrataTextBox = new System.Windows.Forms.TextBox();
            this.venUscitaTextBox = new System.Windows.Forms.TextBox();
            this.venEntrataTextBox = new System.Windows.Forms.TextBox();
            this.fifthDay = new System.Windows.Forms.TextBox();
            this.fourthDay = new System.Windows.Forms.TextBox();
            this.thirdDay = new System.Windows.Forms.TextBox();
            this.secondDay = new System.Windows.Forms.TextBox();
            this.firstDay = new System.Windows.Forms.TextBox();
            this.computeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.venDiffTextBox = new System.Windows.Forms.TextBox();
            this.gioDiffTextBox = new System.Windows.Forms.TextBox();
            this.merDiffTextBox = new System.Windows.Forms.TextBox();
            this.marDiffTextBox = new System.Windows.Forms.TextBox();
            this.lunDiffTextBox = new System.Windows.Forms.TextBox();
            this.totalDiffTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.venROLTextBox = new System.Windows.Forms.TextBox();
            this.gioROLTextBox = new System.Windows.Forms.TextBox();
            this.merROLTextBox = new System.Windows.Forms.TextBox();
            this.marROLTextBox = new System.Windows.Forms.TextBox();
            this.lunROLTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.venRitardoTextBox = new System.Windows.Forms.TextBox();
            this.gioRitardoTextBox = new System.Windows.Forms.TextBox();
            this.merRitardoTextBox = new System.Windows.Forms.TextBox();
            this.marRitardoTextBox = new System.Windows.Forms.TextBox();
            this.lunRitardoTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();

            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(3, 35);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(76, 23);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.resultTextBox.Location = new System.Drawing.Point(194, 38);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(541, 20);
            this.resultTextBox.TabIndex = 1;
            this.resultTextBox.Text = "Waiting...";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lunEntrataTextBox
            // 
            this.lunEntrataTextBox.Location = new System.Drawing.Point(194, 97);
            this.lunEntrataTextBox.Name = "lunEntrataTextBox";
            this.lunEntrataTextBox.Size = new System.Drawing.Size(52, 20);
            this.lunEntrataTextBox.TabIndex = 2;
            // 
            // lunUscitaTextBox
            // 
            this.lunUscitaTextBox.Location = new System.Drawing.Point(286, 97);
            this.lunUscitaTextBox.Name = "lunUscitaTextBox";
            this.lunUscitaTextBox.Size = new System.Drawing.Size(52, 20);
            this.lunUscitaTextBox.TabIndex = 3;
            // 
            // marUscitaTextBox
            // 
            this.marUscitaTextBox.Location = new System.Drawing.Point(286, 139);
            this.marUscitaTextBox.Name = "marUscitaTextBox";
            this.marUscitaTextBox.Size = new System.Drawing.Size(52, 20);
            this.marUscitaTextBox.TabIndex = 5;
            // 
            // marEntrataTextBox
            // 
            this.marEntrataTextBox.Location = new System.Drawing.Point(194, 139);
            this.marEntrataTextBox.Name = "marEntrataTextBox";
            this.marEntrataTextBox.Size = new System.Drawing.Size(52, 20);
            this.marEntrataTextBox.TabIndex = 4;
            // 
            // merUscitaTextBox
            // 
            this.merUscitaTextBox.Location = new System.Drawing.Point(286, 183);
            this.merUscitaTextBox.Name = "merUscitaTextBox";
            this.merUscitaTextBox.Size = new System.Drawing.Size(52, 20);
            this.merUscitaTextBox.TabIndex = 7;
            // 
            // merEntrataTextBox
            // 
            this.merEntrataTextBox.Location = new System.Drawing.Point(194, 183);
            this.merEntrataTextBox.Name = "merEntrataTextBox";
            this.merEntrataTextBox.Size = new System.Drawing.Size(52, 20);
            this.merEntrataTextBox.TabIndex = 6;
            // 
            // gioUscitaTextBox
            // 
            this.gioUscitaTextBox.Location = new System.Drawing.Point(286, 225);
            this.gioUscitaTextBox.Name = "gioUscitaTextBox";
            this.gioUscitaTextBox.Size = new System.Drawing.Size(52, 20);
            this.gioUscitaTextBox.TabIndex = 9;
            // 
            // gioEntrataTextBox
            // 
            this.gioEntrataTextBox.Location = new System.Drawing.Point(194, 225);
            this.gioEntrataTextBox.Name = "gioEntrataTextBox";
            this.gioEntrataTextBox.Size = new System.Drawing.Size(52, 20);
            this.gioEntrataTextBox.TabIndex = 8;
            // 
            // venUscitaTextBox
            // 
            this.venUscitaTextBox.Location = new System.Drawing.Point(286, 270);
            this.venUscitaTextBox.Name = "venUscitaTextBox";
            this.venUscitaTextBox.Size = new System.Drawing.Size(52, 20);
            this.venUscitaTextBox.TabIndex = 11;
            // 
            // venEntrataTextBox
            // 
            this.venEntrataTextBox.Location = new System.Drawing.Point(194, 270);
            this.venEntrataTextBox.Name = "venEntrataTextBox";
            this.venEntrataTextBox.Size = new System.Drawing.Size(52, 20);
            this.venEntrataTextBox.TabIndex = 10;
            // 
            // fifthDay
            // 
            this.fifthDay.Location = new System.Drawing.Point(110, 270);
            this.fifthDay.Name = "fifthDay";
            this.fifthDay.ReadOnly = true;
            this.fifthDay.Size = new System.Drawing.Size(32, 20);
            this.fifthDay.TabIndex = 21;
            this.fifthDay.Text = "0";
            // 
            // fourthDay
            // 
            this.fourthDay.Location = new System.Drawing.Point(110, 225);
            this.fourthDay.Name = "fourthDay";
            this.fourthDay.ReadOnly = true;
            this.fourthDay.Size = new System.Drawing.Size(32, 20);
            this.fourthDay.TabIndex = 20;
            this.fourthDay.Text = "0";
            // 
            // thirdDay
            // 
            this.thirdDay.Location = new System.Drawing.Point(110, 183);
            this.thirdDay.Name = "thirdDay";
            this.thirdDay.ReadOnly = true;
            this.thirdDay.Size = new System.Drawing.Size(32, 20);
            this.thirdDay.TabIndex = 19;
            this.thirdDay.Text = "0";
            // 
            // secondDay
            // 
            this.secondDay.Location = new System.Drawing.Point(110, 139);
            this.secondDay.Name = "secondDay";
            this.secondDay.ReadOnly = true;
            this.secondDay.Size = new System.Drawing.Size(32, 20);
            this.secondDay.TabIndex = 18;
            this.secondDay.Text = "0";
            // 
            // firstDay
            // 
            this.firstDay.Location = new System.Drawing.Point(110, 97);
            this.firstDay.Name = "firstDay";
            this.firstDay.ReadOnly = true;
            this.firstDay.Size = new System.Drawing.Size(32, 20);
            this.firstDay.TabIndex = 17;
            this.firstDay.Text = "0";
            // 
            // computeButton
            // 
            this.computeButton.Location = new System.Drawing.Point(97, 35);
            this.computeButton.Name = "computeButton";
            this.computeButton.Size = new System.Drawing.Size(75, 23);
            this.computeButton.TabIndex = 22;
            this.computeButton.Text = "Compute";
            this.computeButton.UseVisualStyleBackColor = true;
            this.computeButton.Click += new System.EventHandler(this.computeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Entrata:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Uscita:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Diff:";
            // 
            // venDiffTextBox
            // 
            this.venDiffTextBox.Location = new System.Drawing.Point(526, 270);
            this.venDiffTextBox.Name = "venDiffTextBox";
            this.venDiffTextBox.ReadOnly = true;
            this.venDiffTextBox.Size = new System.Drawing.Size(52, 20);
            this.venDiffTextBox.TabIndex = 29;
            // 
            // gioDiffTextBox
            // 
            this.gioDiffTextBox.Location = new System.Drawing.Point(526, 225);
            this.gioDiffTextBox.Name = "gioDiffTextBox";
            this.gioDiffTextBox.ReadOnly = true;
            this.gioDiffTextBox.Size = new System.Drawing.Size(52, 20);
            this.gioDiffTextBox.TabIndex = 28;
            // 
            // merDiffTextBox
            // 
            this.merDiffTextBox.Location = new System.Drawing.Point(526, 183);
            this.merDiffTextBox.Name = "merDiffTextBox";
            this.merDiffTextBox.ReadOnly = true;
            this.merDiffTextBox.Size = new System.Drawing.Size(52, 20);
            this.merDiffTextBox.TabIndex = 27;
            // 
            // marDiffTextBox
            // 
            this.marDiffTextBox.Location = new System.Drawing.Point(526, 139);
            this.marDiffTextBox.Name = "marDiffTextBox";
            this.marDiffTextBox.ReadOnly = true;
            this.marDiffTextBox.Size = new System.Drawing.Size(52, 20);
            this.marDiffTextBox.TabIndex = 26;
            // 
            // lunDiffTextBox
            // 
            this.lunDiffTextBox.Location = new System.Drawing.Point(526, 97);
            this.lunDiffTextBox.Name = "lunDiffTextBox";
            this.lunDiffTextBox.ReadOnly = true;
            this.lunDiffTextBox.Size = new System.Drawing.Size(52, 20);
            this.lunDiffTextBox.TabIndex = 25;
            // 
            // totalDiffTextBox
            // 
            this.totalDiffTextBox.Location = new System.Drawing.Point(526, 319);
            this.totalDiffTextBox.Name = "totalDiffTextBox";
            this.totalDiffTextBox.ReadOnly = true;
            this.totalDiffTextBox.Size = new System.Drawing.Size(52, 20);
            this.totalDiffTextBox.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(523, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Ferie/ROL:";
            // 
            // venROLTextBox
            // 
            this.venROLTextBox.Location = new System.Drawing.Point(373, 270);
            this.venROLTextBox.Name = "venROLTextBox";
            this.venROLTextBox.Size = new System.Drawing.Size(52, 20);
            this.venROLTextBox.TabIndex = 37;
            // 
            // gioROLTextBox
            // 
            this.gioROLTextBox.Location = new System.Drawing.Point(373, 225);
            this.gioROLTextBox.Name = "gioROLTextBox";
            this.gioROLTextBox.Size = new System.Drawing.Size(52, 20);
            this.gioROLTextBox.TabIndex = 36;
            // 
            // merROLTextBox
            // 
            this.merROLTextBox.Location = new System.Drawing.Point(373, 183);
            this.merROLTextBox.Name = "merROLTextBox";
            this.merROLTextBox.Size = new System.Drawing.Size(52, 20);
            this.merROLTextBox.TabIndex = 35;
            // 
            // marROLTextBox
            // 
            this.marROLTextBox.Location = new System.Drawing.Point(373, 139);
            this.marROLTextBox.Name = "marROLTextBox";
            this.marROLTextBox.Size = new System.Drawing.Size(52, 20);
            this.marROLTextBox.TabIndex = 34;
            // 
            // lunROLTextBox
            // 
            this.lunROLTextBox.Location = new System.Drawing.Point(373, 97);
            this.lunROLTextBox.Name = "lunROLTextBox";
            this.lunROLTextBox.Size = new System.Drawing.Size(52, 20);
            this.lunROLTextBox.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Ritardo:";
            // 
            // venRitardoTextBox
            // 
            this.venRitardoTextBox.Location = new System.Drawing.Point(450, 270);
            this.venRitardoTextBox.Name = "venRitardoTextBox";
            this.venRitardoTextBox.Size = new System.Drawing.Size(52, 20);
            this.venRitardoTextBox.TabIndex = 43;
            // 
            // gioRitardoTextBox
            // 
            this.gioRitardoTextBox.Location = new System.Drawing.Point(450, 225);
            this.gioRitardoTextBox.Name = "gioRitardoTextBox";
            this.gioRitardoTextBox.Size = new System.Drawing.Size(52, 20);
            this.gioRitardoTextBox.TabIndex = 42;
            // 
            // merRitardoTextBox
            // 
            this.merRitardoTextBox.Location = new System.Drawing.Point(450, 183);
            this.merRitardoTextBox.Name = "merRitardoTextBox";
            this.merRitardoTextBox.Size = new System.Drawing.Size(52, 20);
            this.merRitardoTextBox.TabIndex = 41;
            // 
            // marRitardoTextBox
            // 
            this.marRitardoTextBox.Location = new System.Drawing.Point(450, 139);
            this.marRitardoTextBox.Name = "marRitardoTextBox";
            this.marRitardoTextBox.Size = new System.Drawing.Size(52, 20);
            this.marRitardoTextBox.TabIndex = 40;
            // 
            // lunRitardoTextBox
            // 
            this.lunRitardoTextBox.Location = new System.Drawing.Point(450, 97);
            this.lunRitardoTextBox.Name = "lunRitardoTextBox";
            this.lunRitardoTextBox.Size = new System.Drawing.Size(52, 20);
            this.lunRitardoTextBox.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "lun.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "mar.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(148, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "mer.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "gio.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(148, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "ven.";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(97, 9);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 50;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.venRitardoTextBox);
            this.Controls.Add(this.gioRitardoTextBox);
            this.Controls.Add(this.merRitardoTextBox);
            this.Controls.Add(this.marRitardoTextBox);
            this.Controls.Add(this.lunRitardoTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.venROLTextBox);
            this.Controls.Add(this.gioROLTextBox);
            this.Controls.Add(this.merROLTextBox);
            this.Controls.Add(this.marROLTextBox);
            this.Controls.Add(this.lunROLTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalDiffTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.venDiffTextBox);
            this.Controls.Add(this.gioDiffTextBox);
            this.Controls.Add(this.merDiffTextBox);
            this.Controls.Add(this.marDiffTextBox);
            this.Controls.Add(this.lunDiffTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.computeButton);
            this.Controls.Add(this.fifthDay);
            this.Controls.Add(this.fourthDay);
            this.Controls.Add(this.thirdDay);
            this.Controls.Add(this.secondDay);
            this.Controls.Add(this.firstDay);
            this.Controls.Add(this.venUscitaTextBox);
            this.Controls.Add(this.venEntrataTextBox);
            this.Controls.Add(this.gioUscitaTextBox);
            this.Controls.Add(this.gioEntrataTextBox);
            this.Controls.Add(this.merUscitaTextBox);
            this.Controls.Add(this.merEntrataTextBox);
            this.Controls.Add(this.marUscitaTextBox);
            this.Controls.Add(this.marEntrataTextBox);
            this.Controls.Add(this.lunUscitaTextBox);
            this.Controls.Add(this.lunEntrataTextBox);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.downloadButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Meega Fleeeex Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        public System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox lunEntrataTextBox;
        private System.Windows.Forms.TextBox lunUscitaTextBox;
        private System.Windows.Forms.TextBox marUscitaTextBox;
        private System.Windows.Forms.TextBox marEntrataTextBox;
        private System.Windows.Forms.TextBox merUscitaTextBox;
        private System.Windows.Forms.TextBox merEntrataTextBox;
        private System.Windows.Forms.TextBox gioUscitaTextBox;
        private System.Windows.Forms.TextBox gioEntrataTextBox;
        private System.Windows.Forms.TextBox venUscitaTextBox;
        private System.Windows.Forms.TextBox venEntrataTextBox;
        private System.Windows.Forms.TextBox fifthDay;
        private System.Windows.Forms.TextBox fourthDay;
        private System.Windows.Forms.TextBox thirdDay;
        private System.Windows.Forms.TextBox secondDay;
        private System.Windows.Forms.TextBox firstDay;
        private System.Windows.Forms.Button computeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox venDiffTextBox;
        private System.Windows.Forms.TextBox gioDiffTextBox;
        private System.Windows.Forms.TextBox merDiffTextBox;
        private System.Windows.Forms.TextBox marDiffTextBox;
        private System.Windows.Forms.TextBox lunDiffTextBox;
        private System.Windows.Forms.TextBox totalDiffTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox venROLTextBox;
        private System.Windows.Forms.TextBox gioROLTextBox;
        private System.Windows.Forms.TextBox merROLTextBox;
        private System.Windows.Forms.TextBox marROLTextBox;
        private System.Windows.Forms.TextBox lunROLTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox venRitardoTextBox;
        private System.Windows.Forms.TextBox gioRitardoTextBox;
        private System.Windows.Forms.TextBox merRitardoTextBox;
        private System.Windows.Forms.TextBox marRitardoTextBox;
        private System.Windows.Forms.TextBox lunRitardoTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}


namespace Gk3
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.savePolylineButton = new System.Windows.Forms.Button();
            this.loadPolylineButton = new System.Windows.Forms.Button();
            this.stopAnimationButton = new System.Windows.Forms.Button();
            this.startAnimationButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.moovingOnTheCurveRadioButton = new System.Windows.Forms.RadioButton();
            this.RotationRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rotationWithFilteringRadioButton = new System.Windows.Forms.RadioButton();
            this.naivRotationRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadImage = new System.Windows.Forms.Button();
            this.imageOnBezierCurveImageBox = new System.Windows.Forms.PictureBox();
            this.visiblePolylineCheckBox = new System.Windows.Forms.CheckBox();
            this.generatePolylineButton = new System.Windows.Forms.Button();
            this.pointsNumberPolylineTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageOnBezierCurveImageBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.savePolylineButton);
            this.panel1.Controls.Add(this.loadPolylineButton);
            this.panel1.Controls.Add(this.stopAnimationButton);
            this.panel1.Controls.Add(this.startAnimationButton);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.visiblePolylineCheckBox);
            this.panel1.Controls.Add(this.generatePolylineButton);
            this.panel1.Controls.Add(this.pointsNumberPolylineTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 607);
            this.panel1.TabIndex = 0;
            // 
            // savePolylineButton
            // 
            this.savePolylineButton.Location = new System.Drawing.Point(109, 143);
            this.savePolylineButton.Name = "savePolylineButton";
            this.savePolylineButton.Size = new System.Drawing.Size(75, 37);
            this.savePolylineButton.TabIndex = 10;
            this.savePolylineButton.Text = "Save Polyline";
            this.savePolylineButton.UseVisualStyleBackColor = true;
            this.savePolylineButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // loadPolylineButton
            // 
            this.loadPolylineButton.Location = new System.Drawing.Point(13, 143);
            this.loadPolylineButton.Name = "loadPolylineButton";
            this.loadPolylineButton.Size = new System.Drawing.Size(75, 37);
            this.loadPolylineButton.TabIndex = 9;
            this.loadPolylineButton.Text = "Load Polyline";
            this.loadPolylineButton.UseVisualStyleBackColor = true;
            this.loadPolylineButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // stopAnimationButton
            // 
            this.stopAnimationButton.Location = new System.Drawing.Point(99, 579);
            this.stopAnimationButton.Name = "stopAnimationButton";
            this.stopAnimationButton.Size = new System.Drawing.Size(75, 23);
            this.stopAnimationButton.TabIndex = 8;
            this.stopAnimationButton.Text = "Stop";
            this.stopAnimationButton.UseVisualStyleBackColor = true;
            this.stopAnimationButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // startAnimationButton
            // 
            this.startAnimationButton.Location = new System.Drawing.Point(6, 579);
            this.startAnimationButton.Name = "startAnimationButton";
            this.startAnimationButton.Size = new System.Drawing.Size(75, 23);
            this.startAnimationButton.TabIndex = 7;
            this.startAnimationButton.Text = "Start";
            this.startAnimationButton.UseVisualStyleBackColor = true;
            this.startAnimationButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.moovingOnTheCurveRadioButton);
            this.groupBox3.Controls.Add(this.RotationRadioButton);
            this.groupBox3.Location = new System.Drawing.Point(6, 440);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 133);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Move";
            // 
            // moovingOnTheCurveRadioButton
            // 
            this.moovingOnTheCurveRadioButton.AutoSize = true;
            this.moovingOnTheCurveRadioButton.Location = new System.Drawing.Point(7, 68);
            this.moovingOnTheCurveRadioButton.Name = "moovingOnTheCurveRadioButton";
            this.moovingOnTheCurveRadioButton.Size = new System.Drawing.Size(123, 17);
            this.moovingOnTheCurveRadioButton.TabIndex = 1;
            this.moovingOnTheCurveRadioButton.TabStop = true;
            this.moovingOnTheCurveRadioButton.Text = "Moving on the curve";
            this.moovingOnTheCurveRadioButton.UseVisualStyleBackColor = true;
            this.moovingOnTheCurveRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // RotationRadioButton
            // 
            this.RotationRadioButton.AutoSize = true;
            this.RotationRadioButton.Location = new System.Drawing.Point(10, 32);
            this.RotationRadioButton.Name = "RotationRadioButton";
            this.RotationRadioButton.Size = new System.Drawing.Size(65, 17);
            this.RotationRadioButton.TabIndex = 0;
            this.RotationRadioButton.TabStop = true;
            this.RotationRadioButton.Text = "Rotation";
            this.RotationRadioButton.UseVisualStyleBackColor = true;
            this.RotationRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rotationWithFilteringRadioButton);
            this.groupBox2.Controls.Add(this.naivRotationRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 123);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rotation";
            // 
            // rotationWithFilteringRadioButton
            // 
            this.rotationWithFilteringRadioButton.AutoSize = true;
            this.rotationWithFilteringRadioButton.Location = new System.Drawing.Point(13, 70);
            this.rotationWithFilteringRadioButton.Name = "rotationWithFilteringRadioButton";
            this.rotationWithFilteringRadioButton.Size = new System.Drawing.Size(83, 17);
            this.rotationWithFilteringRadioButton.TabIndex = 1;
            this.rotationWithFilteringRadioButton.TabStop = true;
            this.rotationWithFilteringRadioButton.Text = "With filtering";
            this.rotationWithFilteringRadioButton.UseVisualStyleBackColor = true;
            this.rotationWithFilteringRadioButton.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // naivRotationRadioButton
            // 
            this.naivRotationRadioButton.AutoSize = true;
            this.naivRotationRadioButton.Location = new System.Drawing.Point(13, 30);
            this.naivRotationRadioButton.Name = "naivRotationRadioButton";
            this.naivRotationRadioButton.Size = new System.Drawing.Size(47, 17);
            this.naivRotationRadioButton.TabIndex = 0;
            this.naivRotationRadioButton.TabStop = true;
            this.naivRotationRadioButton.Text = "Naiv";
            this.naivRotationRadioButton.UseVisualStyleBackColor = true;
            this.naivRotationRadioButton.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadImage);
            this.groupBox1.Controls.Add(this.imageOnBezierCurveImageBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 119);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // loadImage
            // 
            this.loadImage.Location = new System.Drawing.Point(119, 33);
            this.loadImage.Name = "loadImage";
            this.loadImage.Size = new System.Drawing.Size(51, 50);
            this.loadImage.TabIndex = 1;
            this.loadImage.Text = "Load";
            this.loadImage.UseVisualStyleBackColor = true;
            this.loadImage.Click += new System.EventHandler(this.button4_Click);
            // 
            // imageOnBezierCurveImageBox
            // 
            this.imageOnBezierCurveImageBox.BackColor = System.Drawing.SystemColors.Window;
            this.imageOnBezierCurveImageBox.Location = new System.Drawing.Point(12, 33);
            this.imageOnBezierCurveImageBox.Name = "imageOnBezierCurveImageBox";
            this.imageOnBezierCurveImageBox.Size = new System.Drawing.Size(101, 80);
            this.imageOnBezierCurveImageBox.TabIndex = 0;
            this.imageOnBezierCurveImageBox.TabStop = false;
            // 
            // visiblePolylineCheckBox
            // 
            this.visiblePolylineCheckBox.AutoSize = true;
            this.visiblePolylineCheckBox.Location = new System.Drawing.Point(16, 96);
            this.visiblePolylineCheckBox.Name = "visiblePolylineCheckBox";
            this.visiblePolylineCheckBox.Size = new System.Drawing.Size(94, 17);
            this.visiblePolylineCheckBox.TabIndex = 4;
            this.visiblePolylineCheckBox.Text = "Visible polyline";
            this.visiblePolylineCheckBox.UseVisualStyleBackColor = true;
            this.visiblePolylineCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // generatePolylineButton
            // 
            this.generatePolylineButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generatePolylineButton.Location = new System.Drawing.Point(73, 63);
            this.generatePolylineButton.Name = "generatePolylineButton";
            this.generatePolylineButton.Size = new System.Drawing.Size(75, 23);
            this.generatePolylineButton.TabIndex = 3;
            this.generatePolylineButton.Text = "Generate";
            this.generatePolylineButton.UseVisualStyleBackColor = true;
            this.generatePolylineButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // pointsNumberPolylineTextBox
            // 
            this.pointsNumberPolylineTextBox.Location = new System.Drawing.Point(99, 37);
            this.pointsNumberPolylineTextBox.Name = "pointsNumberPolylineTextBox";
            this.pointsNumberPolylineTextBox.Size = new System.Drawing.Size(49, 20);
            this.pointsNumberPolylineTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of points:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bezier\'s Curve";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(201, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(796, 607);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(786, 597);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 607);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageOnBezierCurveImageBox)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button generatePolylineButton;
        private System.Windows.Forms.TextBox pointsNumberPolylineTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox visiblePolylineCheckBox;
        private System.Windows.Forms.Button stopAnimationButton;
        private System.Windows.Forms.Button startAnimationButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton moovingOnTheCurveRadioButton;
        private System.Windows.Forms.RadioButton RotationRadioButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rotationWithFilteringRadioButton;
        private System.Windows.Forms.RadioButton naivRotationRadioButton;
        private System.Windows.Forms.Button loadImage;
        private System.Windows.Forms.PictureBox imageOnBezierCurveImageBox;
        private System.Windows.Forms.Button savePolylineButton;
        private System.Windows.Forms.Button loadPolylineButton;
    }
}


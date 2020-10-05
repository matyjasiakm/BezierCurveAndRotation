using Gk3.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gk3
{
    public partial class Form1 : Form
    {
        BezierCurve bezierCurve;
        Vertex activeVertex;
        bool moveEnable;
        bool animateEnable;
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = Resources.Niclaus;
            imageOnBezierCurveImageBox.Image = new Bitmap(bitmap, imageOnBezierCurveImageBox.Size);
            bezierCurve = new BezierCurve(4, pictureBox1.Width, pictureBox1.Height, bitmap);
            activeVertex = null;
            moveEnable = false;
            visiblePolylineCheckBox.Checked = bezierCurve.drawPolylineEnable;
            animateEnable = false;
            RotationRadioButton.Checked = true;
            bezierCurve.rotationNaivActive = true;
            naivRotationRadioButton.Checked = true;
            bezierCurve.animatedActive = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            bezierCurve.DrawBezierCurve(e.Graphics, pictureBox1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            activeVertex = bezierCurve.GetClickedPoint(e.X, e.Y);
            if (activeVertex != null)
                moveEnable = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveEnable)
                bezierCurve.MoveVertexTo(activeVertex, e.X, e.Y);
            if (!animateEnable)
                pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moveEnable = false;
            activeVertex = null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (visiblePolylineCheckBox.Checked)
            {
                bezierCurve.drawPolylineEnable = true;
            }
            else
            {
                bezierCurve.drawPolylineEnable = false;
            }
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(pointsNumberPolylineTextBox.Text, out int pointsNumber))
            {
                if (pointsNumber <= 0)
                {
                    MessageBox.Show("The number of points must be integer > 0!", "", MessageBoxButtons.OK);
                    return;
                }

                bezierCurve = new BezierCurve(pointsNumber, pictureBox1.Width, pictureBox1.Height, bitmap);
                activeVertex = null;
                moveEnable = false;
                visiblePolylineCheckBox.Checked = bezierCurve.drawPolylineEnable;
                animateEnable = false;
                RotationRadioButton.Checked = true;

                naivRotationRadioButton.Checked = true;
                bezierCurve.animatedActive = false;
                bezierCurve.rotationNaivActive = true;

                animateEnable = false;

            }
            else
                MessageBox.Show("The number of points must be integer >0!", "", MessageBoxButtons.OK);

            pictureBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!animateEnable)
            {
                animateEnable = true;
                bezierCurve.animate = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (animateEnable)
            {
                animateEnable = false;
                bezierCurve.animate = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RotationRadioButton.Checked)
            {
                if (naivRotationRadioButton.Checked)
                {
                    bezierCurve.rotationNaivActive = true;
                    bezierCurve.rotationFilterActive = false;
                }
                else
                {
                    bezierCurve.rotationFilterActive = true;
                    bezierCurve.rotationNaivActive = false;
                }
                bezierCurve.animatedActive = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (moovingOnTheCurveRadioButton.Checked)
            {
                bezierCurve.animatedActive = true;
                bezierCurve.rotationNaivActive = false;
                bezierCurve.rotationFilterActive = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (animateEnable)
                {
                    pictureBox1.Invoke(new Action(() => pictureBox1.Refresh()));
                    if (moovingOnTheCurveRadioButton.Checked)
                    {
                        Thread.Sleep(20);
                    }
                    else
                    {
                        Thread.Sleep(50);
                    }
                }
                else
                    break;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (naivRotationRadioButton.Checked)
            {
                bezierCurve.rotationNaivActive = true;
                bezierCurve.rotationFilterActive = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (rotationWithFilteringRadioButton.Checked)
            {
                bezierCurve.rotationNaivActive = false;
                bezierCurve.rotationFilterActive = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog.FileName);
                int polylinePointsNumber = bezierCurve.PolylinePointsNumber;
                bezierCurve = new BezierCurve(polylinePointsNumber, pictureBox1.Width, pictureBox1.Height, (Bitmap)image);
                activeVertex = null;
                moveEnable = false;
                visiblePolylineCheckBox.Checked = bezierCurve.drawPolylineEnable;
                animateEnable = false;
                RotationRadioButton.Checked = true;
                bezierCurve.rotationNaivActive = true;
                naivRotationRadioButton.Checked = true;
                bezierCurve.animatedActive = false;
                bitmap = (Bitmap)image;
                imageOnBezierCurveImageBox.Image = new Bitmap(image, imageOnBezierCurveImageBox.Size);
                pictureBox1.Refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool isValidFile = true;
            OpenFileDialog newFileDialog = new OpenFileDialog();
            newFileDialog.Filter = "txt files (*.txt)|*.txt";

            if (newFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Vertex> newVertices = new List<Vertex>();

                StreamReader reader = new StreamReader(newFileDialog.FileName);

                while (!reader.EndOfStream)
                {
                    string[] wordFromFile = reader.ReadLine().Split(',');
                    if (wordFromFile.Length == 2)
                        newVertices.Add(new Vertex(Int32.Parse(wordFromFile[0]), Int32.Parse(wordFromFile[1])));
                    else
                    {
                        isValidFile = false;
                    }
                }

                reader.Close();

                if (!isValidFile)
                {
                    MessageBox.Show("Wrong data!!!", "", MessageBoxButtons.OK);
                }
                else
                {
                    bezierCurve = new BezierCurve(newVertices.ToList(), bitmap);
                    activeVertex = null;
                    moveEnable = false;
                    visiblePolylineCheckBox.Checked = bezierCurve.drawPolylineEnable;
                    animateEnable = false;
                    RotationRadioButton.Checked = true;

                    naivRotationRadioButton.Checked = true;
                    bezierCurve.animatedActive = false;
                    bezierCurve.rotationNaivActive = true;

                    animateEnable = false;
                    pictureBox1.Refresh();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog newFileDialog = new SaveFileDialog();
            newFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (newFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(newFileDialog.FileName);
                List<Vertex> pom = bezierCurve.GetbSpline();
                foreach (var elem in pom)
                {
                    writer.WriteLine(((int)elem.X).ToString() + "," + ((int)elem.Y).ToString());
                }
                writer.Close();
            }
        }
    }
}

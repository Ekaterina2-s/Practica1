using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Star 
{
    public partial class Form1 : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Form1()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);

            // Устанавливаем размер формы
            this.ClientSize = new Size(400, 400);

            // Вычисляем размер и положение формы
            int starSize = 200;
            int radius = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 2 - 20; // Радиус звезды
            int points = 5; // Количество вершин звезды
            double R = 23, r = 60 // радиусы

            // Диаметр звезды
            int diameter = 2 * r;
            int formSize = (int)Math.Ceiling(diameter);

            // Координаты центра звезды
            int centerX = formSize / 2;
            int centerY = formSize / 2;

            // Точки звезды
            PointF[] starPoints = new PointF[points  2];

            // Создаем вершины звезды
            for (int i = 0; i < points 2; i++)
            {
                // Угол для каждой вершины
                double angle = i  2  Math.PI/points;

                // Вычисляем координаты вершины
                float x = (float)(centerX + radius  Math.Cos(angle));
                float y = (float)(centerY + radius  Math.Sin(angle));

                // Добавляем вершину в массив
                starPoints[i] = new PointF(x, y);
            }

            // Устанавливаем размер и положение формы
            this.ClientSize = new Size(formSize, formSize);
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - formSize) / 2,
                                       (Screen.PrimaryScreen.WorkingArea.Height - formSize) / 2);
            this.Text = "Фиолетовая звезда";

            // Рисуем звезду
            this.Paint += new PaintEventHandler(MainForm_Paint);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Для сглаженных краев

            // Рисуем звезду фиолетовым цветом
            g.FillPolygon(new SolidBrush(Color.Purple), StarPoints);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = Location;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currentCursorPoint = Cursor.Position;
                Location = new Point(dragFormPoint.X + currentCursorPoint.X - dragCursorPoint.X,
                    dragFormPoint.Y + currentCursorPoint.Y - dragCursorPoint.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = false;
            }
        }
    }
}

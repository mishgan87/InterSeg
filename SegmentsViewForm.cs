using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace InterSeg
{
    public partial class SegmentsViewForm : Form
    {
        private bool needToRead;
        public SegmentsViewForm()
        {
            needToRead = false;
            InitializeComponent();
        }
        private void SegmentsViewForm_Load(object sender, EventArgs e)
        {
            segmentsBox.Dock = DockStyle.Bottom;
            segmentsBox.BackColor = Color.White;
            segmentsBox.Paint += new System.Windows.Forms.PaintEventHandler(this.segmentsBox_Paint);
            this.Controls.Add(segmentsBox);
        }
        /// <summary>
        /// чтение списков отрезков и пересечений из файла
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="seg">ссылка на список отрезков</param>
        /// <param name="inter">ссылка на список пересечений</param>
        private void ReadSegments(string fileName, ref List<Segment> seg, ref List<Segment> inter)
        {
            if (!needToRead)
            {
                return;
            }
            using (StreamReader sr = new StreamReader(fileName))
            {
                seg.Clear();
                inter.Clear();
                string line = sr.ReadLine();
                while (true)
                {
                    line = sr.ReadLine();
                    if (line == "Пересечения")
                    {
                        break;
                    }
                    string[] subs = line.Split(' ');
                    Point p1 = new Point(Convert.ToInt32(subs[0]), Convert.ToInt32(subs[1]));
                    Point p2 = new Point(Convert.ToInt32(subs[2]), Convert.ToInt32(subs[3]));
                    seg.Add(new Segment(p1, p2));
                }
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string[] subs = line.Split(' ');
                    Point p1 = new Point(Convert.ToInt32(subs[0]), Convert.ToInt32(subs[1]));
                    Point p2 = new Point(Convert.ToInt32(subs[2]), Convert.ToInt32(subs[3]));
                    inter.Add(new Segment(p1, p2));
                }
            }
        }
        /// <summary>
        /// запись в файл списков отрезков и пересечений
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="seg">ссылка на список отрезков</param>
        /// <param name="inter">ссылка на список пересечений</param>
        private void WriteSegments(string fileName, ref List<Segment> seg, ref List<Segment> inter)
        {
            var dTableSegment = new DataTable();
            dTableSegment.Columns.Add("Id", typeof(int));
            dTableSegment.Columns.Add("Отрезок", typeof(string));
            var dTableIntersection = new DataTable();
            dTableIntersection.Columns.Add("Id", typeof(int));
            dTableIntersection.Columns.Add("Отрезок", typeof(string));

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Отрезки");
                for (int i = 0; i < seg.Count; i++)
                {
                    string text = seg[i].First.X.ToString() + " " + seg[i].First.Y.ToString()
                                    + " " + seg[i].Second.X.ToString() + " " + seg[i].Second.Y.ToString();
                    sw.WriteLine(text);

                    dTableSegment.Rows.Add(i + 1, seg[i].First.X.ToString() + " " + seg[i].First.Y.ToString() + " " +
                    seg[i].Second.X.ToString() + " " + seg[i].Second.Y.ToString());
                }

                sw.WriteLine("Пересечения");
                for (int i = 0; i < inter.Count; i++)
                {
                    string text = inter[i].First.X.ToString() + " " + inter[i].First.Y.ToString()
                                    + " " + inter[i].Second.X.ToString() + " " + inter[i].Second.Y.ToString();
                    sw.WriteLine(text);

                    dTableIntersection.Rows.Add(i + 1, inter[i].First.X.ToString() + " " + inter[i].First.Y.ToString() + " " +
                    inter[i].Second.X.ToString() + " " + inter[i].Second.Y.ToString());
                }
                sw.Flush();
                needToRead = true;
            };

            dataGridSegment.DataSource = dTableSegment;
            dataGridSegment.Update();
            dataGridIntersection.DataSource = dTableIntersection;
            dataGridIntersection.Update();
        }
        private void segmentsBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen penSeg = new Pen(segmentColor.BackColor, 2);
            penSeg.StartCap = LineCap.Flat;
            penSeg.EndCap = LineCap.Flat;

            Pen penInter = new Pen(intersectionColor.BackColor, 2);
            penInter.StartCap = LineCap.Flat;
            penInter.EndCap = LineCap.Flat;

            // список полученных пересечений
            List<Segment> NewSegments = new List<Segment>();
            // список сгенерированных отрезков
            List<Segment> Segments = new List<Segment>();

            ReadSegments(@".\hta.txt", ref Segments, ref NewSegments);

            for (int i = 0; i < Segments.Count; i++)
            {
                e.Graphics.DrawLine(penSeg, Segments[i].First.X, Segments[i].First.Y, Segments[i].Second.X, Segments[i].Second.Y);
            }

            for (int i = 0; i < NewSegments.Count; i++)
            {
                e.Graphics.DrawLine(penInter, NewSegments[i].First.X, NewSegments[i].First.Y, NewSegments[i].Second.X, NewSegments[i].Second.Y);
            }
        }
        private double AngleToOX(Segment seg)
        {
            if (seg.Second.X < seg.First.X)
            {
                Point tmp = seg.First;
                seg.First = seg.Second;
                seg.Second = tmp;
            }
            double angle = Math.Atan2((double)seg.Second.Y - (double)seg.First.Y, (double)seg.Second.X - (double)seg.First.X);
            angle = Math.Abs((angle * 180) / Math.PI);
            return angle;
        }
        /// <summary>
        /// векторное произведение
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="ay"></param>
        /// <param name="bx"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        private int vector_mult(int ax, int ay, int bx, int by) 
        {
            return ax * by - bx * ay;
        }
        /// <summary>
        /// проверка пересечения
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <returns></returns>
        public bool areCrossing(Point p1, Point p2, Point p3, Point p4)
        {
            int v1 = vector_mult(p4.X - p3.X, p4.Y - p3.Y, p1.X - p3.X, p1.Y - p3.Y);
            int v2 = vector_mult(p4.X - p3.X, p4.Y - p3.Y, p2.X - p3.X, p2.Y - p3.Y);
            int v3 = vector_mult(p2.X - p1.X, p2.Y - p1.Y, p3.X - p1.X, p3.Y - p1.Y);
            int v4 = vector_mult(p2.X - p1.X, p2.Y - p1.Y, p4.X - p1.X, p4.Y - p1.Y);
            if ((v1 * v2) < 0 && (v3 * v4) < 0)
            {
                return true;
            }
            return false;
        }
        //поиск точки пересечения
        Point CrossingPoint(Point p1, Point p2, Point p3, Point p4)
        {
            int a1 = p2.Y - p1.Y;
            int b1 = p1.X - p2.X;
            int c1 = -p1.X * (p2.Y - p1.Y) + p1.Y * (p2.X - p1.X);
            int a2 = p4.Y - p3.Y;
            int b2 = p3.X - p4.X;
            int c2 = -p3.X * (p4.Y - p3.Y) + p3.Y * (p4.X - p3.X);
            Point pt = new Point();
            double d = (double)(a1 * b2 - b1 * a2);
            double dx = (double)(-c1 * b2 + b1 * c2);
            double dy = (double)(-a1 * c2 + c1 * a2);
            pt.X = (int)(dx / d);
            pt.Y = (int)(dy / d);
            return pt;
        }
        
        /// <summary>
        /// обработчик нажатия кнопки "Генерировать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxSegmentCount.Text.Length == 0)
            {
                return;
            }
            // проверка является ли числом содержимое текстбокса
            bool isNumber = true;
            for (int i = 0; i < textBoxSegmentCount.Text.Length; i++)
            {
                bool isDigit = false;
                for (int j = 0; j < 9; j++)
                {
                    if (textBoxSegmentCount.Text.Substring(i, 1) == j.ToString())
                    {
                        isDigit = true;
                        break;
                    }
                }
                if (!isDigit)
                {
                    isNumber = false;
                    break;
                }
            }
            if (!isNumber)
            {
                return;
            }
            // список полученных пересечений
            List<Segment> NewSegments = new List<Segment>();
            // список сгенерированных отрезков
            List<Segment> Segments = new List<Segment>();
            // список отрезков для удаления
            List<Segment> SegmentsForDelete = new List<Segment>();
            Random rnd = new Random();
            // список точек пересечения
            List<Point> crossPoints = new List<Point>();
            int count = Convert.ToInt32(textBoxSegmentCount.Text);
            // генерируем список отрезков в дипазоне границ pictureBox
            for (int i = 0; i < count; i++)
            {
                // получаем случайные точки в дипазоне границ pictureBox
                Point p1 = new Point(rnd.Next(0, this.segmentsBox.Width), rnd.Next(0, this.segmentsBox.Height));
                Point p2 = new Point(rnd.Next(0, this.segmentsBox.Width), rnd.Next(0, this.segmentsBox.Height));
                //расставим точки по порядку, т.е. чтобы было p1.X <= p2.X
                if (p2.X < p1.X)
                {
                    Point tmp = p1;
                    p1 = p2;
                    p2 = tmp;
                }
                Segments.Add(new Segment(p1, p2));
            }

            int crossCount = 0;
            const int delta = 40;
            // определяем пересечения сгенерированных отрезков
            for (int i = 0; i < Segments.Count; i++)
            {
                for (int j = 0; j < Segments.Count; j++)
                {
                    if (i != j)
                    {
                        if (areCrossing(Segments[i].First, Segments[i].Second, Segments[j].First, Segments[j].Second))
                        {
                            crossCount++;
                            Point cPoint = CrossingPoint(Segments[i].First, Segments[i].Second, Segments[j].First, Segments[j].Second);

                            if (!crossPoints.Contains(cPoint))
                            {
                                crossPoints.Add(cPoint);
                                double anglei = AngleToOX(Segments[i]);
                                double anglej = AngleToOX(Segments[j]);
                                if (anglei >= anglej)
                                {
                                    Point tmpPoint = new Point();
                                    tmpPoint = cPoint;
                                    tmpPoint.X -= (int)(delta * Math.Cos(anglei));
                                    tmpPoint.Y -= (int)(delta * Math.Sin(anglei));
                                    NewSegments.Add(new Segment(Segments[i].First, tmpPoint));

                                    tmpPoint = cPoint;
                                    tmpPoint.X += (int)(delta * Math.Cos(anglei));
                                    tmpPoint.Y += (int)(delta * Math.Sin(anglei));
                                    NewSegments.Add(new Segment(tmpPoint, Segments[i].Second));

                                    SegmentsForDelete.Add(Segments[i]);
                                }
                                else
                                {
                                    Point tmpPoint = new Point();
                                    tmpPoint = cPoint;
                                    tmpPoint.X -= (int)(delta * Math.Cos(anglej));
                                    tmpPoint.Y -= (int)(delta * Math.Sin(anglej));
                                    NewSegments.Add(new Segment(Segments[j].First, tmpPoint));

                                    tmpPoint = cPoint;
                                    tmpPoint.X += (int)(delta * Math.Cos(anglej));
                                    tmpPoint.Y += (int)(delta * Math.Sin(anglej));
                                    NewSegments.Add(new Segment(tmpPoint, Segments[j].Second));

                                    SegmentsForDelete.Add(Segments[j]);
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < Segments.Count; i++)
            {
                if (SegmentsForDelete.Contains(Segments[i]))
                {
                    Segments.RemoveAt(i);
                }
            }

            WriteSegments(@".\hta.txt", ref Segments, ref NewSegments);
            this.segmentsBox.Refresh();
        }

        private void intersection_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = false;
            cd.ShowHelp = true;
            cd.Color = intersectionColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
                intersectionColor.BackColor = cd.Color;
        }

        private void segmentColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = false;
            cd.ShowHelp = true;
            cd.Color = segmentColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
                segmentColor.BackColor = cd.Color;
        }
    }
}

using System.Security.Cryptography.X509Certificates;

namespace DrawTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Pen MyPen = new Pen(Color.Black, 5f);

            DrawBackground(graphics, new SolidBrush(Color.DarkSlateGray));
            DrawCorners(graphics, MyPen, new SolidBrush(Color.Yellow));
            DrawOuterTiles(graphics, MyPen, new SolidBrush(Color.Firebrick));
            DrawTitleBackground(graphics, MyPen, new SolidBrush(Color.DarkRed));
            DrawTitle(graphics, new Font(FontFamily.GenericMonospace, 24f), new Pen(Color.Orange, 5f), new Pen(Color.Orange, 5f), new SolidBrush(Color.Yellow));
            DrawButton(graphics, new Font(FontFamily.GenericMonospace, 12f), MyPen, new SolidBrush(Color.CadetBlue));

            //Window is 800, 450 in scale
        }

        private void DrawButton(Graphics graphics, Font font, Pen MyPen, SolidBrush brush)
        {
            int x = 350;
            int y = 260;

            DrawHexagon(x, y, 80, graphics, MyPen, brush);
            graphics.DrawEllipse(MyPen, x - 40, y + 25, 30, 30);
            graphics.FillEllipse(new SolidBrush(Color.Yellow), x - 40, y + 25, 30, 30);
            graphics.DrawEllipse(MyPen, x + 90, y + 25, 30, 30);
            graphics.FillEllipse(new SolidBrush(Color.Yellow), x + 90, y + 25, 30, 30);

            graphics.DrawString("Play", font, new SolidBrush(Color.Red), new Point(x + 18, y + 30));
        }

        private void DrawHexagon(int x, int y, int size, Graphics graphics, Pen MyPen, SolidBrush brush)
        {
            Point[] points = new Point[6];

            points[0] = new Point(x + (size/4), y);
            points[1] = new Point(x + (size - size/4), y);
            points[2] = new Point(x + size, y + (size / 2));
            points[3] = new Point(x + (size - size/4), y + size);
            points[4] = new Point(x + (size/4), y + size);
            points[5] = new Point(x, y + (size / 2));

            graphics.DrawPolygon(MyPen, points);
            graphics.FillPolygon(brush, points);
        }

        private void DrawTitleBackground(Graphics graphics, Pen MyPen, SolidBrush brush)
        {
            int x = 262;
            int y = 170;
            graphics.DrawEllipse(MyPen, x, y, 260, 120);
            graphics.FillEllipse(brush, x, y, 260, 120);
        }

        private void DrawTitle(Graphics graphics, Font font, Pen TrianglePen, Pen ArcPen, SolidBrush brush)
        {
            int x = 310;
            int y = 210;

            graphics.DrawString("The Game", font, new SolidBrush(Color.DarkRed), new Point(x - 2, y - 2));
            graphics.DrawString("The Game", font, new SolidBrush(Color.DarkRed), new Point(x + 2, y + 2));
            graphics.DrawString("The Game", font, new SolidBrush(Color.DarkOrange), new Point(x - 1, y - 1));
            graphics.DrawString("The Game", font, new SolidBrush(Color.DarkOrange), new Point(x + 1, y + 1));
            graphics.DrawString("The Game", font, new SolidBrush(Color.Yellow), new Point(x, y));

            graphics.DrawArc(ArcPen, (float)x - 20, (float)y - 25, 203f, 100f, 180f, 180f);

            DrawTriangle(x - 25, y + 25, 15, graphics, TrianglePen, brush);
            DrawTriangle(x + 175, y + 25, 15, graphics, TrianglePen, brush);
        }

        private void DrawTriangle(int x, int y, int size, Graphics graphics, Pen MyPen, SolidBrush brush)
        {
            Point[] points = new Point[3];

            points[0] = new Point(x, y);
            points[1] = new Point(x + size, y);
            points[2] = new Point(x + (size / 2), y - size);

            graphics.DrawPolygon(MyPen, points);
            graphics.FillPolygon(brush, points);
        }

        private void DrawBackground(Graphics graphics, SolidBrush brush)
        {
            graphics.FillRectangle(brush, 0f, 0f, 800f, 450f);
        }

        private void DrawOuterTiles(Graphics graphics, Pen MyPen, SolidBrush brush)
        {
            for (int i = 0; i < 16; i++)
            {
                graphics.DrawRectangle(MyPen, i * 50f, 0f, 50, 50);
                graphics.FillRectangle(brush, i * 50f, 0f, 50, 50);
                graphics.DrawRectangle(MyPen, i * 50f, 400f, 50, 50);
                graphics.FillRectangle(brush, i * 50f, 400f, 50, 50);

                if (i < 8 && i > 0)
                {
                    graphics.DrawRectangle(MyPen, 0f, i * 50f, 50, 50);
                    graphics.FillRectangle(brush, 0f, i * 50f, 50, 50);
                    graphics.DrawRectangle(MyPen, 750f, i * 50f, 50, 50);
                    graphics.FillRectangle(brush, 750f, i * 50f, 50, 50);
                }
            }
        }

        private void DrawCorners(Graphics graphics, Pen MyPen, SolidBrush brush)
        {
            for (int i = 0; i < 2; i++)
            {
                graphics.DrawPie(MyPen, i * 700f, 0f, 100f, 100f, i * 90f, 90f);
                graphics.FillPie(brush, i * 700f, 0f, 100f, 100f, i * 90f, 90f);
            }

            graphics.DrawPie(MyPen, 0f, 350f, 100f, 100f, 270f, 90f);
            graphics.FillPie(brush, 0f, 350f, 100f, 100f, 270f, 90f);

            graphics.DrawPie(MyPen, 700f, 350f, 100f, 100f, 180f, 90f);
            graphics.FillPie(brush, 700f, 350f, 100f, 100f, 180f, 90f);
        }
    }
}
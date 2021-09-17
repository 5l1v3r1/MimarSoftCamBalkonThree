using System.Drawing;

namespace Repository.Business.Logic.Geometri
{
    public static class Table
    {
        public static void Draw(Graphics g, int X, int Y, int RowCount, int ColCount, int[] ColWidths, int RowHeight)
        {
            int width = 0;
            int height = RowCount * RowHeight;

            for (int i = 0; i < ColWidths.Length; i++)
            {
                width += ColWidths[i];
            }

            g.DrawRectangle(Pens.Black, X, Y, width, height);

            for (int i = 0; i < RowCount; i++)
            {
                g.DrawLine(Pens.Black, X, Y + RowHeight * i, X + width, Y + RowHeight * i);
            }
            int x = X;
            for (int i = 0; i < ColCount; i++)
            {
                x += ColWidths[i];
                g.DrawLine(Pens.Black, x, Y, x, Y + RowHeight * RowCount);
            }
        }
    }
}
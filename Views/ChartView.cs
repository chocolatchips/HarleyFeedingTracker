using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Views
{
    public class ChartView : ContentView
    {
        private GraphicsView _graphicsView;
        private PieChartDrawable _pieChartDrawable;

        public List<float> Values
        {
            get => _pieChartDrawable.Values;
            set
            {
                _pieChartDrawable.Values = value;
                _graphicsView.Invalidate();
            }
        }

        public List<Color> Colors
        {
            get => _pieChartDrawable.ChartColors;
            set
            {
                _pieChartDrawable.ChartColors = value;
                _graphicsView.Invalidate();
            }
        }

        public List<string> Labels
        {
            get => _pieChartDrawable.Labels;
            set
            {
                _pieChartDrawable.Labels = value;
                _graphicsView.Invalidate();
            }
        }

        public ChartView()
        {
            _pieChartDrawable = new PieChartDrawable();
            _graphicsView = new GraphicsView
            {
                Drawable = _pieChartDrawable
            };
            Content = _graphicsView;
        }        
    }

    internal class PieChartDrawable : IDrawable
    {
        public List<float> Values { get; set; } = [];
        public List<Color> ChartColors { get; set; } = [];
        public List<string> Labels { get; set; } = [];

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (Values == null || Values.Count == 0)
                return;

            float sum = Values.Sum();

            float startAngle = 0;
            float centerX = dirtyRect.Center.X;
            float centerY = dirtyRect.Center.Y;
            float radius = Math.Min(dirtyRect.Width, dirtyRect.Height) / 2;

            // Draws outer curve of chart
            for (int i = 0; i < Values.Count; i++)
            {
                float sweepAngle = 360 * (Values[i] / sum);

                canvas.FillColor = ChartColors[i];
                // Shifts center location by the height and width
                canvas.FillArc(centerX, centerY, radius, radius, startAngle, startAngle + sweepAngle, false);

                float startX = centerX + radius / 2 * (float) Math.Cos(startAngle * Math.PI / 180);
                float startY = centerY - radius / 2 * (float) Math.Sin(startAngle * Math.PI / 180);

                double endX = centerX + radius / 2 * (float)Math.Cos((startAngle + sweepAngle) * Math.PI / 180);
                double endY = centerY - radius / 2 * (float)Math.Sin((startAngle + sweepAngle) * Math.PI / 180);

                PathF path = new PathF();
                path.MoveTo(centerX + radius / 2, centerY + radius / 2);
                path.LineTo((float)startX + radius / 2, (float)startY + radius / 2);
                path.LineTo((float)endX + radius / 2, (float)endY + radius / 2);
                path.Close();
                canvas.FillPath(path);

                startAngle += sweepAngle;
            }


            for (int i = 0; i < Labels.Count; i++)
            {
                canvas.FontColor = ChartColors[i];
                canvas.Font = Microsoft.Maui.Graphics.Font.Default;
                canvas.FontSize = 20;

                canvas.DrawString(Labels[i], centerX / 2, centerY -radius - (i * 24), dirtyRect.Width, dirtyRect.Height,HorizontalAlignment.Left, VerticalAlignment.Center);
            }
        }
    }
}

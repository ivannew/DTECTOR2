using SkiaSharp.Views.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DTECTOR.ViewModel
{
    public class GasDetectorView : ContentView
    {
        private double _percentage;

        public double Percentage
        {
            get { return _percentage; }
            set
            {
                _percentage = value;
                // Actualiza visualmente la vista cuando cambia el porcentaje
                InvalidateMeasure();
            }
        }

        public GasDetectorView()
        {
            // Inicializa la vista
            InitializeViews();
        }

        private void InitializeViews()
        {
            // Crea un SKCanvasView para dibujar la rueda del detector de gas
            var canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnPaintSurface;
            Content = canvasView;
        }


        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {

            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float strokeWidth = 10;
            float radius = Math.Min(info.Width, info.Height) / 2 - strokeWidth;

            // Dibuja el círculo exterior
            using (SKPaint circlePaint = new SKPaint())
            {
                circlePaint.Style = SKPaintStyle.Stroke;
                circlePaint.Color = SKColors.LightGray;
                circlePaint.StrokeWidth = strokeWidth;

                canvas.DrawCircle(info.Width / 2, info.Height / 2, radius, circlePaint);
            }

            // Dibuja el arco de porcentaje
            using (SKPaint arcPaint = new SKPaint())
            {
                arcPaint.Style = SKPaintStyle.Stroke;
                arcPaint.Color = new SKColor(0x97, 0xFF, 0x83); // Color #97FF83
                arcPaint.StrokeWidth = strokeWidth;

                float startAngle = -90;
                float sweepAngle = (float)(360 * Percentage / 100);

                canvas.DrawArc(new SKRect(strokeWidth, strokeWidth, info.Width - strokeWidth, info.Height - strokeWidth), startAngle, sweepAngle, false, arcPaint);
            }

            // Dibuja el texto del porcentaje
            using (SKPaint textPaint = new SKPaint())
            {
                textPaint.Style = SKPaintStyle.Fill;
                textPaint.Color = new SKColor(0x97, 0xFF, 0x83); // Color #97FF83
                textPaint.TextSize = 40;
                textPaint.TextAlign = SKTextAlign.Center;

                string percentageText = $"{Percentage}%";
                SKRect textBounds = new SKRect();
                textPaint.MeasureText(percentageText, ref textBounds);
                float textX = info.Width / 2 - textBounds.MidX;
                float textY = info.Height / 2 - textBounds.MidY;

                canvas.DrawText(percentageText, textX, textY, textPaint);
            }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            // Establece el tamaño medido de la vista
            var size = Math.Min(widthConstraint, heightConstraint);
            return new SizeRequest(new Size(size, size));
        }
    }
}

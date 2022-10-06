
using SkiaSharp;
using System;
using System.Linq;

namespace Topten.RichTextKit
{
    /// <summary>
    /// Desribes a gradient to apply to the text
    /// </summary>
    public class TextGradient
    {

        public SKPoint Center { get; set; }
        public float Radius { get; set; }
        public GradientType GradientType { get; set; }
        public SKColor[] Colors { get; set; }
        public float[] Positions { get; set; }
        public float Angle { get; set; }

        public static TextGradient Linear(SKColor[] colors, float[] positions, float angle)
        {
            return new TextGradient()
            {
                GradientType = GradientType.Linear,
                Colors = colors,
                Positions = positions,
                Angle = angle
            };
        }

        public static TextGradient Radial(SKColor[] colors, float[] positions, float angle, SKPoint center, float radius)
        {
            return new TextGradient()
            {
                GradientType = GradientType.Radial,
                Colors = colors,
                Positions = positions,
                Angle = angle,
                Center = center,
                Radius = radius
            };
        }

        internal SKShader CreateShader(float width, float height, float offsetx = 0)
        {
            var rotation = SKMatrix.CreateRotationDegrees(180 + Angle, width * .5f, height * .5f);
            var startPoint = new SKPoint(width * .5f, 0);
            var endPoint = new SKPoint(width * .5f, height);

            startPoint = rotation.MapPoint(startPoint);
            endPoint = rotation.MapPoint(endPoint);

            var localMatrix = SKMatrix.CreateTranslation(offsetx, 0);

            if (GradientType == GradientType.Linear)
            {
                var sx = Math.Abs(endPoint.X - startPoint.X);
                var sy = Math.Abs(endPoint.Y - startPoint.Y);
                if (sx == 0) sx = 1;
                if (sy == 0) sy = 1;

                sx = width / sx;
                sy = height / sy;

                var localScale = SKMatrix.CreateScale(sx, sy, width * .5f, height * .5f);
                localMatrix = SKMatrix.Concat(localMatrix, localScale);

                return SKShader.CreateLinearGradient( startPoint, endPoint, Colors, Positions, SKShaderTileMode.Clamp, localMatrix);
            }

            if(GradientType == GradientType.Radial)
            {
                var radius = Math.Max( width, height ) * Radius;
                var center = new SKPoint(width * Center.X, height * Center.Y);
                return SKShader.CreateRadialGradient(center, radius, Colors, Positions, SKShaderTileMode.Clamp, localMatrix);
            }

            return null;
        }

    }

    public enum GradientType
    {
        Linear,
        Radial
    }

}

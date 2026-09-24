using System.Globalization;
using System.Windows;
using System.Windows.Media;
using BarcodeLib;

namespace LabelPriceGenerator;

public static class LabelPreviewService
{
    public static ImageSource GeneratePriceLabel(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name) && string.IsNullOrWhiteSpace(product.Barcode))
        {
            return null!;
        }

        var barcodeText = string.IsNullOrWhiteSpace(product.Barcode) ? "0000000000000" : product.Barcode;
        var barcode = new Barcode();
        var bitmap = barcode.Encode(TYPE.CODE128, barcodeText, System.Drawing.Color.Black, System.Drawing.Color.White, 320, 90);
        var bitmapSource = ConvertToBitmapSource(bitmap);

        var drawing = new DrawingVisual();
        using (var dc = drawing.RenderOpen())
        {
            var titleBrush = new SolidColorBrush(Colors.Black);
            var priceBrush = new SolidColorBrush(Colors.DarkGreen);
            var textBrush = new SolidColorBrush(Colors.Black);

            dc.DrawRectangle(Brushes.White, null, new Rect(0, 0, 430, 260));
            dc.DrawRectangle(null, new Pen(Brushes.Gray, 1.5), new Rect(10, 10, 410, 240));

            dc.DrawText(new FormattedText(
                product.Name,
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                24,
                titleBrush),
                new Point(24, 18));

            var priceText = product.PromoPrice.HasValue ? $"{product.PromoPrice.Value:0.00} lei" : $"{product.Price:0.00} lei";
            dc.DrawText(new FormattedText(
                priceText,
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                36,
                priceBrush),
                new Point(24, 70));

            if (product.PromoPrice.HasValue)
            {
                dc.DrawText(new FormattedText(
                    $"Pret normal: {product.Price:0.00} lei",
                    CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                    16,
                    Brushes.Gray),
                    new Point(24, 118));
            }

            dc.DrawImage(bitmapSource, new Rect(60, 150, 300, 90));
            dc.DrawText(new FormattedText(
                product.Barcode,
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                16,
                textBrush),
                new Point(110, 245));
        }

        var renderBitmap = new RenderTargetBitmap(430, 260, 96, 96, PixelFormats.Pbgra32);
        renderBitmap.Render(drawing);
        return renderBitmap;
    }

    private static BitmapSource ConvertToBitmapSource(System.Drawing.Bitmap bitmap)
    {
        var bitmapData = bitmap.LockBits(
            new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
            System.Drawing.Imaging.ImageLockMode.ReadOnly,
            System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        var source = BitmapSource.Create(
            bitmapData.Width,
            bitmapData.Height,
            bitmap.HorizontalResolution,
            bitmap.VerticalResolution,
            PixelFormats.Bgra32,
            null,
            bitmapData.Scan0,
            bitmapData.Stride * bitmapData.Height,
            bitmapData.Stride);

        source.Freeze();
        bitmap.UnlockBits(bitmapData);
        return source;
    }
}

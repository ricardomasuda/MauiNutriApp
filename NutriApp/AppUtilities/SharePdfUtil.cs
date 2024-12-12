using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;

namespace NutriApp.AppUtilities;

public static class SharePdfUtil
{
    public static async Task CaptureAndSharePageAsPdf(Page page)
    {
        // 1. Capturar a Page como imagem
        byte[] imageData = await CapturePageAsync(page);

        if (imageData == null)
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "Falha ao capturar a página.", "OK");
            return;
        }

        // 2. Converter a imagem em PDF
        Stream pdfStream = CreatePdfFromImage(imageData);

        // 3. Compartilhar o PDF
        await SharePdfAsync(pdfStream, "RelatorioNutricional.pdf");
    }
    
    public static async Task CaptureAndShareViewAsPdf(View view)
    {
        // 1. Capturar a View como imagem
        byte[] imageData = await CaptureViewAsync(view);

        if (imageData == null)
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "Falha ao capturar a visualização.", "OK");
            return;
        }

        // 2. Converter a imagem em PDF
        Stream pdfStream = CreatePdfFromImage(imageData);

        // 3. Compartilhar o PDF
        await SharePdfAsync(pdfStream, "RelatorioNutricinal.pdf");
    }
    
    public static async Task<byte[]> CaptureViewAsync(View view)
    {
        IScreenshotResult screenshot = await view.CaptureAsync();

        if (screenshot != null)
        {
            using Stream stream = await screenshot.OpenReadAsync();
            using MemoryStream ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            return ms.ToArray();
        }

        return null;
    }
    
    public static async Task<byte[]> CapturePageAsync(Page page)
    {
        IScreenshotResult screenshot = await page.CaptureAsync();

        if (screenshot != null)
        {
            using Stream stream = await screenshot.OpenReadAsync();
            using MemoryStream ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            return ms.ToArray();
        }

        return null;
    }
    
    public static Stream CreatePdfFromImage(byte[] imageData)
    {
        using MemoryStream imageStream = new MemoryStream(imageData);
        using XImage image = XImage.FromStream(() => imageStream);

        PdfDocument document = new PdfDocument();
        PdfPage page = document.AddPage();

        // Ajusta o tamanho da página ao tamanho da imagem
        page.Width = image.PixelWidth * 72 / image.HorizontalResolution;
        page.Height = image.PixelHeight * 72 / image.VerticalResolution;

        using XGraphics gfx = XGraphics.FromPdfPage(page);
        gfx.DrawImage(image, 0, 0, page.Width, page.Height);

        MemoryStream pdfStream = new MemoryStream();
        document.Save(pdfStream, false);
        pdfStream.Position = 0; // Reseta a posição do stream para leitura

        return pdfStream;
    }
    
    
    public static async Task SharePdfAsync(Stream pdfStream, string fileName)
    {
        string filePath = Path.Combine(FileSystem.CacheDirectory, fileName);

        using (FileStream fileStream = File.Create(filePath))
        {
            pdfStream.Seek(0, SeekOrigin.Begin);
            await pdfStream.CopyToAsync(fileStream);
        }

        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = "Compartilhar PDF",
            File = new ShareFile(filePath)
        });
    }
}
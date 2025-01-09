// See https://aka.ms/new-console-template for more information

using FFMpegCore;
using System.Drawing;
using System.IO.Compression;

Console.WriteLine("Processo iniciado:");


var videoPath = @"Marvel_DOTNET_CSHARP.mp4";

var outputFolder = @"C:\Projetos\FIAP_HACK\FIAPProcessaVideo\FIAPProcessaVideo\Images\";

Directory.CreateDirectory(outputFolder);

var videoInfo = FFProbe.Analyse(videoPath);
var duration = videoInfo.Duration;

var interval = TimeSpan.FromSeconds(20);

for (var currentTime = TimeSpan.Zero; currentTime < duration; currentTime += interval)
{
    Console.WriteLine($"Processando frame: {currentTime}");

    var outputPath = Path.Combine(outputFolder, $"frame_at_{currentTime.TotalSeconds}.jpg");
    FFMpeg.Snapshot(videoPath, outputPath, new Size(1920, 1080), currentTime);
}

string destinationZipFilePath = @"C:\Projetos\FIAP_HACK\FIAPProcessaVideo\FIAPProcessaVideo\images.zip";

ZipFile.CreateFromDirectory(outputFolder, destinationZipFilePath);

Console.WriteLine("Processo finalizado.");



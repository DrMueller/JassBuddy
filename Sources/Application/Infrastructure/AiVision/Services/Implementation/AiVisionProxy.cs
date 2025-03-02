using Azure;
using Azure.AI.Vision.ImageAnalysis;
using JetBrains.Annotations;
using Mmu.JassBuddy2.Infrastructure.AiVision.Models;
using Mmu.JassBuddy2.Infrastructure.Settings.Provisioning.Services;

namespace Mmu.JassBuddy2.Infrastructure.AiVision.Services.Implementation
{
    [UsedImplicitly]
    public class AiVisionProxy(ISettingsProvider settingsProvider) : IAiVisionProxy
    {
        private readonly ISettingsProvider _settingsProvider = settingsProvider;

        public async Task<OcrRecognitionResult> RecognizeAsync(Stream stream)
        {
            var settings = _settingsProvider.AppSettings;

            var client = new ImageAnalysisClient(
                new Uri(settings.ComputerVisionEndpoint),
                new AzureKeyCredential(settings.ComputerVisionApiKey));

            var binaryData = await BinaryData.FromStreamAsync(stream);

            ImageAnalysisResult result = await client.AnalyzeAsync(
                binaryData,
                VisualFeatures.Read);

            var res = result.Read.Blocks
                .Select(f => new OrcRecognitionBlock
                (f.Lines.Select(g => new OrcRecognitionLine(g.Words
                    .Select(h => new OrcRecognitionWord(h.Text))
                    .ToList())).ToList()))
                .ToList();

            return new OcrRecognitionResult(res);
        }
    }
}
using JetBrains.Annotations;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
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
            var client =
                new ComputerVisionClient(new ApiKeyServiceClientCredentials(
                        _settingsProvider.AppSettings.ComputerVisionApiKey))
                    { Endpoint = _settingsProvider.AppSettings.ComputerVisionEndpoint };

            var readResult = await client.ReadInStreamAsync(stream);
            var operationLocation = readResult.OperationLocation;
            Thread.Sleep(2000);

            const int numberOfCharsInOperationId = 36;
            var operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

            ReadOperationResult results;
            do
            {
                results = await client.GetReadResultAsync(Guid.Parse(operationId));
            }
            while (results.Status == OperationStatusCodes.Running ||
                   results.Status == OperationStatusCodes.NotStarted);

            var textUrlFileResults = results.AnalyzeResult.ReadResults;
            foreach (var page in textUrlFileResults)
            {
                foreach (var line in page.Lines)
                {
                    Console.WriteLine(line.Text);
                }
            }

            var res = results.AnalyzeResult.ReadResults
                .Select(f => new OrcRecognitionRegion(
                    f.Lines.Select(g => new OrcRecognitionLine(g.Words
                        .Select(h => new OrcRecognitionWord(h.Text)).ToList()
                        .ToList())).ToList())).ToList();

            var result = new OcrRecognitionResult(res);

            return result;
        }
    }
}
using Microsoft.AspNetCore.Components;
using Mmu.JassBuddy2.Areas.Coiffeur.Models;
using Mmu.JassBuddy2.Areas.Coiffeur.Services;
using Mmu.JassBuddy2.Infrastructure.AiVision.Models;
using Mmu.JassBuddy2.Infrastructure.AiVision.Services;
using Mmu.JassBuddy2.Shared.Cameras;

namespace Mmu.JassBuddy2.Areas.Coiffeur.Components
{
    public partial class ResultsDisplayPage
    {
        public const string Path = "/coiffeur/results";

        public bool ShowCamera { get; set; } = true;

        private CoiffeurBlatt? CoiffeurBlatt {  get; set; }

        private Picture? _picture;

        [Inject]
        public required IAiVisionProxy VisionProxy { get; set; }

        [Inject]
        public required ICoiffeurBlattFactory CoiffeurBlattFactory { get; set; }

        private OcrRecognitionResult? OcrResult { get; set; }

        private async Task HandlePictureAsync(Picture arg)
        {
            _picture = arg;
        }

        private async Task AnalyzeAsync()
        {
            using var ms = new MemoryStream(_picture.Data);
            OcrResult = await VisionProxy.RecognizeAsync(ms);
            CoiffeurBlatt = await CoiffeurBlattFactory.CreateAsync(OcrResult);
        }
    }
}

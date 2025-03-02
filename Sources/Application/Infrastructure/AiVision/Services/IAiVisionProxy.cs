using Mmu.JassBuddy2.Infrastructure.AiVision.Models;

namespace Mmu.JassBuddy2.Infrastructure.AiVision.Services
{
    public interface IAiVisionProxy
    {
        Task<OcrRecognitionResult> RecognizeAsync(Stream stream);
    }
}
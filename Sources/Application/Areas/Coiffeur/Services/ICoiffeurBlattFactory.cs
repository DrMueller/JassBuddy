using Mmu.JassBuddy2.Areas.Coiffeur.Models;
using Mmu.JassBuddy2.Infrastructure.AiVision.Models;

namespace Mmu.JassBuddy2.Areas.Coiffeur.Services
{
    public interface ICoiffeurBlattFactory
    {
        Task<CoiffeurBlatt> CreateAsync(OcrRecognitionResult ocrResult);
    }
}

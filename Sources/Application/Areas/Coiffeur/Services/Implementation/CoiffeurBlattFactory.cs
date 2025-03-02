using Mmu.JassBuddy2.Areas.Coiffeur.Models;
using Mmu.JassBuddy2.Infrastructure.AiVision.Models;

namespace Mmu.JassBuddy2.Areas.Coiffeur.Services.Implementation
{
    public class CoiffeurBlattFactory : ICoiffeurBlattFactory
    {
        public Task<CoiffeurBlatt> CreateAsync(OcrRecognitionResult ocrResult)
        {
            return Task.FromResult<CoiffeurBlatt>(null);
        }
    }
}
namespace Mmu.JassBuddy2.Infrastructure.AiVision.Models
{
    public record OrcRecognitionWord(string Text);

    public record OrcRecognitionLine(IReadOnlyCollection<OrcRecognitionWord> Words);

    public record OrcRecognitionBlock(IReadOnlyCollection<OrcRecognitionLine> Lines);

    public record OcrRecognitionResult(IReadOnlyCollection<OrcRecognitionBlock> Blocks);
}
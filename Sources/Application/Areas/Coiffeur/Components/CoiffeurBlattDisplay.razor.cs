using Microsoft.AspNetCore.Components;
using Mmu.JassBuddy2.Areas.Coiffeur.Models;

namespace Mmu.JassBuddy2.Areas.Coiffeur.Components
{
    public partial class CoiffeurBlattDisplay
    {
        [Parameter]
        [EditorRequired]
        public required CoiffeurBlatt Blatt { get; set; }
    }
}

namespace Mmu.JassBuddy2.Areas.Coiffeur.Models
{
    public record CoiffeurTeams(string Team1, string Team2);
    public record CoiffeurLinie(string Jass, int? PunkteTeam1, int? PunkteTeam2);
    public record CoiffeurBlatt(CoiffeurTeams Teams, IReadOnlyCollection<CoiffeurLinie> Linien)
    {
        public int Team1Punkte => Linien.Sum(f => f.PunkteTeam1 ?? 0);
        public int Team2Punkte => Linien.Sum(f => f.PunkteTeam2 ?? 0);
    }
}

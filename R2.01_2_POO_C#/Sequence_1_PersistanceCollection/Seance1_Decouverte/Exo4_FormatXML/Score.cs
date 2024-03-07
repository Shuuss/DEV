namespace Exo4_FormatXML;

public class Score : IComparable<Score>
{
    private int nbPoints;
    private String prenom;

    public Score(int nbPoints, string prenom)
    {
        NbPoints = nbPoints;
        Prenom = prenom;
    }
    
    public Score()
    {
        NbPoints = 0;
        Prenom = "unknown";
    }

    public int NbPoints { get => nbPoints; set => nbPoints = value; }
    public string Prenom { get => prenom; set => prenom = value; }

    public int CompareTo(Score? other)
    {
        if (other == null)
            throw new ArgumentNullException("score ne doit pas être null");
        return this.NbPoints.CompareTo(other.NbPoints);
    }

    public override bool Equals(object? obj)
    {
        return obj is Score score &&
               NbPoints == score.NbPoints &&
               Prenom == score.Prenom;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(NbPoints, Prenom);
    }

    public override string? ToString()
    {
        return $"{Prenom} a fait un score de {NbPoints}";
    }


}
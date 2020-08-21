namespace AvgWords.Core.Repos.Interfaces
{
    public interface ILyricsRepo
    {
        string Get(string artist, string title);
    }
}



namespace Jukebox_Project
{
    public class Song
    {
        string title, artist, genre;
        int releaseYear, songNum, timesPlayed;
        double playtime;

        public Song(string title, string artist, string genre, int releaseYear, double playtime, int songNum, int timesPlayed)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            ReleaseYear = releaseYear;
            Playtime = playtime;
            SongNum = songNum;
            TimesPlayed = timesPlayed;
            
        }

        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrEmpty(title))
                {
                    throw new Exception("title cannot be null");
                }
                title = value;
            }

        }
        public string Artist
        {
            get => artist;
            set
            {
                if (string.IsNullOrEmpty(artist))
                {
                    throw new Exception("artist cannot be null");
                }
                artist = value;
            }
        }

        public string Genre
        {
            get => genre;
            set
            {
                if (string.IsNullOrEmpty(genre))
                {
                    throw new Exception("genre cannot be null");
                }
                genre = value;
            }
        }
        public int ReleaseYear
        {
            get => releaseYear;
            set
            {
                if (releaseYear < 1950 || releaseYear > DateTime.Now.Year)
                {
                    throw new Exception("Invalid release year");
                }
                releaseYear = value;
            }

        }
        public int SongNum
        {
            get => songNum;
            set
            {
                if (songNum < 0)
                {
                    throw new Exception("song number cannot be negative");
                }
                songNum = value;
            }
        }
        public int TimesPlayed
        {
            get => timesPlayed;
            set
            {
                if(timesPlayed < 0)
                {
                    throw new Exception("invalid times played entry");
                }
                timesPlayed = value;
            }
        }
        public double Playtime
        {
            get => playtime;
            set
            {
                if (playtime == 0)
                {
                    throw new Exception("Song playtime cannot be zero");
                }
                playtime = value;
            }
        }

        public override string ToString()
        {
            return $"{Title} performed by {Artist} in {ReleaseYear}. ({Playtime}) Category: {Genre}";
        }

    }
}

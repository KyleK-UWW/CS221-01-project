using System.ComponentModel.Design;
using System.Media;
using Jukebox_Project;

public static class Jukebox
{
    private static int GetLineCount(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("File does not exist at: " + Path.GetFullPath(path));
            throw new FileNotFoundException("cannot find file", path);
        }
        int count = 0;
        using StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            reader.ReadLine();
            count++;
        }
        return count;
    }
    private static void Main()
    {
        string path = "Jukebox Playlist.csv"; //.csvfile not audio!
        int lineCount = GetLineCount(path);

        Song[] playlist = new Song[lineCount - 1];
        string[] wavName = new string[playlist.Length];
        SoundPlayer player = new SoundPlayer();

        try
        {
            using StreamReader reader = new StreamReader(path);
            reader.ReadLine();
            for (int i = 0; i < playlist.Length; i++)
            {
                string line = reader.ReadLine();
                string[] cols = line.Split(',');

                string title = cols[0];
                double playtime = double.Parse(cols[1]);
                string artist = cols[2];
                int releaseYear = int.Parse(cols[3]);
                string genre = cols[4];
                wavName[i] = cols[5];
                int songNum = i + 1;
                int timesPlayed = 0; //initial setting for tracking song history..

                playlist[i] = new Song(title, artist, genre, releaseYear, playtime,songNum,timesPlayed);

            }


        }
        catch
        {
            Console.WriteLine("Error reading from file", path);

            return;

        }

        Console.WriteLine("Current playlist:");
        for (int i = 0; i < playlist.Length; i++) 
        {
            if (playlist[i].Genre == "Alt/Indie")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            if (playlist[i].Genre == "Hip-Hop")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            if (playlist[i].Genre == "Rock")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            if (playlist[i].Genre == "Metal")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            if (playlist[i].Genre == "Pop")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            if (playlist[i].Genre == "Game")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            Console.WriteLine($"{playlist[i].SongNum}\t{playlist[i]}");
            Console.ResetColor();
        }

        
        while (true)
        {
            Console.WriteLine("\nPlease enter Song Number you wish to play:");

            string input = Console.ReadLine();
            int selection = int.Parse(input)-1;
            player.SoundLocation = wavName[selection];

            if (playlist.Length > selection && selection >= 0)
            {
                if (playlist[selection].Genre == "Alt/Indie")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                if (playlist[selection].Genre == "Hip-Hop")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                if (playlist[selection].Genre == "Rock")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                if (playlist[selection].Genre == "Metal")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                if (playlist[selection].Genre == "Pop")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                if (playlist[selection].Genre == "Game")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                Console.WriteLine($"\nNow playing:\t{playlist[selection]}");
                Console.ResetColor();

                player.Play();
                Console.WriteLine("Press the any key to stop...");
                Console.ReadKey();
                player.Stop();
                playlist[selection].TimesPlayed++;
                //stretch goal for screen color change based on song genre would happen here...
            }
            else
            {
                Console.WriteLine("Invalid Song selection, please try again!");
            }

        }
       
    }


}

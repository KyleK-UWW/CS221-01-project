using System.ComponentModel.Design;
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
            Console.WriteLine($"{playlist[i].SongNum}\t{playlist[i]}");

        }

        
        while (true)
        {
            Console.WriteLine("\nPlease enter Song Number you wish to play:");

            string input = Console.ReadLine();
            int selection = int.Parse(input)-1;

            if (playlist.Length > selection && selection >= 0)
            {
                //song trigger happens here inside if{}
                Console.WriteLine($"\nNow playing:\t{playlist[selection]}");
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

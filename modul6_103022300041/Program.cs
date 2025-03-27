using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

public class SayaTubeVideo {
    private int id;
    public int playCount;
    public string title;

    public SayaTubeVideo(string title) {

        Debug.Assert(!string.IsNullOrEmpty(title) && title.Length <= 200, "Judul video tidak boleh null atau lebih dari 200 karakter.");
        Random random = new Random();
        this.id = random.Next(10000, 100000);
        this.title = title;
        this.playCount = 0;
    }

    public void increasePlayCount(int increment) {

        Debug.Assert(!(increment<0) && increment > 0 && increment < 25000000);

        try {
            checked {
                this.playCount += increment;
            }
        }
        catch (OverflowException e)
        {
            Console.WriteLine("Overflow terjadi");
        }
        
    }

    public void printVideoDetails()
    {
        Console.WriteLine("Video ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}

public class SayaTubeUser {
    private int id;
    private string Username;
    private List<SayaTubeVideo> uploadVideos;
    public SayaTubeUser(string user)
    {

        Debug.Assert(!string.IsNullOrEmpty(user) && user.Length <= 100, "Username tidak boleh null atau lebih dari 100 karakter.");
        Random random = new Random();
        this.id = random.Next(10000, 100000);
        this.uploadVideos = new List<SayaTubeVideo>();
        this.Username = user;
    }

    public int getTotalVideoPlayCount()
    {
        int total=0;
        for (int i = 0; i < uploadVideos.Count; i++)
        {
            total += uploadVideos[i].playCount;
        }
        return total;
    }

    public void addVideo(SayaTubeVideo video) {
        Debug.Assert(video != null && video.playCount < int.MaxValue);
        this.uploadVideos.Add(video);
    }

    public void PrintAllVideoPlaycount() {
        Console.WriteLine("User: " + Username);
        for (int i = 0; i < uploadVideos.Count; i++)
        {
            Console.WriteLine($"Video {i + 1} judul: {uploadVideos[i].title}");
        }
    }
}

public class Program {
    public static void Main(string[] args) {

        try {
            SayaTubeVideo film1 = new SayaTubeVideo("Spiderman 8");
            SayaTubeUser user1 = new SayaTubeUser("Adrian");
            for (int i = 0; i < 10; i++)
            {
                film1.increasePlayCount(25000000);
            }
            film1.printVideoDetails();
        } 
        catch(Exception e)
        {
            Console.WriteLine("Terjadi Error: " + e.Message);
        }

    }
}
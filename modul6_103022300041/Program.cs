using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

public class SayaTubeVideo {
    private int id;
    public int playCount;
    public string title;

    public SayaTubeVideo(string title) {
        Random random = new Random();
        this.id = random.Next(10000, 100000);
        this.title = title;
        this.playCount = 0;
    }

    public void increasePlayCount(int increment) {
        this.playCount += increment;
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
        SayaTubeUser user1 = new SayaTubeUser("Adrian");
        SayaTubeVideo film1 = new SayaTubeVideo("Spiderman 2 oleh Adrian");
        film1.increasePlayCount(10);
        film1.printVideoDetails();
        SayaTubeVideo film2 = new SayaTubeVideo("Spiderman 3 oleh Adrian");
        film2.increasePlayCount(4);
        film2.printVideoDetails();
        user1.addVideo(film1);
        user1.addVideo(film2);
        Console.WriteLine("Total video PlayCount: " + user1.getTotalVideoPlayCount());
        user1.PrintAllVideoPlaycount();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ItunesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Music perfect = new Music("Perfect", "Ed Sheeran", 50);
            // activating itunes notifications (creating object)
            ItunesNotifications myItunesNotif = new ItunesNotifications();
            //adding functions to the invoke list of the event
            perfect.Listened += myItunesNotif.SendingMessage;

            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                perfect.Listening();
            }
        }
    }
    public class Music
    {
        //creating a delegate
        public delegate void MusicListenedEventHandler(object source, EventArgs args, Music song);
        //creating an event upon the delegate
        public event MusicListenedEventHandler Listened;

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
        }
        private string author;
        public string Author
        {
            get
            {
                return author;
            }
        }
        private int timeLength;
        public int TimeLength
        {
            get
            {
                return timeLength;
            }
        }
        public Music(string _title, string _author, int _timeLength)
        {
            this.title = _title;
            this.author = _author;
            this.timeLength = _timeLength;
        }
        public void Listening()
        {
            Console.WriteLine("Listening to {0}", this.Title);
            for(int i = 0; i <= this.TimeLength; i+=10)
            {
                Console.WriteLine(i + "seconds have been played");
                Thread.Sleep(10000);
            }
            Console.WriteLine("Song Finished!");
            OnListened();
        }
        protected virtual void OnListened()
        {
            if(this.Listened != null)
            {
                this.Listened(this, EventArgs.Empty, this);
            }
        }
    }
    public class ItunesNotifications
    {
        public void SendingMessage(object source, EventArgs args, Music song)
        {
            Console.WriteLine("Do you want to add {0} by {1} to Itunes Playlist?", song.Title, song.Author);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EventApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Setup();
        }

        private List<Event> AllEvents { get; set; }

        private List<Event> GetEvents()
        {
            return new List<Event>()
            {
                new Event{ EventTitle = "Camping", BgColor = "#EB9999", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(12, 23, 45, 59).Ticks)},
                new Event{ EventTitle = "Tony's Wedding", BgColor = "#96338F", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(270, 1, 22, 10).Ticks)},
                new Event{ EventTitle = "Hackathon", BgColor = "#8251AE", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(48, 11, 15, 0).Ticks)},
                new Event{ EventTitle = "Exams", BgColor = "#6787FF", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(2, 17, 29, 45).Ticks)},
            };
        }

        private void Setup()
        {
            AllEvents = GetEvents();
            eventList.ItemsSource = AllEvents;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                foreach (var evt in AllEvents)
                {
                    var timespan = evt.Date - DateTime.Now;
                    evt.Timespan = timespan;
                }

                eventList.ItemsSource = null;
                eventList.ItemsSource = AllEvents;

                return true;
            });
        }
    }

    public class Event
    {
        public DateTime Date { get; set; }
        public string EventTitle { get; set; }
        public TimeSpan Timespan { get; set; }
        public string Days => Timespan.Days.ToString("00");
        public string Hours => Timespan.Hours.ToString("00");
        public string Minutes => Timespan.Minutes.ToString("00");
        public string Seconds => Timespan.Seconds.ToString("00");
        public string BgColor { get; set; }
    }
}

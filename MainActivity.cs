using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Content;

namespace AndroidCalendar
{
    [Activity(Label = "AndroidCalendar", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        MediaPlayer player;
        //Button evalButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var calendarView = FindViewById<CalendarView>(Resource.Id.calendarView);
            var txtDisplay = FindViewById<TextView>(Resource.Id.txtDisplay);

            Button noteButton = FindViewById<Button>(Resource.Id.noteButton);
            noteButton.Click += (sender, e) => 
            {
                Intent secondIntent = new Intent(this, typeof(noteActivity));
                this.StartActivity(secondIntent);
            };

            Button evalButton = FindViewById<Button>(Resource.Id.evaluateButton);
            evalButton.Click += (sender, e) =>
            {
                Intent firstIntent = new Intent(this, typeof(evaluateActivity));
                this.StartActivity(firstIntent);
            };

            txtDisplay.Text = "Date: ";
            calendarView.DateChange += (s, e) =>
            {
                int day = e.DayOfMonth;
                int month = e.Month;
                int year = e.Year;
                txtDisplay.Text = "Date: " + day + "/" + month + "/" + year;
            };

            player = MediaPlayer.Create(this, Resource.Raw.adele_hello);

            Button button = FindViewById<Button>(Resource.Id.playButton);
            button.Click += (sender, e) =>
            {
                player.Start();
            };

            Button buttonPause = FindViewById<Button>(Resource.Id.pauseButton);
            buttonPause.Click += (sender, e) =>
            {
                player.Pause();
            };

            Button buttonStop = FindViewById<Button>(Resource.Id.stopButton);
            buttonStop.Click += (sender, e) =>
            {
                player.Stop();
            };

            player.Release();

        }
    }
}


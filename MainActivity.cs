using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidCalendar
{
    [Activity(Label = "AndroidCalendar", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var calendarView = FindViewById<CalendarView>(Resource.Id.calendarView);
            var txtDisplay = FindViewById<TextView>(Resource.Id.txtDisplay);

            txtDisplay.Text = "Date: ";
            calendarView.DateChange += (s, e) =>
            {
                int day = e.DayOfMonth;
                int month = e.Month;
                int year = e.Year;
                txtDisplay.Text = "Date: " + day + " / " + month + " / " + year;
            };

        }
    }
}


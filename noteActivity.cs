using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;
using Android.Views;
using Android.Support.V7.App;
using Java.Util;
using Android.Graphics;
using static Android.App.DatePickerDialog;

namespace AndroidCalendar
{
    [Activity(Label = "noteActivity")]// Theme = "@style/Theme.AppCompact.Light.NoActionBar")]
    public class noteActivity : Activity//,IOnDateSetListener
    {

        //Calendar currenDate;
        //EditText dateEditTxt;
        /*
		public void OnDate(DatePicker view, int year, int month, int dayOfmonth)
		{
            dateEditTxt.Text = $"{dayOfmonth} - {month + 1} - {year}";
            currenDate.Set(year, month, dayOfmonth);
		}
        */
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.noteLayout);

            Button saveButton = FindViewById<Button>(Resource.Id.saveButton);
            saveButton.Click += delegate
            {
                //get info from the boxes
                EditText txtTitle = FindViewById<EditText>(Resource.Id.txtTitle);
                string title = txtTitle.Text;
                EditText txtDate = FindViewById<EditText>(Resource.Id.txtStartDate);
                string date = txtDate.Text;
                EditText txtDescription = FindViewById<EditText>(Resource.Id.txtDescription);
                string description = txtDescription.Text;

                //add new events to the share preferences
                var localEvents = Application.Context.GetSharedPreferences("MyEvent", FileCreationMode.Private);
                var eventEdit = localEvents.Edit();
                eventEdit.PutString("Title", title);
                eventEdit.PutString("Date", date);
                eventEdit.PutString("Description", description);
                eventEdit.Commit();

                //carete a toast notification to comfrim the submission
                Android.Widget.Toast.MakeText(this, "Note Added", ToastLength.Short).Show();

                //clear the boxes of the text
                txtTitle.Text = "";
                txtDate.Text = "";
                txtDescription.Text = "";
            };

            Button viewButton = FindViewById<Button>(Resource.Id.showButton);
            viewButton.Click += (sender, e) => 
            {
                Intent intent = new Intent(this, typeof(noteListActivity));
                this.StartActivity(intent);
            };


                
            //dateEditTxt = FindViewById<TextView>(Resource.Id.txtStartDate);
            //var txtEndDate = FindViewById<TextView>(Resource.Id.txtEndDate);

            //txtEndDate = dateEditTxt;
            /*
            dateEditTxt = FindViewById<EditText>(Resource.Id.txtStartDate);
            dateEditTxt.Click += delegate 
            {
                currenDate = Calendar.Instance;
                int CalendarYear = currenDate.Get(CalendarField.Year);
                int CalendarMonth = currenDate.Get(CalendarField.Month);
                int CalendardayOfmonth = currenDate.Get(CalendarField.DayOfMonth);

                //DatePickerDialog mDate = new DatePickerDialog(this, this, CalendarYear, CalendarMonth, CalendardayOfmonth);
                //mDate.Show();
            };*/

        }


    }
}

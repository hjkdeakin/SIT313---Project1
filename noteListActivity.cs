using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidCalendar
{
    [Activity(Label = "noteActivity")]
    public class noteListActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            //retrieve the information from shared preferences
            var localEvents = Application.Context.GetSharedPreferences("MyEvent", FileCreationMode.Private);
            string title = localEvents.GetString("Title", null);
            string date = localEvents.GetString("Date", null);
            string description = localEvents.GetString("Description", null);

            noteData myData = new noteData(title, date, description);

            //create an array of items that will go in my list
            noteData[] dataList = { myData };
            ListAdapter = new ArrayAdapter<noteData>(this, Android.Resource.Layout.SimpleListItem1, dataList);

            // Create your application here
            //SetContentView(Resource.Layout.noteListLayout);
        }
    }
}
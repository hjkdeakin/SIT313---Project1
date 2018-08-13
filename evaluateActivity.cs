
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
    [Activity(Label = "evaluateActivity")]
    public class evaluateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.evaluate);

            var ratingBar = FindViewById<RatingBar>(Resource.Id.ratingBar);
            var submitButton = FindViewById<Button>(Resource.Id.submitButton);
            var txtRate = FindViewById<TextView>(Resource.Id.txtPoint);

            submitButton.Click += (sender, e) => 
            {
                string ratingValue = ratingBar.Rating.ToString();
                txtRate.Text = "Rate: " + ratingValue;
            };

        }
    }
}

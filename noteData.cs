using System;

namespace AndroidCalendar
{
    public class noteData
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }

        public noteData(string _title, string _date, string _description)
        {
            Title = _title;
            Date = _date;
            Description = _description;
        }

        public override string ToString()
        {
            return "Title: " + Title + "\n" + "Date: " + Date + "\n" + "Event: " + Description + "\n" + "\n";
            //return string.Format("[noteData: Title={0}, Date={1}, Description={2}]", Title, Date, Description);
        }
    }
}

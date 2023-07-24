using System;
using System.Collections.Generic;
using System.Configuration;
using KGySoft.ComponentModel;

namespace ConnectorLibrary.Utilities
{
    /// <summary>
    /// Class for storing and updating the activity list
    /// </summary>
    public static class ActivityLog
    {
        // List of statuses sent to the Filters form
        public static SortableBindingList<string> activityList = new SortableBindingList<string>();

        // Filtered list depending on Filters set in the Filters form
        public static List<string> filteredList = new List<string>();

        // Seach list depends on user input into the search field 
        public static List<string> searchList = new List<string>();

        // Method to clear the list if it exceeds 5000 entries
        public static void ClearActivityList()
        {
            if (activityList.Count > Common.ACTIVITY_LENGTH)
            {
                activityList.Clear();
            }
        }

        /// <summary>
        /// Method for creating the string that is added to the activity list
        /// </summary>
        /// <param name="activity"></param>
        public static void activityListText(string activity)
        {
            activityList.Add($"{ DateTime.Now.ToString("yyy-MM-dd hh:mm:ss.ff") }    { activity }");
        }
    }
}

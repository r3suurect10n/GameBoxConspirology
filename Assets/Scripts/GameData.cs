using System.Collections.Generic;

public static class GameData
{
    #region DateCounter
    public static int startDay = 1;
    public static int startMonth = 6;
    public static int year = 2025;

    public static int currentDay;
    public static int currentMonth;

    public static void SetStartDay()
    {
        currentDay = startDay;
        currentMonth = startMonth;
    }

    public static void SetNextDay()
    {
        if (currentDay <= 30)
            currentDay++;
        else
        {
            currentMonth++;
            currentDay = startDay;
        }
    }
    #endregion

    #region NotebookFill
    public static Dictionary<int, List<string>> notebook;
    public static int notesCounter;

    public static void ClearNotebook()
    {
        notebook.Clear();
        notesCounter = 0;
    }

    public static void AddNote(string name, string date, string events, string place)
    {
        List<string> note = new List<string>();

        note.Add(name);
        note.Add(date);
        note.Add(events);
        note.Add(place);

        notebook.Add(notesCounter, note);
        notesCounter++;
    }

    #endregion
}

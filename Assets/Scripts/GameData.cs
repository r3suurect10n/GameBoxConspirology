using System;
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
    public static Action OnAddNote;

    public static Dictionary<int, List<string>> notebook;
    public static int notesCounter;

    public static void InitializeNotebook()
    {
        if (notebook == null)
            notebook = new Dictionary<int, List<string>>();
        else if (notebook.Count > 0)
            notebook.Clear();

        notesCounter = 0;
    }   

    public static void AddNote(string name, string place, string events, string date)
    {
        if (notebook.Count != 0)
        {
            foreach (List<string> note in notebook.Values)
            {
                if (note.Contains(name) && note.Contains(place) && note.Contains(date))
                    return;
            }
        }

        List<string> newNote = new List<string> {name, place, events, date};        

        notebook.Add(notesCounter, newNote);

        OnAddNote?.Invoke();

        notesCounter++;        
    }

    #endregion   
}

using UnityEngine;

public class NoteContent : MonoBehaviour
{
    [SerializeField] private string _humanName;
    [SerializeField] private string _placeName;
    [SerializeField] private string _eventName;
    [SerializeField] private string _day;

    public void OnNoteAdd()
    {        
        GameData.AddNote(_humanName, _placeName, _eventName, _day);        
    }
}

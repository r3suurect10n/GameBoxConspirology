using UnityEngine;

public class AddNotes : MonoBehaviour
{
    [SerializeField] private string _humanName;
    [SerializeField] private string _placeName;
    [SerializeField] private string _eventName;
    [SerializeField] private string _day;

    [SerializeField] private bool _isNoteAdded = false;

    public void OnNoteAdd()
    {
        if (!_isNoteAdded)
        {
            GameData.AddNote(_humanName, _placeName, _eventName, _day);
            _isNoteAdded = true;
        }
    }
}

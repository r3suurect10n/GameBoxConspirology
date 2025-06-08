using UnityEngine;

public class AddNote : MonoBehaviour
{
    public void AddNoteToBook(NoteContent noteContentItem)
    {
        noteContentItem.OnNoteAdd();
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _notes;

    private void Start()
    {
        FillNote();
    }

    private void FillNote()
    {
        for (int i = 0; i < _notes.Length; i++)
        {
            Text[] noteColumns = _notes[i].GetComponentsInChildren<Text>();

            if (GameData.notebook.ContainsKey(i))
            {
                List<string> noteData = GameData.notebook[i];

                for (int j = 0; j < noteColumns.Length; j++)
                {
                    noteColumns[j].text = noteData[j];
                }
            }
        }
    }
}

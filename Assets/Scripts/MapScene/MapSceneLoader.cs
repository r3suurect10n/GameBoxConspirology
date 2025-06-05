using UnityEngine;
using UnityEngine.UI;

public class MapSceneLoader : MonoBehaviour
{
    [SerializeField] private Text _dateText;    

    private void Awake()
    {
        OnSceneLoad();
    }

    private void OnSceneLoad()
    {
        _dateText.text = $"{GameData.currentDay:00}.{GameData.currentMonth:00}.{GameData.year:0000}";
    }
}

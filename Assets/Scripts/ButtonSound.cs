using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;   

    public void OnButtonClick(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}

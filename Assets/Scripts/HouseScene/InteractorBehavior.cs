using System;
using UnityEngine;

public class InteractorBehavior : MonoBehaviour
{
    public static Action<string> OnExit;

    [SerializeField] private PanelFader _fader;

    private Animator _interactorAnim;

    private bool _interactorIsOpen = false;

    private void Start()
    {
        if (gameObject.GetComponent<Animator>() != null)
        {
            _interactorAnim = GetComponent<Animator>();
            _interactorAnim.SetBool("Opening", _interactorIsOpen);
        }
    }

    public void InteractorOpenClose()
    {
        if (gameObject.GetComponent<Animator>())
        {
            _interactorIsOpen = !_interactorIsOpen;
            _interactorAnim.SetBool("Opening", _interactorIsOpen);
        }
        else
        {
            GameData.SetNextDay();
            OnExit?.Invoke("MapScene");
        }

    }
}

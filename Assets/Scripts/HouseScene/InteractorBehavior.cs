using UnityEngine;

public class InteractorBehavior : MonoBehaviour
{
    private Animator _interactorAnim;

    private bool _interactorIsOpen = false;

    private void Start()
    {
        _interactorAnim = GetComponent<Animator>();
        _interactorAnim.SetBool("Opening", _interactorIsOpen);
    }

    public void InteractorOpenClose()
    {
        _interactorIsOpen = !_interactorIsOpen;
        _interactorAnim.SetBool("Opening", _interactorIsOpen);
    }
}

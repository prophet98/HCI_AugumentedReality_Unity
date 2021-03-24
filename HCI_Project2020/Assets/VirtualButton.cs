
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
public class VirtualButton : MonoBehaviour
{
    public GameObject virtualButton;
    public UnityEvent onPushButton;
    private void Start()
    {
        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(ButtonPressed);
        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(ButtonReleased);
    }

    private void ButtonPressed(VirtualButtonBehaviour virtualButtonBehaviour)
    {
        Debug.Log("Premuto!");
        onPushButton.Invoke();
    }
    private void ButtonReleased(VirtualButtonBehaviour virtualButtonBehaviour)
    {
        Debug.Log("Lasciato!");
    }
}

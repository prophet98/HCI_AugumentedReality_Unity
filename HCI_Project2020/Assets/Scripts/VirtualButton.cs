
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
    }

    private void ButtonPressed(VirtualButtonBehaviour virtualButtonBehaviour)
    {
        Debug.Log("Premuto!");
        onPushButton.Invoke();
    }

    public void AlignButtonAndTableRotation()
    {
        this.GetComponentInParent<Transform>().localRotation = Quaternion.identity;
    }
}

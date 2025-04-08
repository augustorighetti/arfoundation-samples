using UnityEngine;
using UnityEngine.UI;

public class IdToggleManager : MonoBehaviour
{
    public void SwitchToggleState()
    {
        // Get the current state of the toggle
        GetComponent<Toggle>().isOn = !GetComponent<Toggle>().isOn;
    }
}

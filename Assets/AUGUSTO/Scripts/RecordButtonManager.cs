using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RecordButtonManager : MonoBehaviour
{

    [SerializeField] private Sprite defaultIcon;
    [SerializeField] private Sprite closeIcon;

    [SerializeField] private TMP_InputField id_InputField;

    public UnityEvent onRecordButtonClicked;

    public void ToggleRecord()
    {
        if (GetComponentInParent<Image>().sprite.Equals(closeIcon))
        {
            //settingsPanel.SetActive(false);
            GetComponent<Image>().sprite = defaultIcon;
            onRecordButtonClicked.Invoke();
        }
        else
        {
            //settingsPanel.SetActive(true);
            GetComponent<Image>().sprite = closeIcon;
            onRecordButtonClicked.Invoke();
        }
    }

    public void ToggleIdInputField()
    {
        id_InputField.enabled = !id_InputField.enabled;
        //id_InputField.gameObject.SetActive(!id_InputField.gameObject.activeSelf);
    }

}
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelManager : MonoBehaviour
{

    [SerializeField] private Sprite defaultIcon;
    [SerializeField] private Sprite closeIcon;
    [SerializeField] private GameObject settingsPanel;

    public void ToggleSettingsPanel()
    {
        if (settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
            GetComponent<Image>().sprite = defaultIcon;
        }
        else
        {
            settingsPanel.SetActive(true);
            GetComponent<Image>().sprite = closeIcon;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class StatusVisibilityManager : MonoBehaviour
{

    [SerializeField] private Sprite visibleIcon;
    [SerializeField] private Sprite hidedIcon;
    [SerializeField] private GameObject statusText;

    public void ToggleSettingsPanel()
    {
        if (statusText.activeSelf)
        {
            statusText.SetActive(false);
            GetComponent<Image>().sprite = hidedIcon;
        }
        else
        {
            statusText.SetActive(true);
            GetComponent<Image>().sprite = visibleIcon;
        }
    }
}

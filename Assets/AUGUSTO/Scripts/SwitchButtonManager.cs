using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SwitchButtonManager : MonoBehaviour
{
    [SerializeField] private Sprite goLeft_Sprite;
    [SerializeField] private Sprite goRightSprite;
    [SerializeField] private RectTransform group_RectTransform;
    [SerializeField] private RectTransform switchButton_RectTransform;

    //on button click, switch the sprite of the button

    public void SwitchSprite()
    {
        Image[] ll = transform.GetComponentsInChildren<Image>();
        Sprite currentSprite = ll[1].sprite;


        if (currentSprite == goLeft_Sprite)
        {
            ll[1].sprite = goRightSprite;
            
            // Move the group to the left
            group_RectTransform.anchorMin = new Vector2(0.03f, 0.03f);
            group_RectTransform.anchorMax = new Vector2(0.38f, 0.33f);
            //m_RectTransform.pivot = new Vector2(0.5f, 0.5f);
            //m_RectTransform.offsetMin = Vector2.zero;  // Remove deslocamento da borda inferior/esquerda  
            //m_RectTransform.offsetMax = Vector2.zero;  // Remove deslocamento da borda superior/direita

            //Move the button to the left
            switchButton_RectTransform.anchorMin = new Vector2(0, 1);
            switchButton_RectTransform.anchorMax = new Vector2(0, 1);
            switchButton_RectTransform.anchoredPosition = new Vector2(90, 50);
        }
        else
        {
            ll[1].sprite = goLeft_Sprite;

            // Move the group to the right
            group_RectTransform.anchorMin = new Vector2(0.62f, 0.03f);
            group_RectTransform.anchorMax = new Vector2(0.97f, 0.33f);

            //Move the button to the right
            switchButton_RectTransform.anchorMin = new Vector2(1, 1);
            switchButton_RectTransform.anchorMax = new Vector2(1, 1);
            switchButton_RectTransform.anchoredPosition = new Vector2(10, 50);
        }
    }
}

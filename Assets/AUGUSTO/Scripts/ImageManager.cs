using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    
    private Vector2 originalSize;
    private Vector3 originalPosition;
    private bool isExpanded = false;
    
    private Vector2 originalAnchoredPosition;
    private Vector2 dragOffset;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        
        // Salva o tamanho e posição original
        originalSize = rectTransform.sizeDelta;
        originalPosition = rectTransform.position;
        originalAnchoredPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Ignora drag se estiver expandido
        if (isExpanded)
            return;
            
        // Reduz ligeiramente a opacidade durante o arrasto
        canvasGroup.alpha = 0.8f;
        
        // Calcula o offset entre o ponto clicado e a posição do objeto
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out dragOffset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Ignora drag se estiver expandido
        if (isExpanded)
            return;
            
        // Calcula nova posição baseada na posição do mouse e offset
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera,
            out localPointerPosition))
        {
            rectTransform.anchoredPosition = localPointerPosition - dragOffset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Restaura a opacidade
        canvasGroup.alpha = 1.0f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Toggle entre tamanho normal e expandido
        if (!isExpanded)
        {
            ExpandImage();
        }
        else
        {
            RestoreImage();
        }
    }

    private void ExpandImage()
    {
        // Salva a posição atual antes de expandir
        originalAnchoredPosition = rectTransform.anchoredPosition;
        
        // Expande a imagem para preencher o canvas
        RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
        
        // Centraliza a imagem
        rectTransform.anchoredPosition = Vector2.zero;
        // Define o tamanho para o tamanho do canvas
        rectTransform.sizeDelta = canvasRectTransform.sizeDelta;
        
        // Marca como expandido
        isExpanded = true;
        
        // Traz para a frente
        transform.SetAsLastSibling();
    }

    private void RestoreImage()
    {
        // Restaura ao tamanho e posição original
        rectTransform.sizeDelta = originalSize;
        rectTransform.anchoredPosition = originalAnchoredPosition;
        
        // Marca como não expandido
        isExpanded = false;
    }
}

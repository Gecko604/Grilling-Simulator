using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTransitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{

    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.grey;
    public Color32 m_DownColor = Color.white;

    private Image m_Image = null;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        m_Image.color = m_HoverColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");

        m_Image.color = m_DownColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");

        m_Image.color = m_HoverColor;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");

        m_Image.color = m_NormalColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Window : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rectTransform;
    private bool isDragging = false;
    public Vector2 offset;
    public Canvas canvas;
    public Button XButton;

    public List<Button> buttons;

    public File thisFile = null;

    public List<Sprite> sprites = new List<Sprite>();

    private void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();

        if (XButton == null)
        {
            XButton = GetComponent<Button>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPointerPosition);
        offset = rectTransform.anchoredPosition - localPointerPosition;

        rectTransform.SetAsLastSibling();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            //Debug.Log("Parent: " + canvas.transform);
            //Debug.Log("Parent as RectTransform: " + (canvas.transform as RectTransform));
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPointerPosition);
            rectTransform.anchoredPosition = localPointerPosition + offset;

        }
    }

    public void Minamize()
    {
        Debug.Log("fick");
        Destroy(this.gameObject);
    }

    public void OpenFileExplorer()
    {
        this.gameObject.SetActive(true);
    }

    public void DrawFiles()
    {
        int count = 0;
        foreach (var file in thisFile.children)
        {
            buttons[count].gameObject.SetActive(true);
            buttons[count].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = file.name;
            switch (file.type)
            {
                case "Folder":

                    buttons[count].gameObject.GetComponent<Image>().sprite = sprites[0];
                    buttons[count].gameObject.GetComponent<Button>().interactable = true;
                    buttons[count].gameObject.GetComponent<Button>().onClick.AddListener(() => transform.parent.GetComponent<DrawWindow>().createWindow(file.ID));
                    break;
                case "Txt":
                    buttons[count].gameObject.GetComponent<Image>().sprite = sprites[1];
                    buttons[count].gameObject.GetComponent<Button>().interactable = false;
                    break;
            }
            count++;
        }
    }

    public void OpenNewWindow()
    {

    }

    public void SetButtons() 
    { 

    }
}

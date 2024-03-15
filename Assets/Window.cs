using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
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
    public GameObject FileManager;

    public GameObject parent;
    public GameManager gameManager;

    public List<Button> buttons;

    public File thisFile = null;

    public List<Sprite> sprites = new List<Sprite>();

    public File oldFile = null;

    private void Start()
    {
        parent = this.transform.parent.gameObject;
        rectTransform = this.GetComponent<RectTransform>();

        if (XButton == null)
        {
            XButton = GetComponent<Button>();
        }

        foreach (var file in thisFile.children)
        {
            file.parent = gameObject;
        }
    }

    private void Update()
    {
        
    }

    public void Ruin(int ID)
    {
        parent.gameObject.GetComponent<DrawWindow>().curruptableFiles.Remove(ID);
        //Debug.Log($"{parent.gameObject.GetComponent<DrawWindow>().curruptableFiles.Count}");
        var file = parent.gameObject.GetComponent<DrawWindow>().curruptableFiles.ElementAt(Random.Range(0, parent.gameObject.GetComponent<DrawWindow>().curruptableFiles.Count));
        file.Value.type = "Txt-C";
        file.Value.isCurrupting = true;
        //Debug.Log($"{file.Value.ID}, {file.Key}, {file.Value.name}");
    }

    public void Spread(int ID)
    {
        
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
        //Debug.Log("fick");
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
            file.parent = this.gameObject;
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
                case "Txt-C":
                    buttons[count].gameObject.GetComponent<Image>().sprite = sprites[2];
                    buttons[count].gameObject.GetComponent<Button>().interactable = true;
                    buttons[count].gameObject.GetComponent<Button>().onClick.AddListener(() => gainMoney(file,count));
                    break;
                case "Runied":
                    buttons[count].gameObject.GetComponent<Image>().sprite = sprites[3];
                    buttons[count].gameObject.GetComponent<Button>().interactable = false;
                    break;
                case "Deleted":
                    buttons[count].gameObject.GetComponent<Image>().sprite = sprites[4];
                    buttons[count].gameObject.GetComponent<Button>().interactable = false;
                    break;
            }
            count++;
        }
    }

    public void gainMoney(File file, int count) 
    {
        if (file.type == "Txt-C")
        {
            gameManager.UpdateMoney();
            if(Random.Range(0,2) == 0)file.FileManager.GetComponent<DrawWindow>().spread();
            if (file.curruptTimer == 100)
            {
                file.curruptionPercent = 0;
                file.curruptTimer = 40;
            }
        }
        buttons[count].gameObject.GetComponent<Button>().interactable = false;
        file.type = "Txt";
        this.DrawFiles();
    }
}
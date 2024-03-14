using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DrawWindow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rectTransform;
    private bool isDragging = false;
    public Vector2 offset;

    public Canvas canvas;

    public Button XButton;

    public List<Button> buttons;

    Dictionary<int, File> files = new Dictionary<int, File>();

    File thisFile = null;

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();

        if (XButton == null)
        {
            XButton = GetComponent<Button>();
        }

        createFiles();
        thisFile = files[0]; 
        DrawFiles();
    }

    void createFiles() 
    {
        File fileExplorer = new File(0,"Folder","File Explorer");
        File file1 = new File(1,"Folder","Documents");
        File file2 = new File(2,"Folder","Downloads");
        File file3 = new File(3,"Folder","Music");
        File file4 = new File(4,"Folder","Pictures");
        File file5 = new File(5,"Folder","Videos");
        List<File> children = new List<File>();
        children.Add(file1);
        children.Add(file2);
        children.Add(file3);
        children.Add(file4);
        children.Add(file5);
        files.Add(0,fileExplorer);
        files.Add(1,file1);
        files.Add(2,file2);
        files.Add(3,file3);
        files.Add(4,file4);
        files.Add(5,file5);
    }

    void setFile() 
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
        this.gameObject.SetActive(false);
    }
    
    public void OpenFileExplorer() 
    {
        this.gameObject.SetActive(true);
    }

    public void DrawFiles() 
    {
        foreach (var file in thisFile.children) 
        { 
            
        }
    }

    public void OpenNewWindow() 
    { 
    
    }
}

public class File
{
    int ID;
    string type;
    string name;
    //File parent;
    public List<File> children;

    bool isDeleted = false;
    bool isCurrupted = false;
    bool isCurrupting = false;
    float curruptionPercent = 0;

    public File(int _ID, string _type, string _name)
    { 
        ID = _ID;
        type = _type;
        name = _name;
        //parent = _parent;
        children = new List<File>();
        //children = _children;
    }

    public void addChildren() 
    { 
    
    }


}

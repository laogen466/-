using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class randombutton : MonoBehaviour,IPointerExitHandler
{

    public Image _image;
    public Image _BG;
    public Button _randombutton;
    public Transform _weaponchoose;
    public Transform _rolechoose;

    public void OnPointerExit(PointerEventData eventData)
    {
        _BG.color=new (27/255f,27/255f,27/255f);
    }

    // Start is called before the first frame update
    void Awake()
    {
        _image=GetComponent<Transform>().GetChild(0).GetComponent<Image>();
        _BG=GetComponent<Image>();
        _randombutton=GetComponent<Button>();
        _weaponchoose=GameObject.Find("weaponchoose").GetComponent<Transform>();
        _rolechoose=GameObject.Find("rolechoose").GetComponent<Transform>();
    }
    public int  randomweapon()
    {
        int index;
        index=Random.Range(1,Weaponchoose._instance.weapondatas.Count+1);
        return index;
    }
}

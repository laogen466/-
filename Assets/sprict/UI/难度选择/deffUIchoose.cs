
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class deffUIchoose : MonoBehaviour
{
    // Start is called before the first frame update
    private static deffUIchoose instance;
    public static deffUIchoose _instance
    {
        get
        {
            return instance;

        }
    }
    public TextAsset deffasset;
    public List<deffdata> ddata=new List<deffdata>();
    public GameObject deffprefab;
    public Transform deffchoose;
    public Image _desrdeff;
    public Image _paneldiffimage;
    public TextMeshProUGUI _text7;
    public TextMeshProUGUI _text9;
    public CanvasGroup _deffchoosecanvas;
    public CanvasGroup _deffcanvas;


    void Awake()
    {
        instance=this;
        deffasset=Resources.Load<TextAsset>("Data/difficulty");
        deffDataWrapper dedata = JsonUtility.FromJson<deffDataWrapper>(deffasset.text);
        ddata=dedata.items;
        deffprefab=Resources.Load<GameObject>("prefab/deffbutton");
        deffchoose=GameObject.Find("diffchoose").GetComponent<Transform>();
        _desrdeff=GameObject.Find("desrdeff").GetComponent<Image>();
        _text7=GameObject.Find("Text7").GetComponent<TextMeshProUGUI>();
        _text9=GameObject.Find("Text9").GetComponent<TextMeshProUGUI>();
        _deffchoosecanvas=GetComponent<CanvasGroup>();
        _deffcanvas=GameObject.Find("diff").GetComponent<CanvasGroup>();
        _paneldiffimage=GameObject.Find("paneldiffimage").GetComponent<Image>();
    }
    void Start()
    {
        foreach(deffdata d  in ddata)
        {
            deffUIcommd deffUIcommd=Instantiate(deffprefab,deffchoose).GetComponent<deffUIcommd>();
            deffUIcommd.setdata(d);
        }
    }
}

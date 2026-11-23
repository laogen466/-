
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class rolechoose : MonoBehaviour
{
    private static rolechoose instance;
    public static rolechoose getInstance
    {
        get
        {
            return instance;
        } 
    }
    
    private GameObject roleprefab;
    private TextAsset roleasset;
    private List<roledata> rolelist=new List<roledata>();
    private Transform Rolechoose;
    public CanvasGroup _left;
    public CanvasGroup _right;
    public CanvasGroup rolechoosepanel;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Text3;
    public TextMeshProUGUI record;
    public Image desrrole;
    public TextMeshProUGUI _title;
    public HorizontalLayoutGroup _showpanel;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance=this;
        Rolechoose=GameObject.Find("rolechoose").transform;
        roleasset=Resources.Load<TextAsset>("Data/role");
        roleDataWrapper wrapper = JsonUtility.FromJson<roleDataWrapper>(roleasset.text);
        rolelist = wrapper.items;
        roleprefab=Resources.Load<GameObject>("prefab/rolebutton");
        Name=GameObject.Find("Text1").GetComponent<TextMeshProUGUI>();
        Text3=GameObject.Find("Text3").GetComponent<TextMeshProUGUI>();
        record=GameObject.Find("desr").GetComponent<TextMeshProUGUI>();
        desrrole=GameObject.Find("desrrole").GetComponent<Image>();
        _left=GameObject.Find("left").GetComponent<CanvasGroup>();
        _right=GameObject.Find("right").GetComponent<CanvasGroup>();
        rolechoosepanel=GameObject.Find("rolechoose").GetComponent<CanvasGroup>();
        _title=GameObject.Find("title").GetComponent<TextMeshProUGUI>();
        _showpanel=GameObject.Find("showpanel").GetComponent<HorizontalLayoutGroup>();
    }
    void Start()
    {
        foreach(roledata roledata in rolelist)
        {
            roleUIcommod r=Instantiate(roleprefab,Rolechoose).GetComponent<roleUIcommod>();
           r.setData(roledata);
           
        }
        _left.alpha=0;
        _right.alpha=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

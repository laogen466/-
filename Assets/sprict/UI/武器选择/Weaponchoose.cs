
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Weaponchoose : MonoBehaviour
{
    // Start is called before the first frame update
    private static  Weaponchoose instance;
    public static Weaponchoose _instance
    {
        get {return  instance;}
    }
    
    public List<weapondata> weapondatas=new List<weapondata>();
    public TextAsset weaponasset;
    public GameObject weapon;
    public Image _desrweapon;
    
    public TextMeshProUGUI _text4;
    public TextMeshProUGUI _text6;
    public GameObject weaponprefab;
    public Transform _weaponchoose;
    public CanvasGroup weaponpanel;
    public CanvasGroup weaponchoosepanel;
    

    void Awake()
    {
        instance=this;
        weaponasset=Resources.Load<TextAsset>("Data/weapon");
        WeaponDataWrapper wrapper = JsonUtility.FromJson<WeaponDataWrapper>(weaponasset.text);
        weapondatas = wrapper.items;
        _desrweapon=GameObject.Find("desrweapon").GetComponent<Image>();
        _text4=GameObject.Find("Text4").GetComponent<TextMeshProUGUI>();
        _text6=GameObject.Find("Text6").GetComponent<TextMeshProUGUI>();
        weaponprefab=Resources.Load<GameObject>("prefab/weaponbutton");
        _weaponchoose=GameObject.Find("weaponchoose").GetComponent<Transform>();
        weaponpanel=GameObject.Find("weapon").GetComponent<CanvasGroup>();
        weaponchoosepanel=GameObject.Find("weaponchoose").GetComponent<CanvasGroup>();
        weapon=GameObject.Find("weapon");
        
    }
    void Start()
    {
        foreach(weapondata weapondata in weapondatas)
        {
            weaponcommd w= Instantiate(weaponprefab,_weaponchoose).GetComponent<weaponcommd>();
            w.setweapondata(weapondata);
        }
    }
}

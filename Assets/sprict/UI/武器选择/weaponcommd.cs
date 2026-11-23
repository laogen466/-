using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class weaponcommd : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    // Start is called before the first frame update
    public weapondata weapondata;
    public Image weaponimage;
    public Image weaponBG;
    public Button wbutton;
    public AudioClip audioClip;
    public Transform miancamera;
    void Awake()
    {
        weaponimage=GetComponent<Transform>().GetChild(0).GetComponent<Image>();
        weaponBG=GetComponent<Image>();
        wbutton=GetComponent<Button>();
        miancamera=GameObject.Find("Main Camera").transform;
    }
    void Start()
    {
        wbutton.onClick.AddListener(renewpanel);
    }
    public void setweapondata(weapondata w)
    {
        weapondata=w;
        weaponimage.sprite=Resources.Load<Sprite>(w.avatar);
        weaponimage.SetNativeSize();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        weaponBG.color=new (255,255,255);
        UIweaponrenew(weapondata);
        Weaponchoose._instance.weaponpanel.alpha=1;
        AudioSource.PlayClipAtPoint(audioClip,miancamera.position,0.8f);
    }

    
    public void OnPointerExit(PointerEventData eventData)
    {
        weaponBG.color=new (27/255f,27/255f,27/255f);
    }
    public void UIweaponrenew(weapondata w)
    {
        Weaponchoose._instance._text4.text=w.name;
        Weaponchoose._instance._text6.text=w.describe;
        Weaponchoose._instance._desrweapon.sprite=Resources.Load<Sprite>(w.avatar);
        
    }
    public void renewpanel()
    {
        GameManager._instance.currentweapon=weapondata;
        rolechoose.getInstance._title.text="难度选择";
        rolechoose.getInstance._showpanel.padding.left=-77;

        deffUIchoose._instance._deffchoosecanvas.alpha=1;
        deffUIchoose._instance._deffchoosecanvas.interactable=true;
        deffUIchoose._instance._deffchoosecanvas.blocksRaycasts=true;

        Weaponchoose._instance.weaponchoosepanel.alpha=0;
        Weaponchoose._instance.weaponchoosepanel.interactable=false;
        Weaponchoose._instance.weaponchoosepanel.blocksRaycasts=false;

        deffUIchoose._instance._deffcanvas.alpha=1;
        deffUIchoose._instance._deffcanvas.interactable=true;
        deffUIchoose._instance._deffcanvas.blocksRaycasts=true;
        deffUIchoose._instance._deffcanvas.GetComponent<Transform>().SetSiblingIndex(2);
    }
}

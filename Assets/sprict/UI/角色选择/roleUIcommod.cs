using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class roleUIcommod : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    // Start is called before the first frame update
    public Image _image;
    public Image _avatar;
    public Button _button;
    public AudioClip audioClip;
    public Transform miancamera;


    public roledata roledata;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.color=new (255,255,255);
        UIrenew(roledata);
        rolechoose.getInstance._left.alpha=1;
        rolechoose.getInstance._right.alpha=1;
        AudioSource.PlayClipAtPoint(audioClip,miancamera.position,0.8f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color=new (27/255f,27/255f,27/255f);
        
    }

    public void UIrenew(roledata roledata)
    {
        if (roledata.unlock == 0)
        {
            rolechoose.getInstance.desrrole.sprite=Resources.Load<Sprite>("image/UI/锁");
            rolechoose.getInstance.Name.text = "???";
            rolechoose.getInstance.Text3.text=roledata.unlockConditions;
            rolechoose.getInstance.record.text="暂无记录";
        }
        else{
            rolechoose.getInstance.desrrole.sprite=Resources.Load<Sprite>(roledata.avatar);
            
            rolechoose.getInstance.Name.text= roledata.name;
            rolechoose.getInstance.Text3.text=roledata.describe;
            if (roledata.record == -1)
            {
                rolechoose.getInstance.record.text="暂无记录";
            }
            else
                rolechoose.getInstance.record.text ="通关危险"+ roledata.record.ToString();
          

            }
        
    }
    public void setData(roledata r)
    {
        this.roledata=r;
        if (roledata.unlock == 0)
        {
            _avatar.sprite=Resources.Load<Sprite>("image/UI/锁");
            _avatar.SetNativeSize();
        }
        else
        {
            _avatar.sprite=Resources.Load<Sprite>(roledata.avatar);
            _avatar.SetNativeSize();
        }

    }
    void Awake()
    {
        _image=GetComponent<Image>();
        _avatar=GetComponent<Transform>().GetChild(0).GetComponent<Image>();
        _button =GetComponent<Button>();
        miancamera=GameObject.Find("Main Camera").transform;
        
    }
    void Start()
    {
        _button.onClick.AddListener(renewpanel);
    }

    public void renewpanel()
    {
        if (roledata.unlock == 0)
        {
            return;
        }
        rolechoose.getInstance._right.alpha=0;
        rolechoose.getInstance._right.interactable=false;
        rolechoose.getInstance._right.blocksRaycasts=false;

        // Weaponchoose._instance.weaponpanel.alpha=1;
        // Weaponchoose._instance.weaponpanel.interactable=true;
        // Weaponchoose._instance.weaponpanel.blocksRaycasts=true;
        //GameObject go=
        
        Weaponchoose._instance.weaponpanel.GetComponent<Transform>().SetSiblingIndex(0);
        rolechoose.getInstance._left.GetComponent<Transform>().SetSiblingIndex(0);
        
        
        rolechoose.getInstance.rolechoosepanel.alpha=0;
        rolechoose.getInstance.rolechoosepanel.interactable=false;
        rolechoose.getInstance.rolechoosepanel.blocksRaycasts=false;

        Weaponchoose._instance.weaponchoosepanel.alpha=1;
        Weaponchoose._instance.weaponchoosepanel.interactable=true;
        Weaponchoose._instance.weaponchoosepanel.blocksRaycasts=true;

        GameManager._instance.currentrole=roledata;
        rolechoose.getInstance._title.text="武器选择";
    }
}

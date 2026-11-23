using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using System;
using System.Xml.Serialization;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class deffUIcommd : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public deffdata deffdata;
    public Image deffimage;
    public Image deffBG;
    public Button dbutton;
    public AudioClip audioClip;
    public Transform miancamera;

    void Awake()
    {
        deffimage=GetComponent<Transform>().GetChild(0).GetComponent<Image>();
        deffBG=GetComponent<Image>();
        dbutton=GetComponent<Button>();
        miancamera=GameObject.Find("Main Camera").transform;
    }
    void Start()
    {
        dbutton.onClick.AddListener(renewpanel);
    }
    public void setdata(deffdata d)
    {
        deffdata=d;
        deffBG.color=colorchoose(d);
        deffimage.sprite=Resources.Load<SpriteAtlas>("Image/UI/危险等级").GetSprite(d.name);
        
    }

    private void  renewpanel()
    {
        
        GameManager._instance.currentdeff=deffdata;
        SceneManager.LoadScene(2);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        deffBG.color=new Color(1,1,1);
        renewUI();
        AudioSource.PlayClipAtPoint(audioClip,miancamera.position,0.8f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        deffBG.color=colorchoose(deffdata);

    }
    private void renewUI()
    {
        deffUIchoose._instance._paneldiffimage.color=colorchoose(deffdata);
        deffUIchoose._instance._text7.text=deffdata.name;
        deffUIchoose._instance._text9.text=describelevel();
        deffUIchoose._instance._desrdeff.sprite=Resources.Load<SpriteAtlas>("Image/UI/危险等级").GetSprite(deffdata.name);
    }
    public string describelevel()
    {
        
        string describe="";
        for (int id = 0; id < deffdata.id; id++)
        {
            if (deffdata.id == 1)
            {
                return "无修改";
            }

            describe+=deffUIchoose._instance.ddata[id].describe;
            describe+="\n";
        }
        describe=describe.TrimStart('\n');
        return describe;
    }
    public Color colorchoose(deffdata d)
    {
        switch (d.id)
        {
            case 1:
            return new Color(27/255f,27/255f,27/255f);
            
            
            case 2:
            return new Color(66/255f,86/255f,108/255f);
            
           
            case 3:
            return new Color(83/255f,65/255f,104/255f);
            
            
            case 4:
            return new Color(103/255f,58/255f,57/255f);
            
            
            case 5:
           return new Color(104/255f,71/255f,57/255f);
            
            
            case 6:
            return new Color(94/255f,90/255f,60/255f);
             
            default: return new Color(27/255f,27/255f,27/255f);
            
            
        }
    }
    
}

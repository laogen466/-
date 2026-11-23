using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class UIcommon : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private TextMeshProUGUI test;
    private Image image;
    public AudioClip audioClip;
    public Transform miancamera;
    void Awake()
    {
        image=this.gameObject.GetComponent<Image>();
        test=transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color=new (255,255,255);
        test.color=new (0,0,0);
        AudioSource.PlayClipAtPoint(audioClip,miancamera.position,0.8f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       image.color=new (0,0,0);
       test.color=new (255,255,255);
    }

    
}

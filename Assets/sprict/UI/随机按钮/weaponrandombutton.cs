
using UnityEngine.EventSystems;

public class weaponrandombutton : randombutton,IPointerEnterHandler
{
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
         _BG.color=new (255,255,255);
         Weaponchoose._instance.weaponpanel.alpha=0;
    }
    
    void Start()
    {
        _randombutton.onClick.AddListener(renewUI);
    }

    private void renewUI()
    {
        
        weaponcommd w= _weaponchoose.GetChild(randomweapon()).GetComponent<weaponcommd>();
        Weaponchoose._instance.weaponpanel.alpha=1;
        w.renewpanel();
        w.UIweaponrenew(w.weapondata);
    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rolerandombutton : randombutton,IPointerEnterHandler,IPointerExitHandler
{
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
         _BG.color=new (255,255,255);
         rolechoose.getInstance._left.alpha=0;
         rolechoose.getInstance._right.alpha=0;
    }
   
    // Update is called once per frame
    void Start()
    {
        _randombutton.onClick.AddListener(renewUI);
    }

    private void renewUI()
    {
        int index;
        for (index=randomweapon();_rolechoose.GetChild(index).GetComponent<roleUIcommod>().roledata.unlock==0;index=randomweapon());
        roleUIcommod r= _rolechoose.GetChild(index).GetComponent<roleUIcommod>();
        rolechoose.getInstance._left.alpha=1;
        r.renewpanel();
        r.UIrenew(r.roledata);
    }
}

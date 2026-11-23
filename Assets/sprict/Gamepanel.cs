using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamepanel : MonoBehaviour
{
    // Start is called before the first frame update
    private static Gamepanel instance;
    public static Gamepanel _instance
    {
        get
        {
            return instance;
        }
    }
    public TextMeshProUGUI _hptext;
    public TextMeshProUGUI _experiencetext;
    public TextMeshProUGUI _goldtext;
    public TextMeshProUGUI _wavetext;
    public Slider _hpslider;
    public Slider _experienceslider;
    public TextMeshProUGUI _wavetime;
    public CanvasGroup _successpanel;
    public CanvasGroup _failpanel;

    void Awake()
    {
        instance=this;
        _hptext=GameObject.Find("Texthp").GetComponent<TextMeshProUGUI>();
        _experiencetext=GameObject.Find("Textexperience").GetComponent<TextMeshProUGUI>();
        _goldtext=GameObject.Find("Textgold").GetComponent<TextMeshProUGUI>();
        _wavetext=GameObject.Find("wave").GetComponent<TextMeshProUGUI>();
        _hpslider=GameObject.Find("hpslider").GetComponent<Slider>();
        _experienceslider=GameObject.Find("experience").GetComponent<Slider>();
        _wavetime=GameObject.Find("timer").GetComponent<TextMeshProUGUI>();
        _successpanel=GameObject.Find("success").GetComponent<CanvasGroup>();
        _failpanel=GameObject.Find("failure").GetComponent<CanvasGroup>();
    }
    void Start()
    {
        renewExperience();
        renewHp();
        renewgold();
        renewwave();
    }

    //更新经验条
    public void renewExperience()
    {
        _experienceslider.value=player._instanc.experience%12/12;
        _experiencetext.text="LV."+(int)player._instanc.experience/12;
    }
    //更新生命值
    public void renewHp()
    {
        _hpslider.value=player._instanc.currhp/player._instanc.maxhp;
        _hptext.text=player._instanc.currhp+"/"+player._instanc.maxhp;
    }
    //更新金币
    public void renewgold()
    {
        
        _goldtext.text=player._instanc.Gold.ToString();
    }

    public void renewcountdown(float time)
    {
        _wavetime.text=time.ToString("F0");
    }
    //更新波次
    void renewwave()
    {
        _wavetext.text="第"+GameManager._instance.currentwave.ToString()+"波";
    }
    public void success()
    {
        for(int i = 0; wavecolltrol._instance.enemies.Count > i; i++)
        {
            Destroy(wavecolltrol._instance.enemies[i]);
        }
        _successpanel.alpha=1;
        StartCoroutine(returnmain());
    }
    public void fail()
    {
        _failpanel.alpha=1;
        StartCoroutine(returnmain());
    }
    IEnumerator returnmain()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f; 
        SceneManager.LoadScene(0);
    }
}

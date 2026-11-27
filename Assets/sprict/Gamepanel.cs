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
       
        
        // 🌟 订阅金币变化事件
        EventManager.Instance.Subscribe(GameEventType.GoldChanged, renewgold);
        // 🌟 订阅血量变化事件
        EventManager.Instance.Subscribe(GameEventType.PlayerHealthChanged, UpdateHpUI);
        // 🌟 订阅经验条变化事件
        EventManager.Instance.Subscribe(GameEventType.ExperienceChanged,renewExperience);
        // 🌟 订阅波次变化事件
        EventManager.Instance.Subscribe(GameEventType.WaveTimeChanged,renewwave);

        renewgold(player._instanc.Gold);
        UpdateHpUI(new Vector2(player._instanc.currhp, player._instanc.maxhp));
        renewExperience(player._instanc.experience);
        renewwave(GameManager._instance.currentwave);
    }

    //更新经验条
    public void renewExperience(object data)
    {
        float experience=(float)data;
        _experienceslider.value=experience%12/12;
        _experiencetext.text="LV."+(int)experience/12;
    }
    //更新生命值
    private void UpdateHpUI(object data)
    {
        Vector2 health = (Vector2)data;
        float currHp = health.x;
        float maxHp = health.y;
        
        _hpslider.value = currHp / maxHp;
        _hptext.text = currHp + "/" + maxHp;
    }
    //更新金币
    public void renewgold(object data)
    {
        
        int gold = (int)data; // 因为传过来的是 object，需要强转回 int
        _goldtext.text = gold.ToString();
    }

    public void renewcountdown(float time)
    {
        _wavetime.text=time.ToString("F0");
    }
    void OnDestroy()
    {
        EventManager.Instance.Unsubscribe(GameEventType.GoldChanged, renewgold);
        EventManager.Instance.Unsubscribe(GameEventType.PlayerHealthChanged, UpdateHpUI);
    }
    //更新波次
    void renewwave(object data)
    {
        int curr=(int)data;
        _wavetext.text="第"+curr.ToString()+"波";
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

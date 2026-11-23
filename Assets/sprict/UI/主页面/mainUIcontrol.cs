
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainUIcontrol : MonoBehaviour
{
    // Start is called before the first frame update

    private Button startbutton;
    private Button setbutton;
    private Button jindubutton;
    private Button exitbutton;
    void Awake()
    {
        startbutton=GameObject.Find("startbutton").GetComponent<Button>();
        setbutton=GameObject.Find("setbutton").GetComponent<Button>();
        jindubutton=GameObject.Find("jindubutton").GetComponent<Button>();
        exitbutton=GameObject.Find("exitbutton").GetComponent<Button>();
    }

    void Start()
    {
        startbutton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
        exitbutton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

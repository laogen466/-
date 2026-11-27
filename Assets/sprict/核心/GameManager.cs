using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager instance;
    public static GameManager _instance
    {
        get {return instance;}
    }
    public roledata currentrole;
    public weapondata currentweapon;
    public deffdata currentdeff;
    public int currentwave=1;
    void Awake()
    {
         instance=this;
         DontDestroyOnLoad(gameObject);
    }
}

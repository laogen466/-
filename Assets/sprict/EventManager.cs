using System;
using System.Collections.Generic;
using UnityEngine;

// 1. 定义《土豆兄弟》里需要用到的事件类型
public enum GameEventType
{
    PlayerHealthChanged,   // 玩家血量变化（参数：当前血量，最大血量）
    GoldChanged,           // 金币变化（参数：当前金币数）
    ExperienceChanged,     // 经验变化（参数：当前经验，当前等级）
    EnemyDied,             // 敌人死亡（参数：死亡位置，掉落的经验值）
    WaveTimeChanged,       // 波次时间变化（参数：剩余时间）
}

public class EventManager
{
    // 单例模式（纯C#单例）
    private static EventManager _instance;
    public static EventManager Instance
    {
        get
        {
            if (_instance == null) _instance = new EventManager();
            return _instance;
        }
    }

    // 核心字典：按事件类型存储委托
    private Dictionary<GameEventType, Action<object>> eventDict = new Dictionary<GameEventType, Action<object>>();

    // 订阅事件
    public void Subscribe(GameEventType eventType, Action<object> listener)
    {
        if (eventDict.ContainsKey(eventType))
        {
            eventDict[eventType] += listener;
        }
        else
        {
            eventDict[eventType] = listener;
        }
    }

    // 取消订阅
    public void Unsubscribe(GameEventType eventType, Action<object> listener)
    {
        if (eventDict.ContainsKey(eventType))
        {
            eventDict[eventType] -= listener;
            if (eventDict[eventType] == null) eventDict.Remove(eventType);
        }
    }

    // 触发事件
    public void Trigger(GameEventType eventType, object data = null)
    {
        if (eventDict.ContainsKey(eventType))
        {
            try
            {
                eventDict[eventType]?.Invoke(data);
            }
            catch (Exception e)
            {
                Debug.LogError($"事件 {eventType} 处理时出错: {e.Message}");
            }
        }
    }
}

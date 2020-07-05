using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public enum eVitalType
{
    HEALTH,
}

[Serializable]
public class Vital
{
    public eVitalType Type;
    public float Max;
    public bool IsMaxOnAwake;

    public float Current { get; private set; }
    public delegate void OnUpdateDelegate(float newAmount, float newMax);
    public OnUpdateDelegate OnUpdate;

    public void Set(float newAmount)
    {
        Current = newAmount;
        Current = Mathf.Clamp(Current, 0, Max);
        OnUpdate?.Invoke(Current, Max);
    }

    public void Modify(float modAmount)
    {
        Current += modAmount;
        Current = Mathf.Clamp(Current, 0, Max);
        OnUpdate?.Invoke(Current, Max);
    }

}

public class PlayerVitals : MonoBehaviour
{
    [SerializeField] private Vital[] Vitals;
    private Dictionary<eVitalType, Vital> _vitalsDictionary = new Dictionary<eVitalType, Vital>();

    private void Awake()
    {
        foreach(Vital v in Vitals)
        {
            if(v.IsMaxOnAwake)
            {
                v.Set(v.Max);
            }
            else
            {
                v.Set(0);
            }

            _vitalsDictionary.Add(v.Type, v);
        }
    }

    public Vital GetVital(eVitalType type)
    {
        return _vitalsDictionary[type];
    }
}

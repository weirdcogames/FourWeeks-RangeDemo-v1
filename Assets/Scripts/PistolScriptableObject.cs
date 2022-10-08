using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public float fireRate;
    public float nextTimeToFire;
    public float minRecoil;
    public float maxRecoil;
}
public class PistolScriptableObject : ScriptableObject
{
    public string name;
    public WeaponStats stats;
    public GameObject pistolPrefab;
}

   

    

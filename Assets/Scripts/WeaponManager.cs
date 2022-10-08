using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject testPistol;
    public GameObject testSMG;
    public GameObject testShotgun;
    // Start is called before the first frame update
    void Start()
    {
        testPistol.SetActive(false);
        testSMG.SetActive(false);
        testShotgun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        testPistol.SetActive(false);
        testSMG.SetActive(false);
        testShotgun.SetActive(false);
    }
}

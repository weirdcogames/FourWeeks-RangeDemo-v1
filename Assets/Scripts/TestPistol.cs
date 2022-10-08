using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPistol : MonoBehaviour
{

    [Header("Reference Points")]
    public Transform barrelPoint;
    public GameObject bulletPrefab;
    public bool equipped;

    [Space]
    [Header("Firearm Variables")]

    public float fireRate = 1f;
    public float nextTimeToFire = 0f;
    public float minRecoil;
    public float maxRecoil;

    public float roundsLeft;
    public float magCapacity;

    public float reloadSpeed;
    public float nextTimeToReload;


    // Start is called before the first frame update
    void Start()
    {
        magCapacity = 15;
        roundsLeft = magCapacity;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            if (roundsLeft <= 0)
            {
                roundsLeft = 0;
            }else{
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
        if (Input.GetButtonDown("Reload") && Time.time >= nextTimeToReload)
        {
            if (roundsLeft >= magCapacity)
            {

                roundsLeft = magCapacity;
                return;
            }
            nextTimeToFire = Time.time + 1f / reloadSpeed;
            Reload();
        }
    }


    void Shoot()
    {
        //Lose a round
        roundsLeft--;
        //Play shoot animation
        Animator player = FindObjectOfType<PlayerMovement>().anim;
        player.Play("pistolshoot");
        //Make bullet at barrel
        GameObject bullet = Instantiate(bulletPrefab, barrelPoint.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + Random.Range(minRecoil, maxRecoil)));
        //Play fire sound

        //Let it die
        Destroy(bullet, 2f);
    }

    void Reload()
    {
        roundsLeft = magCapacity;
        Animator player = FindObjectOfType<PlayerMovement>().anim;
        player.Play("pistolreload");

    }
}

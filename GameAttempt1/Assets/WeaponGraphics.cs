using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGraphics : MonoBehaviour
{
    public ParticleSystem muzzleflash;
    public GameObject hitEffect;

    public void shootEffect() {

        muzzleflash.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{
    string MyID;
    const int maxHealth = 100;

    private WeaponGraphics currentGraphics;

    [SyncVar]
    private int currentHealth;


    public void TakeDamage(int damage) {
        currentHealth -= damage;
        Debug.Log(MyID+" took "+ damage+" damage and now has " +currentHealth +" health" );
        if (currentHealth <= 0) {
            Respawn();
        }
    }

    public void Respawn() {
        float x = Random.Range(-80f, 80f);
        transform.position = new Vector3(x,5,0);

    }
    public void ResetPlayer() {
        currentHealth = maxHealth;
    }

    public WeaponGraphics GetWeaponGraphics() {

        return currentGraphics;
    }

    private void Start()
    {
        MyID = transform.name;
        currentHealth = maxHealth;
        currentGraphics= GetComponent<WeaponGraphics>();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            Respawn();
        
        }
    }

}

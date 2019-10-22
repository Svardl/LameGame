using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{
    string MyID;
    const int maxHealth = 100;

    [SyncVar]
    private int currentHealth;


    public void TakeDamage(int damage) {
        currentHealth -= damage;
        Debug.Log(MyID+" took "+ damage+" damage and now has " +currentHealth +" health" );
    }
    public void ResetPlayer() {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        MyID = transform.name;
        currentHealth = maxHealth;
    }

}

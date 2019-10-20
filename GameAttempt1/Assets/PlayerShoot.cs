using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    [SerializeField]
    private LayerMask mask;

    public Camera cam;
    public PlayerWeapon weapon;

 

    void Start(){

        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    [Client]
    void Shoot() {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask )) {
            if (hit.collider.tag == "Player") {
                CmdPlayerShot(hit.collider.name, weapon.damage);
            
            }
        }
    }
    [Command]
    void CmdPlayerShot(string id, int damage) {
        Debug.Log(id + " has been shot");

        PlayerManager player = GameManager.GetPlayer(id);



    }
}

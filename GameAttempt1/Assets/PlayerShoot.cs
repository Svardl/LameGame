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
    public PlayerController controller;

    void Start(){
        controller = GetComponent<PlayerController>();
        weapon.damage = 10;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }

        if (Input.GetButton("Fire2"))
        {
            controller.Speed = 15;
        }
        else {
            controller.Speed = 5;
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
        player.TakeDamage(damage);



    }
}

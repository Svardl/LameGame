using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerManager))]
public class PlayerSetup : NetworkBehaviour
{

    public Behaviour[] componentsToKill;
    Camera sceneCam;
    public string remoteLayerName = "RemotePlayer";
    void Start(){

        if (!isLocalPlayer) {

            gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
            foreach (Behaviour comp in componentsToKill) {
                comp.enabled = false;
            }
        }
        else {
            sceneCam = Camera.main;
            if(sceneCam!=null)
                sceneCam.gameObject.SetActive(false);
        }

    }
    private void OnDisable() {
        if (sceneCam != null) {
            sceneCam.gameObject.SetActive(true);
        }

        GameManager.Deregister(transform.name); 
;        
    }

    public override void OnStartClient() {
        base.OnStartClient();

        string netId = GetComponent<NetworkIdentity>().netId.ToString();
        PlayerManager player = GetComponent<PlayerManager>();
        GameManager.RegisterPlayer(netId, player);
    }
    void Update()
    {
        
    }
}

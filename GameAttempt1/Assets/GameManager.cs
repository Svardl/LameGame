using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static Dictionary<string, PlayerManager> players = new Dictionary<string, PlayerManager>();

    public static void RegisterPlayer(string netId, PlayerManager player) {
        string playerString = "Player " + netId;
        players.Add(playerString, player);
        player.transform.name = playerString;

    }
    public static PlayerManager GetPlayer(string playerID) {

        return players[playerID];
    }

    public static void Deregister(string playerID) {
        players.Remove(playerID);
    
    }

}

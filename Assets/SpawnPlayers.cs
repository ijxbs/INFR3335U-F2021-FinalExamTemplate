using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public float minX, maxX;
    public float minZ, maxZ;
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0f, Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
    }

}

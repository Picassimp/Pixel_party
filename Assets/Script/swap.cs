using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swap : MonoBehaviour
{
    public void chuyenvitri()
    {
        GameObject[] player1 = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] player2 = GameObject.FindGameObjectsWithTag("Player2");

        Vector3 tempPosition = player1[0].transform.position;
        player1[0].transform.position = player2[0].transform.position;
        player2[0].transform.position = tempPosition;
    }
}

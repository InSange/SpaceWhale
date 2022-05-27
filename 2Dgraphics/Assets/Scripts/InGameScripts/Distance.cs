using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    GameObject Player;
    GameObject Tresure;
    GameObject TreasureFlag;
    float distance;
    float IconDistance;
    Vector3 pos = new Vector3(0, 48, 0);
    float startPos;

    private void Start()
    {
        TreasureFlag = GameObject.FindWithTag("TreasureFlag");
        Player = GameObject.FindWithTag("Player");
        Tresure = GameObject.FindWithTag("Treasure_pile");
        startPos = this.gameObject.transform.position.x;
        distance = Tresure.transform.position.x - Player.transform.position.x;
        IconDistance = TreasureFlag.transform.position.x - this.transform.position.x;
    }

    public void DistanceCALL()
    {
        pos.x = (startPos + 458.0121f) - ((Tresure.transform.position.x - Player.transform.position.x) * (IconDistance / distance));
        this.gameObject.transform.position = pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemps : MonoBehaviour
{
    public GameObject[] botRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;
    public List<GameObject> rooms;

    public float waitTime;
    public GameObject boss;
    public int maxRooms;

    void Start()
    {
        StartCoroutine(SpawnBoss());
    }

    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(waitTime);

        Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
    }
}

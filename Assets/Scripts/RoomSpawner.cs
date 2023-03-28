using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDir;
    // 1 --> need bottom door (has top door)
    // 2 --> need top door    (has bottom door)
    // 3 --> need left door   (has right door)
    // 4 --> need right door  (has left door)
    RoomTemps templates;
    int room;
    public bool spawned = false;
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemps>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (spawned == false)
        {
            if (openingDir == 1)
            {
                room = Random.Range(0, templates.botRooms.Length);
                Instantiate(templates.botRooms[room], transform.position, templates.botRooms[room].transform.rotation);
            }
            else if (openingDir == 2)
            {
                room = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[room], transform.position, templates.topRooms[room].transform.rotation);
            }
            else if (openingDir == 3)
            {
                room = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[room], transform.position, templates.leftRooms[room].transform.rotation);
            }
            else if (openingDir == 4)
            {
                room = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[room], transform.position, templates.rightRooms[room].transform.rotation);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true)
        {
            Destroy(gameObject);
        }
    }
}

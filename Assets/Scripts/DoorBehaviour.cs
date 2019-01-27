using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour
{
    public string destination;
    public Vector2 destinationSpawn;
    public PlayerSpawnPosition playerSpawnPosition;

    public void ChangeRoom()
    {
        playerSpawnPosition.position = new Vector3(destinationSpawn.x, destinationSpawn.y);
        if (destination != "")
        {
            SceneManager.LoadScene(destination);
        }
    }
}

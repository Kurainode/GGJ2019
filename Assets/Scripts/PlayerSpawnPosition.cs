using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerSpawnPosition", order = 1)]
public class PlayerSpawnPosition : ScriptableObject
{
    public Vector3 position;
}

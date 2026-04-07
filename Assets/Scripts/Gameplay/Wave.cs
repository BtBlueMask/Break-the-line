using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Wave", menuName = "Break the Line/Wave", order = 1)]
public class Wave : ScriptableObject
{
    [SerializeField] public List<GameObject> enemies;
    [SerializeField] public List<Vector3> enemyLocations;
}

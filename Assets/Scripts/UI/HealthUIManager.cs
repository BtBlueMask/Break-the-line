using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{

    [SerializeField] private List<GameObject> _HealthList = new List<GameObject>();

    public void onHealthChanged(int Health)
    {
        for (int i = 0; i< _HealthList.Count; i++)
        {
            _HealthList[i].SetActive(Health > i);
        }
    }
    
}

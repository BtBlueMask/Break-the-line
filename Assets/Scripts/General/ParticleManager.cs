using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    [SerializeField] private GameObject Spark;
    [SerializeField] private GameObject Fire;
    [SerializeField] private GameObject Flash;
    [SerializeField] private GameObject Smoke;


    public void StartSpark(Vector3 StartPos)
    {
        Instantiate(Spark, StartPos, Quaternion.Euler(0,0,0));
    }

    public void StartFire(Vector3 StartPos)
    {
        Instantiate(Fire, StartPos, Quaternion.Euler(0, 0, 0));
    }

    public void StartFlash(Vector3 StartPos)
    {
        Instantiate(Flash, StartPos, Quaternion.Euler(0, 0, 0));
    }

    public void StartSmoke(Vector3 StartPos)
    {
        Instantiate(Smoke, StartPos, Quaternion.Euler(0, 0, 0));
    }

}

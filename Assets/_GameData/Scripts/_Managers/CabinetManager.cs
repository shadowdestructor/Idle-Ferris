using UnityEngine;
public class CabinetManager : MonoBehaviour
{
    public static CabinetManager Instance {get; private set;}
    //[HideInInspector] public float speed;
    private void Awake()=>Instance = this;
    
    public void Look() => transform.rotation = Quaternion.Euler(0,0,-transform.parent.rotation.z);
}
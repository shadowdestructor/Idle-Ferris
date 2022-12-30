using UnityEngine;
public class CabinetManager : MonoBehaviour
{
    public static CabinetManager Instance {get; private set;}
    //[HideInInspector] public float speed;
    private void Awake()=>Instance = this;
}
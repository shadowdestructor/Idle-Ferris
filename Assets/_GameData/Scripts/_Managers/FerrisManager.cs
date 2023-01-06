using UnityEngine;

public class FerrisManager : MonoBehaviour
{
    public static FerrisManager Instance {get; private set;}
    private MeshFilter meshFilter;
    public int identity,income;
    private void Awake() 
    {
        Instance = this;
        meshFilter = GetComponent<MeshFilter>();
    }
    
}

using UnityEngine;

public class PumperManager : MonoBehaviour
{
    public static PumperManager Instance {get; private set;}
    private void Awake() => Instance = this;
    public void Enabling(int i)
    {
        Debug.Log(i);
        transform.GetChild(i).gameObject.SetActive(true);
        i++;
    }
    private void OnEnable() 
    {
        //particles
    }
}
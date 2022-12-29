using UnityEngine;

public class WheelManager : MonoBehaviour
{
    public static WheelManager Instance {get; private set;}
    [HideInInspector] public Animator _anim;
    [SerializeField] private UpgradeAble pump;
    private void Awake() 
    {
        Instance = this;
        _anim = GetComponent<Animator>();
        for (int i = 0; i < pump.value; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void Enabling(int i)
    {
        transform.GetChild(i).gameObject.SetActive(true);
        i++;
    }
    private void OnEnable() 
    {
        //particles
    }
}
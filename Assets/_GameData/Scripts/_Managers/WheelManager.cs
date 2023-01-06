using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WheelManager : MonoBehaviour
{
    public static WheelManager Instance {get; private set;}
    [HideInInspector] public Animator _anim;
    [SerializeField] private UpgradeAble pump;
    private List<int> list;
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
    public void Look()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).rotation = Quaternion.Euler(0,0,-transform.parent.rotation.z);
        }
    }
    public void Merge()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            list.Add(transform.GetChild(i).GetComponent<FerrisManager>().identity);
        }
    }
}
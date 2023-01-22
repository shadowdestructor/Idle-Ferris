using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
public class WheelManager : MonoBehaviour
{
    public static WheelManager Instance {get; private set;}
    [HideInInspector] public Animator _anim;
    [SerializeField] private UpgradeAble pump;
    private List<int> list,list2;
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
            var tr = transform.GetChild(i);
            list.Add(tr.GetComponent<FerrisManager>().identity);
            list2.Add(tr.GetSiblingIndex());
            transform.GetChild(i).transform.DOMove(Vector3.zero,1.5f);
        }
        var arbs = list.GroupBy(v => v);
        foreach (var a in arbs)
        {
            if (a.Count() % 4 == 0)
            {
                //mergeyi yap
                Merging();
            }
            //a.Key()
        }

    }
    private void Merging()
    {
        var arbs = list.GroupBy(v => v);
        foreach(var i in arbs)
        {
            
        }
        list.Clear();
    }
}
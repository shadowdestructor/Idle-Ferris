using UnityEngine;
using Dreamteck.Splines;
public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance {get; private set;}
    private Animator anim;
    private SplineFollower splineFollower;
    public SkinnedMeshRenderer meshRenderer;
    private void Awake() 
    {
        Instance = this;
        anim = GetComponent<Animator>();
        splineFollower = GetComponent<SplineFollower>();
    }
    public void Trigger(int speed,bool istriger)
    {
        splineFollower.followSpeed = speed;
        anim.SetBool("Wait",istriger);
    }
    private void OnTriggerEnter(Collider other) 
    {
        Trigger(0,true);
        if (other.gameObject.TryGetComponent(out MeshCollider meshCollider))
        {
            meshRenderer.gameObject.SetActive(false);
            Trigger(1,false);
        }
    }
}
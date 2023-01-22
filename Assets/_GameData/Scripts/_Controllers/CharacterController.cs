using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator _anim;
    private void Awake() 
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collision other) 
    {
        if (other.gameObject.TryGetComponent(out TriggerManager triggerManager))
        {
            _anim.SetBool("isStop",true);
        }
    }
}
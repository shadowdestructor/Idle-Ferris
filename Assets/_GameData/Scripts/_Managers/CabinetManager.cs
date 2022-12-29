using UnityEngine;
public class CabinetManager : MonoBehaviour
{
    public static CabinetManager Instance {get; private set;}
    //[HideInInspector] public float speed;
    private void Awake() => Instance = this;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.TryGetComponent(out BoxCollider boxCollider))
        {
            WheelManager.Instance._anim.speed = 0;
            Invoke(nameof(Goto),2);//speed);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BoxCollider boxCollider))
        {
            CoinManager.Instance.Click();
        }
    }
    private void Goto() => WheelManager.Instance._anim.speed = 1;
}
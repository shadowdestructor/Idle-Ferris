using UnityEngine;
using DG.Tweening;
public class TriggerManager : MonoBehaviour
{
    [SerializeField] private TextMesh text;
    [SerializeField] private UpgradeAble income;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.TryGetComponent(out MeshCollider meshCollider))
        {
            TextAnim();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out MeshCollider meshCollider))
        {  
            CoinManager.Instance.Click();
            CharacterController.Instance.meshRenderer.gameObject.SetActive  (true);
            CharacterController.Instance.Trigger(5,false);
        }
    }
    private void TextAnim()
    {
        text.gameObject.SetActive(true);
        text.gameObject.transform.DOMoveY(6.5f,.75f).OnComplete(()=>
        {
            text.text = "+$"+((int)income.value).ToString();
            text.gameObject.SetActive(false);
            text.gameObject.transform.position = new Vector3(-1,.5f,3);
        });
    }
}

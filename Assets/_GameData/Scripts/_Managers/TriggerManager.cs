using UnityEngine;
using DG.Tweening;
public class TriggerManager : MonoBehaviour
{
    [SerializeField] private TextMesh text;
    [SerializeField] private UpgradeAble income;
    private void OnTriggerEnter(Collider other) 
    {
        WheelManager.Instance._anim.speed = 0;
        TextAnim();
        Invoke(nameof(Goto),2);
    }
    private void OnTriggerExit(Collider other)
    {
        CoinManager.Instance.Click();
    }
    private void Goto()=>WheelManager.Instance._anim.speed = 1;
    private void TextAnim()
    {
        text.gameObject.SetActive(true);
        text.gameObject.transform.DOMoveY(6.5f,.5f).OnComplete(()=>
        {
            text.text = "+$"+((int)income.value).ToString();
            text.gameObject.SetActive(false);
            text.gameObject.transform.position = new Vector3(-1,.5f,3);
        });
    }
}

using UnityEngine;
using DG.Tweening;
using TMPro;

public class TriggerManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out FerrisManager ferrisManager))
        {  
            CoinManager.Instance.Income(ferrisManager.income);
            TextAnim(ferrisManager.income);
        }
    }
    private void TextAnim(int inc)
    {
        text.gameObject.SetActive(true);
        text.gameObject.transform.DOMoveY(6.5f,.6f).OnComplete(()=>
        {
            text.text = "$"+inc.ToString();
            text.gameObject.SetActive(false);
            text.gameObject.transform.position = new Vector3(0,5f,-3);
        });
    }
}

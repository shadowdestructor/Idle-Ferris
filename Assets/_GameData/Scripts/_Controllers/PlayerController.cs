using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {get; private set;}
    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
    }
    private void LateUpdate()
    {
        var mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition).y;
        if (Input.GetKeyDown(KeyCode.Mouse0) && 
        (mousePos < .85f && mousePos > .35f))
        {
            Time.timeScale = 5f;
            Invoke(nameof(NormalTime),1.5f);   
        }
        WheelManager.Instance.Look();
    }
    private void NormalTime()=> Time.timeScale = 1f;
}
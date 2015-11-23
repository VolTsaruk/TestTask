using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class ClickController : MonoBehaviour
{

    public void OnClick()
    {
        LevelController.Instance.OnBackgroundClick(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}

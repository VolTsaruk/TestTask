using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeController : MonoBehaviour
{
    void Awake()
    {
        if (InterfaceController.TimeController != null)
        {
            Destroy(this);
        }
        else
        {
            InterfaceController.TimeController = this;
        }
    }
    public Text LevelTime;
    public void SetLevelTime(int seconds)
    {
        LevelTime.text = (seconds / 60).ToString() + ":" + (seconds % 60).ToString();
        if(seconds<5)
        {
            LevelTime.color = Color.red;
        }
        else
        {
            LevelTime.color = Color.yellow;
        }
    }
}

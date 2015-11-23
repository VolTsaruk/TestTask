using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameoverPanel : MonoBehaviour
{
    public Text FinishText;
    void Awake()
    {
        if (InterfaceController.GameoverPanel != null)
        {
            Destroy(this);
        }
        else
        {
            InterfaceController.GameoverPanel = this;
        }
        gameObject.SetActive(false);
    }
    public void Init(bool nextLevel)
    {
        gameObject.SetActive(true);
        if (nextLevel)
        {
            FinishText.text = "You win! Start next level?";
        }
        else
        {
            FinishText.text = "Time's up! Retry?";
        }
    }
    public void Restart()
    {
        gameObject.SetActive(false);
        LevelController.Instance.Restart();
    }
}

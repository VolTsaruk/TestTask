using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour
{
    static readonly float c_AddTime=5;
    float m_lifeTime = 10;
    public BonusController ParentController { get; set; }
    public void AddBonus()
    {
        LevelController.Instance.AddTime(c_AddTime);
        DestroySelf();
    }


    // Update is called once per frame
    public void OnUpdate(float deltaTime)
    {
        m_lifeTime -= deltaTime;
        if (m_lifeTime < 0)
        {
            DestroySelf();
        }
    }
    public void Reset()
    {
        m_lifeTime = 10;
    }
    void DestroySelf()
    {
        ParentController.RemoveBonus(this);
        ObjectCreator.Destroy(gameObject, "Bonus");
    }
}

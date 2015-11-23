using UnityEngine;
using System.Collections.Generic;

public class BonusController : MonoBehaviour {

    static readonly float c_timeAtOnce = 1f;
    static readonly int c_requiredPonyAtOnce=5;
    float m_timeLeft;
    int m_ponyAtOnce;
    List<Bonus> m_bonuses=new List<Bonus>();
    public GameObject BonusPrefab;
	// Update is called once per frame
	public void OnUpdate (float deltaTime) {
        m_timeLeft -= deltaTime;
	    if(m_timeLeft<0)
        {
            m_ponyAtOnce = 0;
        }
        foreach(Bonus bonus in m_bonuses)
        {
            bonus.OnUpdate(deltaTime);
        }
	}
    public void AddPonyAtOnce()
    {
        if (m_ponyAtOnce==0)
        {
            m_timeLeft = c_timeAtOnce;
        }
        m_ponyAtOnce += 1;
        if(m_ponyAtOnce==c_requiredPonyAtOnce)
        {
            Bonus bonus = ObjectCreator.Instantiate(BonusPrefab, "Bonus").GetComponent<Bonus>();
            bonus.ParentController = this;
            bonus.Reset();
            m_bonuses.Add(bonus);

            
        }
    }
    public void RemoveBonus(Bonus bonus)
    {
        m_bonuses.Remove(bonus);
    }
    public void Reset()
    {
        foreach(Bonus bonus in m_bonuses)
        {
            ObjectCreator.Destroy(bonus.gameObject, "Bonus");
        }
    }
}

using UnityEngine;
using System.Collections;

public class Pony : MonoBehaviour {

    bool m_finished = false;
    public void AttachToGroup(ControlGroup group)
    {
        if (!m_finished)
        {
            GetComponent<GroupableObject>().SetParent(group);
            group.AddObject(GetComponent<GroupableObject>());
            GetComponent<ObjectAnimationController>().Move();
        }
    }
    public void Finish()
    {
        GetComponent<GroupableObject>().Free();

        GetComponent<PonyAnimation>().Win();
        m_finished = true;
    }
    public void Reset()
    {
        m_finished = false;
        GetComponent<PonyAnimation>().ResetAnimations();
        
    }

}

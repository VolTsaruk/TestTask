using UnityEngine;
using System.Collections;

public class Pony : MonoBehaviour {

    bool m_finished = false;
    public void AttachToGroup(ControlGroup group)
    {
        if (!m_finished)
        {
            GetComponent<GroupableObject>().SetParent(group);
        }
    }
    public void Finish()
    {
        GetComponent<GroupableObject>().Free();
        m_finished = true;
    }
    public void Reset()
    {
        m_finished = false;
    }

}

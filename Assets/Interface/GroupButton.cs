using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GroupButton : MonoBehaviour
{
    ControlGroup m_controlledGroup;
    public void SetControlGroup(ControlGroup group)
    {
        m_controlledGroup = group;
    }
    public void Click(bool value)
    {
        if (value && m_controlledGroup != null)
        {
            m_controlledGroup.Activate();
        }
    }
    public void SetActive()
    {
        GetComponent<Toggle>().isOn = true;
    }

}

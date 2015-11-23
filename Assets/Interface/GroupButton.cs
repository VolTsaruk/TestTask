using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GroupButton : MonoBehaviour
{
    ControlGroup m_controlledGroup;
    public Image GroupColorDisplay;
    Toggle m_toggle;
    bool m_activating;
    void Awake()
    {
        m_toggle = GetComponent<Toggle>();
    }
    public void SetControlGroup(ControlGroup group)
    {
        m_controlledGroup = group;
    }
    public void Click(bool value)
    {
        if (value&&m_controlledGroup != null)
        {
            SetActive();
        }
    }
    public void SetActive()
    {
        
        if (!m_activating)
        {
            m_activating = true;
            GetComponent<Toggle>().isOn = true;
            LevelController.Instance.SelectGroup(m_controlledGroup);
        }
        m_activating = false;
    }
    
    public void SetGroupColor(Color color)
    {
        GroupColorDisplay.color = color;
    }
}

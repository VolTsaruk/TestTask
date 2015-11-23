using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GroupButton : MonoBehaviour
{
    ControlGroup m_controlledGroup;
    public Image GroupColorDisplay;

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
       
            GetComponent<Toggle>().isOn = true;
            LevelController.Instance.SelectGroup(m_controlledGroup);
       
    }
    
    public void SetGroupColor(Color color)
    {
        GroupColorDisplay.color = color;
    }
}

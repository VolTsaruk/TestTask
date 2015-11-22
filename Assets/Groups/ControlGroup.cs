using UnityEngine;
using System.Collections.Generic;

/// <summary>
///Provides controlls for the group of objects
/// </summary>
public class ControlGroup : MonoBehaviour
{
    List<GroupableObject> m_ChildObjects = new List<GroupableObject>();
    GroupButton m_button;
	public void Activate()
    {
        m_button.SetActive();
    }
    public void SetGroupButton(GroupButton button)
    {
        m_button = button;
    }
}

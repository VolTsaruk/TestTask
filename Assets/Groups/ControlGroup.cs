using UnityEngine;
using System.Collections.Generic;

/// <summary>
///Provides controlls for the group of objects
/// </summary>
public class ControlGroup : MonoBehaviour
{
    public Dog GroupLeader;
    List<GroupableObject> m_ChildObjects = new List<GroupableObject>();
    GroupButton m_button;
    Color m_groupColor;

    Vector2 m_destination;
    bool m_hasDestination = false;
    public float MaxSpeed=1;
    public bool IsMoving { get { return m_hasDestination; } }

    public Color GroupColor
    {
        get
        {
            return m_groupColor;
        }
        set
        {
            SetGroupColor(value);
        }
    }
	
    public void SetGroupButton(GroupButton button)
    {
        m_button = button;
    }
    public void SetGroupColor(Color color)
    {
        m_groupColor = color;
        GroupLeader.SetCollarColor(color);
    }

    public void Activate()
    {
        m_button.SetActive();

    }
    public void SetDestination(Vector2 dest)
    {
        m_destination = dest;
        m_hasDestination = true;
        foreach(GroupableObject x in m_ChildObjects)
        {
            x.GetComponent<ObjectAnimationController>().Move();
        }
    }
    public void OnUpdate(float deltaTime)
    {
        if (!m_hasDestination) return;
        Vector2 direction = m_destination - (Vector2)transform.position;
        Vector2 speedDirection = direction.normalized*MaxSpeed*deltaTime;
        if(speedDirection.sqrMagnitude>direction.sqrMagnitude)
        {
            speedDirection = direction;
            m_hasDestination=false;
            foreach (GroupableObject x in m_ChildObjects)
            {
                x.GetComponent<ObjectAnimationController>().Stop();
            }
        }
        transform.Translate(speedDirection);
    }
    public void Reset()
    {
        m_hasDestination = false;
        m_ChildObjects.Clear();
        m_ChildObjects.Add(GroupLeader.GetComponent<GroupableObject>());
    }
    public void AddObject(GroupableObject obj)
    {
        m_ChildObjects.Add(obj);
    }
    public void FreeObject(GroupableObject obj)
    {
        m_ChildObjects.Remove(obj);
    }
}

using UnityEngine;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get { return m_instance; } }
    static LevelController m_instance;
    List<ControlGroup> m_objectGroup = new List<ControlGroup>();
    public LevelInitializer Initializer;

    ControlGroup SelectedGroup;
    public SpriteRenderer GroupSelector;


    void Awake()
    {
        m_instance = this;
    }
    void Start()
    {
        Initializer.Init();
        m_objectGroup = Initializer.GetInitializedGroups();
        
    }
    void Update()
    {
        foreach(ControlGroup group in m_objectGroup)
        {
            group.OnUpdate(Time.deltaTime);
        }
        SetSelectorPosition();
    }

    public void SelectGroup(ControlGroup group)
    {
        SelectedGroup = group;
        SetSelectorPosition();
    }
    void SetSelectorPosition()
    {
        if (SelectedGroup != null)
        {
            GroupSelector.transform.position = SelectedGroup.GroupLeader.transform.position - transform.forward;
        }

    }
    public void OnBackgroundClick(Vector2 position)
    {
        if(SelectedGroup!=null)
        {
            SelectedGroup.SetDestination(position);
        }
    }

}

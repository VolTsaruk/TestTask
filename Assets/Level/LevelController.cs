using UnityEngine;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get { return m_instance; } }
    static LevelController m_instance;
    List<ControlGroup> m_objectGroup = new List<ControlGroup>();
    public LevelInitializer Initializer;
    public BonusController BonusControllerInstance;
    ControlGroup SelectedGroup;
    public SpriteRenderer GroupSelector;

    int m_levelNumber = 1;
    int m_numPoniesPerLevel=4;
    int m_numPonies;
    
    float m_timeLeft;
    bool m_finished = false;
    void Awake()
    {
        if (m_instance != null)
        {
            Destroy(this);
        }
        else
        {
            m_instance = this;
        }
    }
    void Start()
    {
        m_numPoniesPerLevel ++;
        
        m_finished = false;
        m_timeLeft = 90 - 5*(m_levelNumber/5);
        m_numPonies = m_numPoniesPerLevel;
       
        Initializer.Init(3,m_numPonies);
        m_objectGroup = Initializer.GetInitializedGroups();
        
    }
    public void Restart()
    {
        Initializer.DestroyLevel();
        Start();
    }
    public void RestartFirstLevel()
    {
        m_levelNumber = 1;
        m_numPoniesPerLevel = 4;
    }
    void Update()
    {
        if (m_finished) return;
        m_timeLeft -= Time.deltaTime;

        InterfaceController.TimeController.SetLevelTime((int)m_timeLeft);
        foreach(ControlGroup group in m_objectGroup)
        {
            group.OnUpdate(Time.deltaTime);
        }
        BonusControllerInstance.OnUpdate(Time.deltaTime);
      
        SetSelectorPosition();
        if(m_timeLeft<0)
        {
            m_finished = true;
            InterfaceController.GameoverPanel.Init(true);
        }
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
    public void OnPonyEnterPaddock()
    {
        m_numPonies--;
        BonusControllerInstance.AddPonyAtOnce();
        if(m_numPonies==0)
        {
            m_finished = true;
            InterfaceController.GameoverPanel.Init(true);
        }
    }
    public void AddTime(float deltaTime)
    {
        m_timeLeft += deltaTime;
    }
}

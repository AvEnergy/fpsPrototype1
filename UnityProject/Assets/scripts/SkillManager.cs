using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    [Header("-----Player Variables----")]
    public GameObject player;
    public playerController playerscript;


    [Header("-----SkillTree UI------")]
    [SerializeField] public GameObject skillMenuActive;
    [SerializeField] GameObject skillMenu;


    [Header("--------Skill Tree Elements-------")]


    [SerializeField] GameObject skilltree;
    public List<int> level_To_Unlock;
    public List<string> skillsUnlocked;
    public List<int> time_Duration;
    public List<SetSkills> skills;
    
    public int skillpoints;
    public int playerlvl;

    
    public bool displayOn;
    // Start is called before the first frame update
    void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
        }
        player = GameObject.FindWithTag("Player");
        playerscript = player.GetComponent<playerController>();
    }

    private void Start()
    {
        //Finds any objects that are childs of skilltree variable 
        //containing the script "SetSkills" and adds them to a list called Skills.
        //This should add only the buttons of the skill tree menu since they're the only ones that a SetSkills script attached.
        foreach(var skill in skilltree.GetComponentsInChildren<SetSkills>()) 
        {
            if (skill != null)
            {
                skills.Add(skill);
            }
        }
     
        //Function to initialize a list and set some levels.
        SetLevelUnlock();
    }


    // Update is called once per frame
    void Update()
    {
        //Pressing the M key will open the skill menu. 
        if(Input.GetKeyUp(KeyCode.M))
        {
            //Checks if SkillMenuActive doesn't have anything. Also Checks if the menuActive doesn't contain anything. Preventing menus from GameManger to open. 
            if (skillMenuActive == null && gameManager.instance.menuActive == null)
            {
                SkillMenuOn();
            }
        }
    }

  

    //Function that opens the skill Menu
    public void SkillMenuOn()
    {
        displayOn = true;
        skillMenu.SetActive(displayOn);
        Cursor.visible = true;

        //Set the current object selected to null since in most cases the object could be assigned to another object from other UI's.
        EventSystem.current.SetSelectedGameObject(null);
        //

        //Set the current object selected to the object called "SkillTreeButtonSelected" (Assigned the button, toggle, or whatever interactable you wish to access)"
        EventSystem.current.SetSelectedGameObject(gameManager.instance.SkillTreeButtonSelected);
        //This works to open visually see a button selected whenever the skill Menu is opened.

        Cursor.lockState = CursorLockMode.Confined;
        skillMenuActive = skillMenu;
    }


   //Turns of the Skill Menu
    public void SkillMenuOff()
    {
        displayOn = false;
        skillMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        skillMenuActive = null;
    }


    public void SetLevelUnlock()
    {
        level_To_Unlock = new List<int>() { 1, 2, 3, 4, 5};
    }
    
}

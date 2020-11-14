using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool GameIsPaused = false;

    public static bool InventoryIsOpen = false;

    public GameObject optionsMenu;

    public GameObject inventory;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public ItemDragAndDrop dragAndDrop;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }

        if(Input.GetKeyDown(KeyCode.E) && GameIsPaused == false)
        {
            inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
        }
    }

    void Resume()
    {
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        optionsMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public ItemContainer inventoryContainer;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Menu mainMenuPrefab;
        [SerializeField] private Menu settingsMenuPrefab;
        [SerializeField] private Menu creditsScreenPrefab;
        [SerializeField] private Menu gameMenuPrefab;
        [SerializeField] private Menu pauseMenuPrefab;
        [SerializeField] private Menu winScreenPrefab;

        [SerializeField] private Transform menuParent;

        private Stack<Menu> menuStack = new Stack<Menu>(); 

        private static MenuManager instance;
        public static MenuManager Instance { get { return instance; } }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                InitializeMenus();
                DontDestroyOnLoad(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

        private void InitializeMenus()
        {
            if (menuParent == null)
            {
                GameObject menusHolder = new GameObject("Menus");
                menuParent = menusHolder.transform;
                DontDestroyOnLoad(menuParent.gameObject);
            }

            BindingFlags searchFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            FieldInfo[] fields = this.GetType().GetFields(searchFlags);

            foreach (FieldInfo field in fields)
            {
                Menu prefab = field.GetValue(this) as Menu;

                if (prefab != null)
                {
                    Menu menuInstance = Instantiate(prefab, menuParent);

                    if (prefab != mainMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance); 
                    }
                }
            }
        }


        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null)
            {
                Debug.LogWarning("MENUMANAGER OpenMenu Error: no menuInstance was passed!");
            }

            // Disable all menus in the stack
            if (menuStack.Count > 0)
            {
                foreach (Menu menu in menuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }

            // Enable selected menu
            menuInstance.gameObject.SetActive(true);

            // Place enabled menu on top of the stack
            menuStack.Push(menuInstance);
        }

        public void CloseMenu()
        {
            if (menuStack.Count == 0)
            {
                Debug.LogWarning("MENUMANAGER CloseMenu Error: no menus in stack!");
            }

            // Remove top menu from the stack and disable it
            Menu topMenu = menuStack.Pop();
            topMenu.gameObject.SetActive(false);

            if (menuStack.Count > 0)
            {
                Menu nextMenu = menuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
    }
}




using PPRWBYTrn.Hack.Menu.Menus;
using Roost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PPRWBYTrn.Hack.Managers
{
    enum MenuType{
        Main,
        None
    }

    //Responsible for showing the right menu
    class MenuMgr
    {
        public static void Reset()
        {
            Menus.Clear();
            EventMgr.DeleteFunc(Events.OnUpdate, OnUpdate);
            EventMgr.DeleteFunc(Events.OnGui, DrawMenu);

            EventMgr.RegisterFunc(Events.OnGui, DrawMenu);
            EventMgr.RegisterFunc(Events.OnUpdate, OnUpdate);

            Menus.Add(new MainMenu());

            foreach (Menu.Menu Menu in Menus)
            {
                Menu.OnInit();
            }
        }

        
        private static void SetPauseState(bool state)
        {
            if (state)
            {
                Time.timeScale = 0;
				//Figure out urself how to emulate ingame menu
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public static void DrawMenu()
        {
#if (DEBUG)
            GUI.Label(new Rect(Screen.width - 200, 10, 200, 20), UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
#endif
            //Draw stuff
            if(iCurMenu >= 0)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    iCurMenu = -1;
                    SetPauseState(false);
                }

                Menus[iCurMenu].OnDraw();
            }
        }

        public static void OnUpdate()
        {
            for (int i = 0; i < Menus.Count; i++)
            {
                if(Input.GetKeyDown(Menus[i].getKey()))
                {
                    if (i == iCurMenu)
                    {
                        iCurMenu = -1;
                        SetPauseState(false);
                    }
                    else
                    {
                        iCurMenu = i;
                        SetPauseState(true);
                    }
                }

                Menus[i].OnUpdate();
            }
        }

        public static void setCurActiveMenu(int idx)
        {
            iCurMenu = idx;
        }

        public static Menu.Menu getMenuByType(MenuType type, int skip = 0)
        {
            foreach(Menu.Menu menu in Menus)
            {
                if (menu.getMenuType() == type)
                {
                    if(skip <= 0)
                        return menu;
                    skip--;
                }
            }
            return null;
        }


        public static Menu.Menu getMenuByIdx(int idx)
        {
            return Menus[idx];
        }

        public static Menu.Menu getCurrentMenu()
        {
            if (iCurMenu >= 0)
                return Menus[iCurMenu];
            return null;
        }

        public static int getCurMenuIdx()
        {
            return iCurMenu;
        }

        static List<Menu.Menu> Menus = new List<Menu.Menu>();
        static int iCurMenu = -1;
    }
}

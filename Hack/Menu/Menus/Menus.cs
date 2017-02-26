using PPRWBYTrn.Hack.Managers;
using PPRWBYTrn.Hack.Menu.Controls;
using PPRWBYTrn.Hack.Modules;
using Roost;
using UnityEngine;

namespace PPRWBYTrn.Hack.Menu.Menus	//DAT NAMING DOE
{
    class MainMenu : Menu
    {
        public CheckBox InfiniteHealth = new CheckBox("Infinite Health");

        public MainMenu() : base("Main Menu", KeyCode.F1, MenuType.Main)	//Dunno why there is menutype rn
        {
        }

        public override void OnInit()
        {
            InfiniteHealth.setOnToggle(MainMods.Test2);

            RegisterControl(InfiniteHealth, MainMods.InfiniteHealth);
            base.OnInit();
        }
    }
}

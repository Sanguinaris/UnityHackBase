using PPRWBYTrn.Hack.Menu.Controls;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PPRWBYTrn.Hack.Menu
{
    //Base Menu class which the menus derive from
    class Menu
    {
        //Config stuff (e.g. Menu drawing variables)

        public Menu(string MenuName, KeyCode key, Managers.MenuType menuType)
        {
            _MenuName = MenuName;
            _Key = key;
            _Menu = menuType;
        }

#region Overrides
        Color labelColor = new Color(0.5372f, 0.447f, 0.7529f);
        public virtual void OnDraw()
        {
            //TODO add upscaling and such
            scale.x = Screen.width / orginalWidth;
            scale.y = Screen.height / orginalHeight;

            var origMatrix = GUI.matrix;
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

            GUI.Box(new Rect(230, 0, 170, 400), _MenuName);
            GUI.Box(new Rect(230, 0, 170, 400), _MenuName);
            GUI.Box(new Rect(230, 0, 170, 400), _MenuName);
            GUI.Box(new Rect(230, 0, 170, 400), _MenuName);
            scrollValue = GUI.VerticalScrollbar(new Rect(400, 0, 100, 400), scrollValue, 5.0f, 0, curY - 358 > 0  ? curY - 358 : 0);
            GUI.BeginGroup(new Rect(240, 22, 160, 358));

            foreach (Control control in Controls)
            {
                control.setScrollValue(scrollValue);
                control.OnDraw();
            }
            GUI.EndGroup();
            GUI.color = labelColor;
            GUI.Label(new Rect(255, 380, 130, 20), "PiratePerfection.com");
            GUI.color = Color.white;
            GUI.matrix = origMatrix;
        }

        public virtual void OnInit()
        {
            //Set positions for controls

            scale.z = 1;
        }

        public virtual void OnUpdate()
        {
            //Module stuff
            foreach (Control control in Controls)
            {
                control.OnUpdate();
            }
        }
#endregion

        private float scrollValue = 0;

        private readonly float orginalWidth = 640;
        private readonly float orginalHeight = 400;
        Vector3 scale;
        protected float curY = 0;
        protected void incrementY(float divider) { curY += 80 / divider + 12; }

        public void RegisterControl(Control control, Action Funk = null)
        {
            control.setPosition(0, (int)curY);

            switch(control.getControlType())
            {
                case ControlType.TextBox:
                case ControlType.Button:
                    incrementY(2);
                    break;
                case ControlType.CheckBox:
                    incrementY(5);
                    break;
                case ControlType.Slider:
                    incrementY(4);
                    break;
            }

            control.setBaseAction(Funk);
            control.setParentMenu(_Menu);
            Controls.Add(control);
        }

#region Getters
        public List<Control> getControls()
        {
            return Controls;
        }

        public Control getControlAt(int idx)
        {
            if (idx >= 0 && idx < Controls.Count)
                return Controls[idx];
            return null;
        }

        public KeyCode getKey()
        {
            return _Key;
        }

        public string getMenuName()
        {
            return _MenuName;
        }

        public Managers.MenuType getMenuType()
        {
            return _Menu;
        }
        #endregion
#region Setters
        public void setName(string name) { _MenuName = name; }  //Localization?
        public void setKey(KeyCode key) { _Key = key; }
#endregion


        protected List<Control> Controls = new List<Control>();
        private string _MenuName;
        private KeyCode _Key;
        private Managers.MenuType _Menu;
    }
}

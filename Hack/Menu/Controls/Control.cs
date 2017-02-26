using PPRWBYTrn.Hack.Managers;
using PPRWBYTrn.Hack.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PPRWBYTrn.Hack.Menu.Controls
{
    enum ControlType
    {
        CheckBox = 1,
        TextBox,
        Slider,
        Button,
        GridSelection
    }

    enum ControlFlags
    {
        None = 0x00,
        SaveAble = 0x01,
        KeyBindable = 0x02
    }

    class Control
    {
#region Virtual funcs

        public virtual void OnDraw()    //Draws the gui element
        { }

        public virtual void OnUpdate()
        { }

#endregion
#region Setters

        public void setBaseAction(Action funk) { Funky = funk; }

        public void setPosition(int xPos, int yPos)
        {
            _Position.x = xPos;
            _Position.y = yPos;
        }

        public void setSize(int width, int height)
        {
            _Position.width = width;
            _Position.height = height;
        }

        public void setName(string name)
        {
            ControlName = name;
        }

        public void setFileName(string name)
        {
            FileName = name;
        }

        public void setParentMenu(MenuType menu)
        {
            parentMenu = menu;
        }

        public void setLocked(bool state)
        {
            Locked = state;
        }

        public void setKey(KeyCode key)
        {
            Key = key;
        }

        public void setScrollValue(float scroll)
        {
            ScrollValue = scroll;
        }

#endregion
#region Getters
        
        public string getName()
        {
            return ControlName;
        }

        public string getFileName()
        {
            return FileName;
        }

        public ControlType getControlType()
        {
            return type;
        }

        public bool isLocked()
        {
            return Locked;
        }

        public MenuType getParentMenu()
        {
            return parentMenu;
        }

        public int getFlags()
        {
            return Flags;
        }

        public KeyCode getKey()
        {
            return Key;
        }

        #endregion
        #region Vars

        private float ScrollValue = 0;
        protected Action Funky;
        protected string FileName;  //Name of the Control when saving
        protected string ControlName;   //Name of the Control when drawing
        private Rect _Position;    //Position and Size when drawing

        protected Rect Position
        {
            get
            {
                Rect tempPos = _Position;
                tempPos.y -= ScrollValue;
                return tempPos;
            }
            set
            {
                _Position = value;
            }
        }

        protected ControlType type; //The type of the control (for loading and saving and such)
        protected int Flags;    //Flags of the Control to determine wether or not it should do stuff
        protected MenuType parentMenu;
        protected bool Locked = false;
        protected KeyCode Key;

#endregion
    }
}

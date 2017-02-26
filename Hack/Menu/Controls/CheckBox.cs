using System;
using UnityEngine;

namespace PPRWBYTrn.Hack.Menu.Controls
{
    class CheckBox : Control
    {
        public CheckBox(string Name = "", KeyCode key = KeyCode.None)
        {
            Key = key;
            ControlName = Name;
            Flags |= (int)ControlFlags.SaveAble | (int)ControlFlags.KeyBindable;
            type = ControlType.CheckBox;
            Position = new Rect(0, 0, 160, 16);
        }

        public void setState(bool state)
        {
            State = state;
        }

        public void setOnEnable(Action funk)
        {
            OnEnable = funk;
        }

        public void setOnDisable(Action funk)
        {
            OnDisable = funk;
        }

        public void setOnToggle(Action funk)
        {
            OnToggle = funk;
        }

        public bool getState()
        {
            return State;
        }

        public override void OnDraw()
        {
            State = GUI.Toggle(Position, State, ControlName);
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyUp(Key))
                State = !State;

            if (State && !prevState)
            {
                OnEnable?.Invoke();
                OnToggle?.Invoke();
            }else if(!State && prevState)
            {
                OnDisable?.Invoke();
                OnToggle?.Invoke();
            }


            if (State)
                Funky?.Invoke();
                
            prevState = State;
        }

        private bool State = false;
        private bool prevState = false;

        private Action OnToggle, OnEnable, OnDisable;
    }
}

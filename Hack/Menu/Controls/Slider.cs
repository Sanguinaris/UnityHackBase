using System;
using UnityEngine;

namespace PPRWBYTrn.Hack.Menu.Controls
{
    class Slider : Control
    {
        public Slider(float maximValue = 1, float minimValue = 0)
        {
            type = ControlType.Slider;
            Position = new Rect(0, 0, 160, 40);
            maxValue = maximValue;
            minValue = minimValue;
        }

        public override void OnDraw()
        {
            curValue = GUI.HorizontalSlider(Position, curValue, minValue, maxValue);
        }

        public override void OnUpdate()
        {
            if(curValue != lastValue)
            {
                lastValue = curValue;
                OnValueChanged?.Invoke();
            }
        }

        public float getValue()
        {
            return curValue;
        }

        public void setValue(float value)
        {
            curValue = value;
        }

        public void setOnValueChanged(Action funk)
        {
            OnValueChanged = funk;
        }

        float minValue = 0;
        float maxValue = 1;
        float curValue = 0;
        float lastValue;
        Action OnValueChanged;
    }
}

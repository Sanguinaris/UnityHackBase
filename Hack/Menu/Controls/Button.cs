using UnityEngine;

namespace PPRWBYTrn.Hack.Menu.Controls
{
    class Button : Control
    {
        public Button(ref Slider childSlider, string Name = "", KeyCode key = KeyCode.None)
        {
            Key = key;
            ControlName = Name;
            Flags |= (int)ControlFlags.KeyBindable;
            type = ControlType.Button;
            Position = new Rect(0, 0, 160, 40);
            slider = childSlider;
        }

        public Button(string Name = "", KeyCode key = KeyCode.None)
        {
            Key = key;
            ControlName = Name;
            Flags |= (int)ControlFlags.KeyBindable;
            type = ControlType.Button;
            Position = new Rect(0, 0, 160, 40);
        }

        public override void OnDraw()
        {
            if (GUI.Button(Position, (slider == null) ? ControlName : ControlName + ": " + slider.getValue().ToString()))
                Funky?.Invoke();
        }

        Slider slider;
    }
}

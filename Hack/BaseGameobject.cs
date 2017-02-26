using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PPRWBYTrn.Hack
{
    class BaseGameobject : MonoBehaviour
    { 
        private void Start()
        {
            //Will be executed on Object generation
            //Initializing Managers
            Managers.EventMgr.Reset();
            Managers.MenuMgr.Reset();
        }

        private void Update()
        {
            //Will be called each update
            Managers.EventMgr.InvokeEvent(Managers.Events.OnUpdate);
        }

        private void OnGUI()
        {
            //Will be called on the drawingz

            Managers.EventMgr.InvokeEvent(Managers.Events.OnGui);   //Invokes the gui event 
        }
    }
}

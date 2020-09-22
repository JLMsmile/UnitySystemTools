using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyWork
{
    public class Startup : MonoBehaviour
    {
        private UIManager ui_manager;
        private GameManager game_manager;
        private void Awake()
        {
            MyWork.Event.AddListener(EventId.StartEvent,this.Crate);
            DontDestroyOnLoad(this);
            ui_manager = UIManager.Instance;
            game_manager = GameManager.Instance;
        }

        private void Start()
        {
            MyWork.Event.Broadcast(EventId.StartEvent);
        }

        private void OnDestroy()
        {
            MyWork.Event.RemoveListener(EventId.StartEvent,this.Crate);
            Debug.Log($"移除事件");
        }

        private void Crate()
        {
            Debug.Log($"Event Test-------------");
        }
    }
    
}


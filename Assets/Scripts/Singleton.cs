using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyWork
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        private static readonly object locker = new object();
        private static bool applicationIsQutting;

        public static T Instance
        {
            get
            {
                lock (Singleton<T>.locker) {
                    if( Singleton<T>.instance != null ) {
                        return Singleton<T>.instance;
                    }

                    Singleton<T>.instance = Object.FindObjectOfType(typeof(T)) as T;
                    if( Object.FindObjectsOfType(typeof(T)).Length > 1 ) {
                        Debug.LogError(@"[Singleton] 发现多余1个的单例对象");
                        return Singleton<T>.instance;
                    }

                    if( Singleton<T>.instance == null ) {
                        if( Singleton<T>.applicationIsQutting ) {
                            Debug.LogWarning($"[Singleton] 对象'{typeof(T)}'在应用程序关闭时释放，不能重新获取使用，返回null");
                        }
                        GameObject singleton = new GameObject();
                        Singleton<T>.instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T);
                        Object.DontDestroyOnLoad(singleton);
                        Debug.Log($"[Singleton] 场景中需要一个 {typeof(T)} 的单例对象，创建'{singleton}'并设置为 DontDestroyOnLoad.");
                        
                    }
                    else {
                        Debug.Log($"[Singleton] 场景中找到'{typeof(T)}'的单例对象'{Singleton<T>.instance.gameObject}'");
                    }

                    return Singleton<T>.instance;
                }
            }
            set => instance = value;
        }

        protected virtual void Awake()
        {
            Debug.Log($"[Singleton] 在'{this.gameObject}'对象上创建单例'{typeof(T)}'");
            Singleton<T>.applicationIsQutting = false;
            
        }

        protected virtual void OnDestroy(){
            this.Purge();
            Debug.Log($"[Singleton] 释放'{this.gameObject}'对象上的单例'{typeof(T)}'");
        }


        public virtual void Purge(){
            
        }

        private void OnApplicationQuit()
        {
            Singleton<T>.applicationIsQutting = true;
        }
    }    
}



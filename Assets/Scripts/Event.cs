using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MyWork
{

    public enum EventId
    {
        StartEvent,
    }
     
    
    public static class Event 
    {
        private static readonly Dictionary<EventId,List<Delegate>> Listener = new Dictionary<EventId, List<Delegate>>();
        
        private static List<Delegate> GetHandlers(EventId eventId)
        {
            List<Delegate> handlers;
            if( !Listener.ContainsKey(eventId) ) {
                handlers = new List<Delegate>();
                Event.Listener.Add(eventId,handlers);
            }
            handlers = Event.Listener[eventId];
            return handlers;
        }
        
        public static void AddListener(EventId eventId,Action handler)
        {
            List<Delegate> handlers = Event.GetHandlers(eventId);
            if( !handlers.Contains(handler) ) {
                handlers.Add(handler);
            }
        }

        public static void AddListener<T1>(EventId eventId,Action<T1> handler)
        {
            List<Delegate> handlers = Event.GetHandlers(eventId);
            if( !handlers.Contains(handler) ) {
                handlers.Add(handler);
            }

        }
        
        public static void AddListener<T1,T2>(EventId eventId,Action<T1,T2> handler)
        {
            List<Delegate> handlers = Event.GetHandlers(eventId);
            if( !handlers.Contains(handler) ) {
                handlers.Add(handler);
            }

        }
        
        public static void AddListener<T1,T2,T3>(EventId eventId,Action<T1,T2,T3> handler)
        {
            List<Delegate> handlers = Event.GetHandlers(eventId);
            if( !handlers.Contains(handler) ) {
                handlers.Add(handler);
            }

        }
        
        public static void AddListener<T1,T2,T3,T4>(EventId eventId,Action<T1,T2,T3,T4> handler)
        {
            List<Delegate> handlers = Event.GetHandlers(eventId);
            if( !handlers.Contains(handler) ) {
                handlers.Add(handler);
            }
        }
        
        public static void AddListener<T1,T2,T3,T4,T5>(EventId eventId,Action<T1,T2,T3,T4,T5> handler)
        {
            List<Delegate> handlers = Event.GetHandlers(eventId);
            if( !handlers.Contains(handler) ) {
                handlers.Add(handler);
            }
        }
        
        //--------------------------------------------------------------------------------------------------------------

        public static void RemoveListener(EventId eventId, Action action)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            if( handlers.Contains(action) ) {
                handlers.Remove(action);
            }
        }
        
        public static void RemoveListener<T1>(EventId eventId, Action<T1> action)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            if( handlers.Contains(action) ) {
                handlers.Remove(action);
            }
        }
        
        public static void RemoveListener<T1,T2>(EventId eventId, Action<T1,T2> action)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            if( handlers.Contains(action) ) {
                handlers.Remove(action);
            }
        }
        
        public static void RemoveListener<T1,T2,T3>(EventId eventId, Action<T1,T2,T3> action)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            if( handlers.Contains(action) ) {
                handlers.Remove(action);
            }
        }
        
        public static void RemoveListener<T1,T2,T3,T4>(EventId eventId, Action<T1,T2,T3,T4> action)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            if( handlers.Contains(action) ) {
                handlers.Remove(action);
            }
        }
        
        public static void RemoveListener<T1,T2,T3,T4,T5>(EventId eventId, Action<T1,T2,T3,T4,T5> action)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            if( handlers.Contains(action) ) {
                handlers.Remove(action);
            }
        }
        
        //--------------------------------------------------------------------------------------------------------------

        public static void Broadcast(EventId eventId)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            
            foreach (var action in handlers) {
                if( action is Action act ) {
                    act.Invoke();
                }
            }
        }
        
        public static void Broadcast<T>(EventId eventId ,T arg1)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            
            foreach (var action in handlers) {
                if( action is Action<T> act ) {
                    act.Invoke(arg1);
                }
            }
        }
        
        public static void Broadcast<T1,T2>(EventId eventId ,T1 arg1 , T2 arg2)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            
            foreach (var action in handlers) {
                if( action is Action<T1,T2> act ) {
                    act.Invoke(arg1,arg2);
                }
            }
        }
        
        public static void Broadcast<T1,T2 ,T3>(EventId eventId ,T1 arg1 ,T2 arg2 ,T3 arg3)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            
            foreach (var action in handlers) {
                if( action is Action<T1,T2,T3> act ) {
                    act.Invoke(arg1,arg2,arg3);
                }
            }
        }
        
        public static void Broadcast<T1,T2 ,T3,T4>(EventId eventId ,T1 arg1 ,T2 arg2 ,T3 arg3 ,T4 arg4)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            
            foreach (var action in handlers) {
                if( action is Action<T1,T2,T3,T4> act ) {
                    act.Invoke(arg1,arg2,arg3,arg4);
                }
            }
        }
        
        public static void Broadcast<T1,T2 ,T3,T4 ,T5>(EventId eventId ,T1 arg1 ,T2 arg2 ,T3 arg3 ,T4 arg4 , T5 arg5)
        {
            List<Delegate> handlers = GetHandlers(eventId);
            
            foreach (var action in handlers) {
                if( action is Action<T1,T2,T3,T4,T5> act ) {
                    act.Invoke(arg1,arg2,arg3,arg4,arg5);
                }
            }
        }
    }
}



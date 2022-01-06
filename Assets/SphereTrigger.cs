 using System.Collections.Generic;
 using UnityEngine;
 
 public class SphereTrigger : MonoBehaviour
 {
     private Dictionary<Collider, bool> _triggerStates = new Dictionary<Collider, bool>();
     public List<Collider> _currentTriggers { get; private set; } = new List<Collider>();
     private bool _on = true;
 
     
     private void FixedUpdate()
     {
         for (var i = 0; i < _currentTriggers.Count; i++)
         {
             var trigger = _currentTriggers[i];
             // If the trigger is no more, for whatever reason, remove it.
             if (!trigger)
             {
                 _triggerStates.Remove(trigger);
                 _currentTriggers.Remove(trigger);
                 continue;
             }
 
             if (!_triggerStates.ContainsKey(trigger))
             {
                 _currentTriggers.Remove(trigger);
             }
             else
             {
                 if (!_triggerStates[trigger])
                 {
                     _triggerStates.Remove(trigger);
                     _currentTriggers.Remove(trigger);
                 }
                 else
                 {
                     _triggerStates[trigger] = false;
                 }
             }
         }
     }
 
     private void OnTriggerEnter(Collider other)
     {
         //if the object is not already in the list
         if (!_triggerStates.ContainsKey(other))
         {
             //add the object to the list
             _triggerStates.Add(other, true);
             _currentTriggers.Add(other);
            Debug.Log("Element entered the Trigger");

         }
     }
 
     
     private void OnTriggerStay(Collider other)
     {
         if (!_triggerStates.ContainsKey(other))
         {
             //add the object to the list
             _triggerStates.Add(other, true);
             _currentTriggers.Add(other);
         }
         else
         {
             _triggerStates[other] = true;
         }
     }
 
     // Called when a trigger exits.
     private void OnTriggerExit(Collider other)
     {
         _triggerStates.Remove(other);
         _currentTriggers.Remove(other);
     }
 
     public void ResetRegisteredTriggers()
     {
         _currentTriggers.Clear();
         _triggerStates.Clear();
     }
 
     public void Toggle(bool on, bool resetCurrentTriggers = true)
     {
         _on = on;
         if(resetCurrentTriggers)
             ResetRegisteredTriggers();
     }
 }
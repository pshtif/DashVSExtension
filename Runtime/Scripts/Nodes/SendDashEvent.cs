// #if DASH_VISUAL_SCRIPTING

using Dash;
using Unity.VisualScripting;
using UnityEngine;

public class SendDashEvent : Unit
{
   [DoNotSerialize] 
   public ControlInput inputTrigger; 

   [DoNotSerialize] 
   public ControlOutput outputTrigger;
   
   [DoNotSerialize] 
   public ValueInput eventNameValue;
   
   protected override void Definition()
   {
      inputTrigger = ControlInput("inputTrigger", (flow) =>
      {
         string eventName = flow.GetValue<string>(eventNameValue);
         DashCore.Instance.SendEvent(eventName, NodeFlowDataFactory.Create());
         return outputTrigger;
      });
      outputTrigger = ControlOutput("outputTrigger");

      eventNameValue = ValueInput<string>("Event Name", "event");
   }
}
// #endif
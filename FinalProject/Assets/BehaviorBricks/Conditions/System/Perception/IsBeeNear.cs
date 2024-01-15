using UnityEngine;
 
using Pada1.BBCore;
using Pada1.BBCore.Framework; 

[Condition("MyConditions/Is Bee Near?")]
[Help("Checks whether Bee is near the Treasure.")]
public class IsBeeNear : ConditionBase
{
    public override bool Check()
    {
        GameObject cop = GameObject.Find("Bee");
        GameObject treasure = GameObject.Find("Treasure");
        return Vector3.Distance(cop.transform.position, treasure.transform.position) < 30f;
    }
} 

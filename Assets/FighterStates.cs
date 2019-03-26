using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travelling : State {
    //public StateMachine owner;
    public override void Enter() {
        Debug.Log("Entered Travelling State" + owner);
        owner.GetComponent<FighterScript>().PickTargetBase();
        owner.GetComponent<Arrive>().enabled = true;
    }
    public override void Exit() {
        Debug.Log("Exited Travelling State" + owner);
        owner.GetComponent<Arrive>().enabled = false;
        owner.GetComponent<Boid>().velocity = Vector3.zero;
        //Turn off seek behaviour
    }
    public override void Think() {
        //If target is < 20 away from base transition to attacking state
        Vector3 target = owner.GetComponent<FighterScript>().target.position;
        if (Vector3.Distance(owner.transform.position, target) < 20) {
            owner.GetComponent<StateMachine>().ChangeState(new Attacking());
        }
    }
}

public class Refueling : State {
    public override void Enter()
    {
        owner.GetComponent<FighterScript>().AttemptRefuel();
    }
    public override void Exit()
    {
        owner.GetComponent<FighterScript>().StopRefueling();
    }
    public override void Think()
    {
        if (owner.GetComponent<FighterScript>().GetTiribium() >= 7) {
            owner.GetComponent<StateMachine>().ChangeState(new Travelling());
        }
    }
}

public class Attacking : State {
    //public StateMachine owner;
    public override void Enter() {
        owner.GetComponent<FighterScript>().StartShootingBase();
    }
    public override void Exit() {
        owner.GetComponent<FighterScript>().StopShootingBase();
    }
    public override void Think() {
        if (owner.GetComponent<FighterScript>().GetTiribium() <= 0) {
            owner.GetComponent<StateMachine>().ChangeState(new Retrieving());
        }
    }
}

public class Retrieving : State {
    //public StateMachine owner;
    public override void Enter() {
        owner.GetComponent<FighterScript>().SetParentTarget();
        owner.GetComponent<Arrive>().enabled = true;
    }
    public override void Exit() {
        owner.GetComponent<Arrive>().enabled = false;
        // finish seek
    }
    public override void Think() {
        //keep checking if at the base or not, if hit the base despawn
        Vector3 target = owner.GetComponent<FighterScript>().target.position;
        if (Vector3.Distance(owner.transform.position, target) < 1)
        {
            owner.GetComponent<StateMachine>().ChangeState(new Refueling());
        }
    }
}

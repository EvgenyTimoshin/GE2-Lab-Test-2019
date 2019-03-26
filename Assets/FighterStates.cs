using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travelling : State {
    //public StateMachine owner;
    public void Enter() {
        owner.GetComponent<FighterScript>().PickTargetBase();
        owner.GetComponent<Arrive>().enabled = true;
    }
    public void Exit() {

        owner.GetComponent<Arrive>().enabled = false;
        //Turn off seek behaviour
    }
    public void Think() {
        //If target is < 20 away from base transition to attacking state
        Vector3 target = owner.GetComponent<FighterScript>().target.position;
        if (Vector3.Distance(owner.transform.position, target) < 20) {
            owner.GetComponent<StateMachine>().ChangeState(new Attacking());
        }
    }
}

public class Refueling : State {
    public void Enter()
    {
        owner.GetComponent<FighterScript>().AttemptRefuel();
    }
    public void Exit()
    {
        owner.GetComponent<FighterScript>().StopRefueling();
    }
    public void Think()
    {
        //wait for base to return 7 teribium
    }
}

public class Attacking : State {
    //public StateMachine owner;
    public void Enter() {
        owner.GetComponent<FighterScript>().StartShootingBase();
    }
    public void Exit() {
        owner.GetComponent<FighterScript>().StopShootingBase();
    }
    public void Think() {
        if (owner.GetComponent<FighterScript>().GetTiribium() <= 0) {
            owner.GetComponent<StateMachine>().ChangeState(new Retrieving());
        }
    }
}

public class Retrieving : State {
    //public StateMachine owner;
    public void Enter() {
        owner.GetComponent<FighterScript>().SetParentTarget();
        owner.GetComponent<Arrive>().enabled = true;
    }
    public void Exit() {
        owner.GetComponent<Arrive>().enabled = false;
        // finish seek
    }
    public void Think() {
        //keep checking if at the base or not, if hit the base despawn
        Vector3 target = owner.GetComponent<FighterScript>().target.position;
        if (Vector3.Distance(owner.transform.position, target) < 20)
        {
            owner.GetComponent<StateMachine>().ChangeState(new Refueling());
        }
    }
}

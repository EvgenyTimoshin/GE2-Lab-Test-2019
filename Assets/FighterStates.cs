using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travelling : State {
    //public StateMachine owner;
    public void Enter() {
        //transition to this state
    }
    public void Exit() {
        //exit this state
    }
    public void Think() {

        //Check to see if close to the base
    }
}

public class Attacking : State {
    //public StateMachine owner;
    public void Enter() {
        //transition to this state
    }
    public void Exit() {
        //exit this state
    }
    public void Think() {
        //Shoot while there is enough tiribium in the base to shoot
    }
}

public class Retrieving : State {
    //public StateMachine owner;
    public void Enter() { }
    public void Exit() { }
    public void Think() {
        //keep checking if at the base or not, if hit the base despawn
    }
}

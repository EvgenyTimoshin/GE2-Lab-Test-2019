using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travelling : State {
    //public StateMachine owner;
    public void Enter() {
       
        //Turn on seek behaviour
    }
    public void Exit() {
        
        
        //Turn off seek behaviour
    }
    public void Think() {
        //If target is < 20 away from base transition to attacking state
    }
}

public class Refueling : State {
    public void Enter()
    {
        //Turn on refueling behaviour
    }
    public void Exit()
    {
        //stop refuleing
    }
    public void Think()
    {
        //wait for base to return 7 teribium
    }
}

public class Attacking : State {
    //public StateMachine owner;
    public void Enter() {
        //Turn on shooting behaviour
    }
    public void Exit() {
        //stop shooting
    }
    public void Think() {
        //Shoot while there is enough tiribium in the base to shoot
    }
}

public class Retrieving : State {
    //public StateMachine owner;
    public void Enter() {
        // Seek to parent turned on
    }
    public void Exit() {
        // finish seek
    }
    public void Think() {
        //keep checking if at the base or not, if hit the base despawn
    }
}

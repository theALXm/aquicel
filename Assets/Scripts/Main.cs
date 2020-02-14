using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main singleton;

    public StateMachine stateMachine = new StateMachine();

    public PlayingState playing = new PlayingState("Playing");
    public PausedState paused = new PausedState("Paused");

    void Awake()
    {
        if(singleton != this && singleton != null)
        {
            GameObject.Destroy(this);
        }
        else
        {
            singleton = this;
        }      
    }    

    private void Start()
    {
        stateMachine.ChangeState(playing);
    }    

    void Update()
    {       
        stateMachine.ExecuteState();
    }
}

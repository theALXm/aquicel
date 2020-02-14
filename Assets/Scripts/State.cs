using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected string stateName;     //String que armazena o nome do estado

    //Esta função obrigatoriamente deve ser definida nas classes que a herdarem, por estar marcada como abstract
    public abstract void Enter();   //Função abstrata que dita o que deve ser feito ao entrar em um estado

    public virtual void Execute()
    {
        //Mostrar no console o valor da variável "stateName"
        Debug.Log(stateName);
    }

    //Esta função obrigatoriamente deve ser definida nas classes que a herdarem, por estar marcada como abstract
    public abstract void Exit();    //Função abstrata que dita o que deve ser feito ao sair de um estado
}

public class PlayingState : State
{
    public PlayingState(string name)
    {
        stateName = name;
    }

    public override void Enter()
    {
        Debug.Log("Entrando no estado: " + stateName);
    }
    
    public override void Execute()
    {
        base.Execute();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Main.singleton.stateMachine.ChangeState(Main.singleton.paused);
        }
    }
    
    public override void Exit()
    {
        Debug.Log("Saindo do estado: " + stateName);
    }
}

public class PausedState : State
{
    public PausedState(string name)
    {
        stateName = name;
    }

    public override void Enter()
    {
        
    }

    public override void Execute()
    {
        Debug.Log(stateName);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Main.singleton.stateMachine.ChangeState(Main.singleton.playing);
        }
    }

    public override void Exit()
    {
        
    }
}

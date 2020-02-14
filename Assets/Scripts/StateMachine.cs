using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State currentState;     //Estado que a máquina deve executar
    private State previousState;    //Estado que a máquina executou anteriormente

    
    public void ExecuteState() //Função chamada no Update() da classe Main
    {
        //Invocar a função Execute() do estado atual
        currentState.Execute();
    }

    //Função para trocar de estado
    public void ChangeState(State newState)
    {
        //Verificar se o objeto currentState não é nulo
        if (currentState != null)
        {
            //Parar o estado atual
            currentState.Exit();

            //Armazenar o estado que estava executando anteriormente
            previousState = currentState;
        }        

        //Colocar um novo estado
        currentState = newState;

        //Executar função para "entrar" no novo estado
        currentState.Enter();
    }
}

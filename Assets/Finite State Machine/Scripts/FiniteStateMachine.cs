using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
namespace ulonce.FiniteStateMachine
{


    public enum States
    {
        IDLE,
        PATROLLING,
        PERSECUTING
    }
    public class FiniteStateMachine : MonoBehaviour
    {
        //declaration of the variable
        public States myState;
        //instation of the variable
        #region UnityMethods
        void Start()
        {

        }
        //operation of the variable
        private void Update()
        {
            //discriminate the state of the variable
            Debug.Log(gameObject.name + "JIjijija is on " + myState.ToString() + " state");
            switch (myState)
            {
                case States.IDLE:
                    //TODO:
                    //Log
                    //LogWarning
                    //LogError
                    //Debug.Log(gameObject.name + "JIjijija is on IDLE State");
                    IdleState();
                    break;
                case States.PATROLLING:
                    //TODO:
                    //Debug.Log(gameObject.name + "JIjijija is on Patrolling State");
                    PatrollingState();
                    break;
                case States.PERSECUTING:
                    //TODO:
                    //Debug.Log(gameObject.name + "JIjijija is on Persecuting State");
                    PersecutingState();
                    break;
            }
        }
        #endregion
        #region FiniteStateMachineMethods
        protected void IdleState()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeState(States.PATROLLING);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeState(States.PERSECUTING);
            }
        }
        protected void PatrollingState()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeState(States.IDLE);
            }
        }
        protected void PersecutingState()
        {
            Invoke("ChangeToIdleState", 3.0f);
        }
        public void ChangeState(States value)
        {
            Debug.Log(gameObject.name + "Finite State Machine - ChangeState() - We will move to the " + value.ToString() + " state");
            myState = value;
        }
        #endregion
        void ChangeToIdleState()
        {
            ChangeState(States.IDLE);
        }
    }
}
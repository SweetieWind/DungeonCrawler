using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
namespace ulonce.FiniteStateMachine
{

    #region Enums
    public enum States
    {
        //Idle
        IDLE_UP,
        IDLE_DOWN,
        IDLE_LEFT,
        IDLE_RIGHT,
        //Moving
        MOVING_UP,
        MOVING_DOWN,
        MOVING_LEFT,
        MOVING_RIGHT,
    }
    #endregion
    public class FiniteStateMachine : MonoBehaviour
    {
        #region Knobs
        //declaration of the variable
        public States myState;
        //instation of the variable
        #endregion
        #region UnityMethods
        void Start()
        {

        }
        //operation of the variable
        private void Update()
        {
            //discriminate the state of the variable
            Debug.Log(gameObject.name + "FiniteStateMachine - Update ()]: Is in any IDLE state " + IsInIdleState);
            Debug.Log(gameObject.name + "JIjijija is on " + myState.ToString() + " state");
            switch (myState)
            {
                case States.IDLE_UP:
                case States.IDLE_DOWN:
                case States.IDLE_LEFT:
                case States.IDLE_RIGHT:
                    IdleState();
                    break;
                case States.MOVING_UP:
                case States.MOVING_DOWN:
                case States.MOVING_LEFT:
                case States.MOVING_RIGHT:
                    IdleState();
                    break;
            }
        }
        #endregion
        #region FiniteStateMachineMethods
        protected void IdleState()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SetState = States.MOVING_UP;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                SetState = States.MOVING_DOWN;
            }
        }
        protected void MovingState()
        {

        }
        protected void PatrollingState()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //ChangeState(States.IDLE);
            }
        }
        protected void PersecutingState()
        {
            Invoke("ChangeToIdleState", 3.0f);
        }

        #endregion
        #region Public Methods
        public void ChangeState(States value)
        {
            Debug.Log(gameObject.name + "Finite State Machine - ChangeState() - We will move to the " + value.ToString() + " state");
            myState = value;
        }
        #endregion
        #region LocalMethods
        void ChangeToIdleState()
        {
            ChangeState(States.IDLE_DOWN);
        }
        #endregion
        #region GettersAndSetters
        protected bool IsInIdleState
        {
            get
            {
                return (myState == States.IDLE_UP
                    || myState == States.IDLE_DOWN
                    || myState == States.IDLE_LEFT
                    || myState == States.IDLE_RIGHT);
            }
        }
        public States SetState
        {
            set
            {
                Debug.Log(gameObject.name + "Finite Stae Machine - SetState - We will move to " + myState);
                myState = value;
            }
        }
        #endregion
    }
}
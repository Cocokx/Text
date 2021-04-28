using System;
using System.Collections;
using System.Collections.Generic;

public class InuStateMachine<T> where T : struct
{
    public class InuState
    {
        public T mStateName = default(T);//"DefaultStateName";

        //It is the FSM the state inside
        public InuStateMachine<T> m_Fsm = null;

        //Events
        //public event OnEnterHandler OnEnter;
        //public event OnUpdateHandler OnUpdate;
        //public event OnExitHandler OnExit;

        public InuState(InuStateMachine<T> stateMachine, T stateName)
        {
            m_Fsm = stateMachine;
            mStateName = stateName;
        }

        //public virtual void Enter() { }
        //public virtual void Update() { }
        //public virtual void Exit() { }

        public virtual void EnterState()
        {
            //if (OnEnter != null)
            //{
            //    OnEnter();
            //}
            //Enter();
        }

        public virtual void UpdateState()
        {
            //if (OnUpdate != null)
            //{
            //    OnUpdate();
            //}
            //Update();
        }

        public virtual void ExitState()
        {
            //if (OnExit != null)
            //{
            //    OnExit();
            //}
            //Exit();
        }
    }

    public Dictionary<T, InuState> m_stateList = new Dictionary<T, InuState>();

    public InuState m_CurState { get; private set; }
    public InuState m_PreState { get; private set; }

    bool m_CurStateUpdated = false;

    public InuState this[T stateName]
    {
        get
        {
            if (!m_stateList.ContainsKey(stateName))
                return null;

            return m_stateList[stateName];
        }
        set
        {
            m_stateList[stateName] = value;
        }
    }

    public InuStateMachine()
    {
    }

    public InuState GetState(T stateName)
    {
        InuState state;
        m_stateList.TryGetValue(stateName, out state);
        return state;
    }

    public void AddState(T stateName, InuState state)
    {
        state.m_Fsm = this;
        state.mStateName = stateName;
        m_stateList.Add(stateName, state);
    }

    public void ChangeState(T newStateName)
    {
        //if (IsInState(newStateName))
        //{
        //    return;
        //}
        if (!m_CurStateUpdated && m_CurState != null)
            InuDebug.Assert(m_CurStateUpdated, "state " + m_CurState.mStateName + " should be updated before change to " + newStateName);

        InuDebug.Assert(m_stateList.ContainsKey(newStateName), "state should exist: " + newStateName);

        InuState newState = m_stateList[newStateName];
        InuDebug.Assert(newState != null, "state should not be null: " + newStateName);

        m_CurStateUpdated = false;

        //Exit current state first
        if (m_CurState != null) m_CurState.ExitState();

        //record previous state
        m_PreState = m_CurState;

        //Change currnet state
        m_CurState = newState;

        //Entry new state
        m_CurState.EnterState();
    }

    public bool IsInState(T checkStateName)
    {
        if (!m_stateList.ContainsKey(checkStateName))
            return false;

        return m_CurState == m_stateList[checkStateName];
    }

    public bool IsInState(InuState checkState)
    {
        return m_CurState == checkState;
    }

    public virtual void Update()
    {
        if (m_CurState == null) return;

        m_CurStateUpdated = true;

        //excute current state
        m_CurState.UpdateState();
    }
}
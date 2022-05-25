namespace FiniteStateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
        virtual void Update(){}
        virtual void FixedUpdate(){}
        virtual void LateUpdate(){}
    }
}
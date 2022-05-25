namespace FiniteStateMachine
{
    public interface IFiniteStateMachine
    {
        void ChangeState(IState state);
    }
}
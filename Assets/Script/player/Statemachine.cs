public class Statemachine
{

    public playerState currentState;


    public void startAnim(playerState _playerState)
    {
        _playerState.Enter();
        currentState=_playerState;
    }

    public void changeAnim(playerState _playerState)
    {
        currentState.Exit();
        currentState=_playerState;
        currentState.Enter();
    }
}
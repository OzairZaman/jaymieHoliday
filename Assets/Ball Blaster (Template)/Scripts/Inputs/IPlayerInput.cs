namespace BallBlast
{
    public interface IPlayerInput
    {
        bool IsPointerDown();
        bool IsPointerUp();
        float GetTouchPointX();
        bool IsShooterPressed();
    }
}


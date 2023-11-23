namespace Assets.Scripts.Runtime
{
    public interface IController
    {
        void OnStart(); // The moment when the controller was created

        void OnStop(); // The moment when the controller was stopped

        void Tick(); // Update every frame
    }
}

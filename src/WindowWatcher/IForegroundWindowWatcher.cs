namespace WindowWatcher;

public interface IForegroundWindowWatcher
{
    event WindowChangedEventHandler? WindowChanged;

    bool IsRunning { get; }

    Window? CurrentForegroundWindow { get; }

    void Start();

    void Start(TimeSpan interval);

    void Start(int intervalMs);

    void Stop();
}
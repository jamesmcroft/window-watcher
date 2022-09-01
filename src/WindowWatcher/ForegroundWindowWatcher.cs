namespace WindowWatcher;

using MADE.Threading;

public class ForegroundWindowWatcher : IForegroundWindowWatcher
{
    private readonly Timer timer;

    public ForegroundWindowWatcher()
    {
        timer = new Timer();
        timer.Tick += OnTimerTick;
    }

    public event WindowChangedEventHandler? WindowChanged;

    public bool IsRunning => timer.IsRunning;

    public Window? CurrentForegroundWindow { get; private set; }

    public void Start()
    {
        Start(TimeSpan.FromMilliseconds(500));
    }

    public void Start(int intervalMs)
    {
        Start(TimeSpan.FromMilliseconds(intervalMs));
    }

    public void Start(TimeSpan interval)
    {
        timer.Interval = interval;
        timer.Start();
    }

    public void Stop()
    {
        timer.Stop();
    }

    private void OnTimerTick(object? sender, object e)
    {
        UpdateCurrentForegroundWindow();
    }

    private void UpdateCurrentForegroundWindow()
    {
        var currentForegroundWindow = WindowHelper.GetCurrentForegroundWindow();
        if (currentForegroundWindow == null || currentForegroundWindow.Equals(CurrentForegroundWindow)) return;

        CurrentForegroundWindow = currentForegroundWindow;
        WindowChanged?.Invoke(this, new WindowChangedEventArgs(currentForegroundWindow));
    }
}
namespace WindowWatcher;

using MADE.Threading;

/// <summary>
/// Defines a watcher for the state of the current foreground (active) window and raises events when it changes.
/// </summary>
public class ForegroundWindowWatcher : IForegroundWindowWatcher, IDisposable
{
    private readonly Timer timer;

    /// <summary>
    /// Initializes a new instance of the <see cref="ForegroundWindowWatcher"/> class.
    /// </summary>
    public ForegroundWindowWatcher()
    {
        timer = new Timer();
        timer.Tick += OnTimerTick;
    }

    /// <summary>
    /// Fired when the current foreground (active) window has changed.
    /// </summary>
    public event WindowChangedEventHandler? WindowChanged;

    /// <summary>
    /// Gets a value indicating whether the watcher is running and listening to window state changes.
    /// </summary>
    public bool IsRunning => timer.IsRunning;

    /// <summary>
    /// Gets the current foreground (active) window.
    /// </summary>
    public Window? CurrentForegroundWindow { get; private set; }

    /// <summary>
    /// Starts listening for changes in the current foreground (active) window.
    /// </summary>
    public void Start()
    {
        Start(TimeSpan.FromMilliseconds(500));
    }

    /// <summary>
    /// Starts listening for changes in the current foreground (active) window with a defined interval in milliseconds.
    /// </summary>
    /// <param name="intervalMs">
    /// The time between checks in milliseconds for the current foreground (active) window.
    /// </param>
    public void Start(int intervalMs)
    {
        Start(TimeSpan.FromMilliseconds(intervalMs));
    }

    /// <summary>
    /// Starts listening for changes in the current foreground (active) window with a defined interval.
    /// </summary>
    /// <param name="interval">
    /// The time between checks for the current foreground (active) window.
    /// </param>
    public void Start(TimeSpan interval)
    {
        timer.Interval = interval;
        timer.Start();
    }

    /// <summary>
    /// Stops listening for changes in the current foreground (active) window.
    /// </summary>
    public void Stop()
    {
        timer.Stop();
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes all the resources associated with the watcher.
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        this.timer.Tick -= this.OnTimerTick;
        this.timer.Dispose();
        this.WindowChanged = null;
    }

    private void OnTimerTick(object? sender, object e)
    {
        UpdateCurrentForegroundWindow();
    }

    private void UpdateCurrentForegroundWindow()
    {
        var currentForegroundWindow = WindowHelper.GetCurrentForegroundWindow();
        if (currentForegroundWindow == null || currentForegroundWindow.Equals(CurrentForegroundWindow))
        {
            return;
        }

        CurrentForegroundWindow = currentForegroundWindow;
        WindowChanged?.Invoke(this, new WindowChangedEventArgs(currentForegroundWindow));
    }
}
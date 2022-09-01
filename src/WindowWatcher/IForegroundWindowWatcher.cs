namespace WindowWatcher;

/// <summary>
/// Defines an interface for a service that watches the state of the current foreground (active) window and raises events when it changes.
/// </summary>
public interface IForegroundWindowWatcher
{
    /// <summary>
    /// Fired when the current foreground (active) window has changed.
    /// </summary>
    event WindowChangedEventHandler? WindowChanged;

    /// <summary>
    /// Gets a value indicating whether the watcher is running and listening to window state changes.
    /// </summary>
    bool IsRunning { get; }

    /// <summary>
    /// Gets the current foreground (active) window.
    /// </summary>
    Window? CurrentForegroundWindow { get; }

    /// <summary>
    /// Starts listening for changes in the current foreground (active) window.
    /// </summary>
    void Start();

    /// <summary>
    /// Starts listening for changes in the current foreground (active) window with a defined interval.
    /// </summary>
    /// <param name="interval">
    /// The time between checks for the current foreground (active) window.
    /// </param>
    void Start(TimeSpan interval);

    /// <summary>
    /// Starts listening for changes in the current foreground (active) window with a defined interval in milliseconds.
    /// </summary>
    /// <param name="intervalMs">
    /// The time between checks in milliseconds for the current foreground (active) window.
    /// </param>
    void Start(int intervalMs);

    /// <summary>
    /// Stops listening for changes in the current foreground (active) window.
    /// </summary>
    void Stop();
}
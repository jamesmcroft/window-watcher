namespace WindowWatcher;

/// <summary>
/// Defines the data that represents a window.
/// </summary>
public sealed class Window : IEquatable<Window>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Window"/> class with the handle to a window and the window title.
    /// </summary>
    /// <param name="handle">The handle to the window.</param>
    /// <param name="title">The title of the window.</param>
    public Window(IntPtr handle, string title)
    {
        Handle = handle;
        Title = title;
    }

    /// <summary>
    /// Gets an empty window model with a zero handle and empty title.
    /// </summary>
    public static Window Empty => new(IntPtr.Zero, string.Empty);

    /// <summary>
    /// Gets the handle to the window.
    /// </summary>
    public IntPtr Handle { get; }

    /// <summary>
    /// Gets the title of the window.
    /// </summary>
    public string Title { get; }

    /// <summary>Indicates whether the current <see cref="Window"/> is equal to another <see cref="Window"/>.</summary>
    /// <param name="other">A <see cref="Window"/> to compare with this <see cref="Window"/>.</param>
    /// <returns>
    /// <see langword="true" /> if the current <see cref="Window"/> is equal to the <paramref name="other" /> <see cref="Window"/>; otherwise, <see langword="false" />.
    /// </returns>
    public bool Equals(Window? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Handle.Equals(other.Handle) && Title == other.Title;
    }

    /// <summary>Determines whether the specified object is equal to the current <see cref="Window"/>.</summary>
    /// <param name="obj">The object to compare with the current <see cref="Window"/>.</param>
    /// <returns>
    /// <see langword="true" /> if the specified object is equal to the current <see cref="Window"/>; otherwise, <see langword="false" />.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((Window)obj);
    }

    /// <summary>Serves as the default hash function.</summary>
    /// <returns>A hash code for the current <see cref="Window"/>.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Handle, Title);
    }
}
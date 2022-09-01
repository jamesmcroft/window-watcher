namespace WindowWatcher;

public sealed class Window : IEquatable<Window>
{
    public Window(IntPtr handle, string title)
    {
        Handle = handle;
        Title = title;
    }

    public IntPtr Handle { get; }

    public string Title { get; }

    public static Window Empty => new(IntPtr.Zero, string.Empty);

    public bool Equals(Window? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Handle.Equals(other.Handle) && Title == other.Title;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Window)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Handle, Title);
    }
}
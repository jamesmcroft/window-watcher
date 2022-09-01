using WindowWatcher;

var windowWatcher = new ForegroundWindowWatcher();

windowWatcher.WindowChanged += (sender, args) =>
{
    Console.WriteLine($"Window changed to {args.NewWindow?.Title}");
};

windowWatcher.Start();

Console.ReadLine();

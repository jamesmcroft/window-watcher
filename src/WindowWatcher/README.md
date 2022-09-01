# Window Watcher SDK

[![GitHub release](https://img.shields.io/github/release/jamesmcroft/window-watcher.svg)](https://github.com/jamesmcroft/window-watcher/releases)
[![Build status](https://github.com/jamesmcroft/window-watcher/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/jamesmcroft/window-watcher/actions/workflows/ci.yml)
[![Twitter Followers](https://img.shields.io/twitter/follow/jamesmcroft?label=follow%20%40jamesmcroft&style=flat)](https://twitter.com/jamesmcroft)
[![SDK](https://img.shields.io/nuget/v/WindowWatcher?label=sdk)](https://www.nuget.org/packages/WindowWatcher/)

The Window Watcher SDK allows you to listen for changes to the current foreground (active) window on Windows devices. The SDK takes advantage of the `user32.dll` windowing APIs to get information about the current foreground (active) window on a device using P/Invoke.

## Getting started

### Get the SDK

If you want to build your own applications on the Window Watcher SDK, you can install the package into your dotnet application.

```bash
dotnet add package WindowWatcher
```

Or by adding the `WindowWatcher` package in your NuGet package manager of choice.

### Using the `ForegroundWindowWatcher`

The `ForegroundWindowWatcher` is a simple class that can be used to listen for changes in the current foreground (active) window on a Windows device providing a `Window` object with the window detail.

```csharp
using WindowWatcher;

var windowWatcher = new ForegroundWindowWatcher();

windowWatcher.WindowChanged += (sender, args) =>
{
    Console.WriteLine($"Window changed to {args.NewWindow?.Title}");
};

windowWatcher.Start();
```

**Note**, `ForegroundWindowWatcher` has an `IForegroundWindowWatcher` interface to ease the extensibility, testability, and support for dependency injection in your applications.

### Getting the current foreground (active) window with the `WindowHelper`

In addition to the watcher, the `WindowHelper` class has a `GetCurrentForegroundWindow` method that you can use to get a point-in-time reference to the current foreground (active) window.

```csharp
Window? currentWindow = WindowHelper.GetCurrentForegroundWindow();
```

## Contributing 🤝🏻

Contributions, issues and feature requests are welcome!

Feel free to check the [issues page](https://github.com/jamesmcroft/window-watcher/issues). You can also take a look at the [contributing guide](https://github.com/jamesmcroft/window-watcher/blob/main/CONTRIBUTING.md).

We actively encourage you to jump in and help with any issues, and if you find one, don't forget to log it!

## Support this project 💗

As many developers know, projects like this are built and maintained in maintainers' spare time. If you find this project useful, please **Star** the repo.

## Author

👤 **James Croft**

- Website: <https://www.jamescroft.co.uk>
- Twitter: [@jamesmcroft](https://twitter.com/jamesmcroft)
- Github: [@jamesmcroft](https://github.com/jamesmcroft)
- LinkedIn: [@jmcroft](https://linkedin.com/in/jmcroft)

## License

This project is made available under the terms and conditions of the [MIT license](LICENSE).

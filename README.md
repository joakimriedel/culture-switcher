# culture-switcher

Quick hack to be able to modify the current thread's culture in a using scope.

Useful for changing culture in background tasks since IStringLocalizer.WithCulture is marked as obsolete in .NET Core 3.0, and will be removed in .NET Core 5.0.

See https://github.com/dotnet/aspnetcore/issues/7756 for discussion.

## usage

```c#
// create a scope with a different culture and ui culture
using (new CultureSwitcher(new CultureInfo("sv-SE"), new CultureInfo("fi-FI")))
{
   // todo: do something in sv-SE culture and fi-FI ui culture
}
// note: the culture is now back to whatever it was before the using scope
```

See the tests for further usage.

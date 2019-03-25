# culture-switcher

Quick hack to be able to modify the current thread's culture in a using scope.

Good for changing culture in background tasks when IStringLocalizer.WithCulture is marked as obsolete in .NET Core 3.0.

## usage

```c#
using (new CultureSwitcher("sv-SE"))
{
   // todo: do something in sv-SE culture
}
// note: the culture is now back to whatever it was before the using scope
```


# RockLib.Threading

This library contains a single class: `RockLib.Threading.SoftLock`, which is an object that enables exclusive access to critical sections of code. Unlike a true lock, where a thread will block while another thread has the lock, a "soft lock" will cause a thread to skip over a critical section of code if another thread has the lock.

An example usage might be a timer that does some potentially long-running task, but we want to skip the task if it is already in progress.

```csharp
SoftLock _softLock = new SoftLock();

var timer = new System.Threading.Timer(_ =>
{
    if (_softLock.TryAcquire())
    {
        try
        {
            // Do long-running task
        }
        finally
        {
            _softLock.Release();
        }
    }
});

timer.Change(0, 1000);
```

If this example used a true lock, then threads could "pile up" at the lock while waiting for other threads to finish.

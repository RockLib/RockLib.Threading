# **RockLib.Threading Deprecation**

RockLib has been a cornerstone of our open source efforts here at Rocket Mortgage, and it's played a significant role in our journey to drive innovation and collaboration within our organization and the open source community. It's been amazing to witness the collective creativity and hard work that you all have poured into this project.

However, as technology relentlessly evolves, so must we. The decision to deprecate this library is rooted in our commitment to staying at the cutting edge of technological advancements. While this chapter is ending, it opens the door to exciting new opportunities on the horizon.

We want to express our heartfelt thanks to all the contributors and users who have been a part of this incredible journey. Your contributions, feedback, and enthusiasm have been invaluable, and we are genuinely grateful for your dedication. 🚀

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

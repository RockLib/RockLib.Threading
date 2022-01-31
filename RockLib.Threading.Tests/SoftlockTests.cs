using FluentAssertions;
using Xunit;

namespace RockLib.Threading.Tests
{
   public class SoftlockTests
   {
      [Fact(DisplayName = "TryAcquire method sets IsLockAckquired property to true")]
      public void TryAcquireTest1()
      {
         var softlock = new SoftLock();

         // Prove that the lock is not acquired initially
         softlock.IsLockAcquired.Should().BeFalse();

         // This will set the lock to true
         softlock.TryAcquire();

         softlock.IsLockAcquired.Should().BeTrue();
      }

      [Fact(DisplayName = "TryAcquire returns true when the lock is acquired")]
      public void TryAcquireTest2()
      {
         var softlock = new SoftLock();

         softlock.TryAcquire().Should().BeTrue();
      }

      [Fact(DisplayName = "TryAcquire returns false when the lock has already been acquired")]
      public void TryAcquireTest3()
      {
         var softlock = new SoftLock();

         softlock.TryAcquire();

         softlock.TryAcquire().Should().BeFalse();
      }

      [Fact(DisplayName = "Release method sets IsLockAcquired property back to false")]
      public void ReleaseTest()
      {
         var softlock = new SoftLock();

         softlock.TryAcquire();

         // prove it is locked
         softlock.IsLockAcquired.Should().BeTrue("If this failed we have issues in TryAcquire");

         softlock.Release();

         // verify it has been released
         softlock.IsLockAcquired.Should().BeFalse();
      }
   }
}

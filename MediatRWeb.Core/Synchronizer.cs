using System;
using System.Threading;

namespace MediatRWeb.Core
{
    public class Synchronizer<T, TRead, TWrite> where T : TWrite, TRead
    {
        private ReaderWriterLockSlim Lock { get; } 
        private T SharedObject { get; }

        public Synchronizer(T sharedObject)
        {
            Lock = new ReaderWriterLockSlim();
            SharedObject = sharedObject;
        }

        public void Read(Action<TRead> functor)
        {
            Lock.EnterReadLock();
            try
            {
                functor(SharedObject);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public void Write(Action<TWrite> functor)
        {
            Lock.EnterWriteLock();
            try
            {
                functor(SharedObject);
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
    }
}

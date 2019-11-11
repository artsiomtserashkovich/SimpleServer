﻿using System;
using System.Threading;
using System.Threading.Tasks;
using NetworkSocketServer.Network.TransportHandler;

namespace NetworkSocketServer.Network.ThreadSet
{
    internal class ThreadPoolThreadSet : IThreadSet
    {
        public ThreadPoolThreadSet(int threadNumbers)
        {
            if(threadNumbers < 1)
                throw new ArgumentException(nameof(threadNumbers));

            ThreadPool.SetMinThreads(1, 1);

            ThreadPool.SetMaxThreads(threadNumbers, threadNumbers);
        }

        public void Execute(Action<object> action)
        {
            ThreadPool.QueueUserWorkItem(action, null, true);
        }

        public void Execute(INetworkServiceHandler serviceHandler, Task<ITransportHandler> transportHandler)
        {
            throw new NotImplementedException();
        }
    }
}

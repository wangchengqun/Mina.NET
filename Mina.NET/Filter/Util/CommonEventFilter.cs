﻿using System;
using Mina.Core.Filterchain;
using Mina.Core.Session;
using Mina.Core.Write;

namespace Mina.Filter.Util
{
    /// <summary>
    /// Extend this class when you want to create a filter that
    /// wraps the same logic around all 9 IoEvents
    /// </summary>
    public abstract class CommonEventFilter : IoFilterAdapter
    {
        public override void SessionCreated(INextFilter nextFilter, IoSession session)
        {
            Filter(new IoFilterEvent(nextFilter, IoEventType.SessionCreated, session, null));
        }

        public override void SessionOpened(INextFilter nextFilter, IoSession session)
        {
            Filter(new IoFilterEvent(nextFilter, IoEventType.SessionOpened, session, null));
        }

        public override void SessionIdle(INextFilter nextFilter, IoSession session, IdleStatus status)
        {
            Filter(new IoFilterEvent(nextFilter, IoEventType.SessionIdle, session, status));
        }

        public override void SessionClosed(INextFilter nextFilter, IoSession session)
        {
            Filter(new IoFilterEvent(nextFilter, IoEventType.SessionClosed, session, null));
        }

        public override void ExceptionCaught(INextFilter nextFilter, IoSession session, Exception cause)
        {
            Filter(new IoFilterEvent(nextFilter, IoEventType.ExceptionCaught, session, cause));
        }

        public override void MessageReceived(INextFilter nextFilter, IoSession session, Object message)
        {
            Filter(new IoFilterEvent(nextFilter, IoEventType.MessageReceived, session, message));
        }

        public override void MessageSent(INextFilter nextFilter, IoSession session, IWriteRequest writeRequest)
        {
            Filter(new IoFilterEvent(nextFilter, IoEventType.MessageSent, session, writeRequest));
        }

        public override void FilterWrite(INextFilter nextFilter, IoSession session, IWriteRequest writeRequest)
        {
            Filter(new IoFilterEvent(nextFilter, IoEventType.Write, session, writeRequest));
        }

        public override void FilterClose(INextFilter nextFilter, IoSession session)
        {
            Filter(new IoFilterEvent(nextFilter, IoEventType.Close, session, null));
        }

        protected abstract void Filter(IoFilterEvent ioe);
    }
}

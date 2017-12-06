using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wu.Framework.Entity;

namespace Wu.Framework.Core
{
    public sealed class Logger
    {
        private ConcurrentQueue<Action> _queue; // 用于存放写日志任务的队列
        private Thread _loggingThread; // 用于写日志的线程
        private ManualResetEvent _hasNew;// 用于通知是否有新日志要写的“信号器”
        NLog.Logger logger;

        private Logger(NLog.Logger logger)
        {
            this.logger = logger;
            _queue = new ConcurrentQueue<Action>();
            _hasNew = new ManualResetEvent(false);
            //开启线程写日志
            _loggingThread = new Thread(Process);
            _loggingThread.IsBackground = true;
            _loggingThread.Start();
        }

        public static Logger Instance { get; private set; }

        static Logger()
        {
            Instance = new Logger(LogManager.GetCurrentClassLogger());
        }

        // 处理队列中的任务
        private void Process()
        {
            while (true)
            {
                _hasNew.WaitOne();// 等待接收信号，阻塞线程。
                _hasNew.Reset();// 接收到信号后，重置“信号器”，信号关闭。
                Thread.Sleep(100);// 由于队列中的任务可能在极速地增加，这里等待是为了一次能处理更多的任务，减少对队列的频繁“进出”操作。

                // 开始执行队列中的任务。
                // 由于执行过程中还可能会有新的任务，所以不能直接对原来的 _queue 进行操作，
                // 先将_queue中的任务复制一份后将其清空，然后对这份拷贝进行操作。
                ConcurrentQueue<Action> queueCopy;
                lock (_queue)
                {
                    queueCopy = new ConcurrentQueue<Action>(_queue);
                    while (_queue.TryDequeue(out Action action))
                    {

                    }
                    //怎么移除队列有问题
                }
                foreach (var action in queueCopy)
                {
                    action();
                }
            }
        }
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="log"></param>
        private void WriteLog(LogEventInfo log)
        {
            lock (_queue)
            {
                _queue.Enqueue(() => logger.Log(log));
            }
            _hasNew.Set();
        }

        public  void WriteLog(OperationLog nlog,Exception ex=null)
        {
            LogEventInfo log = new LogEventInfo();

            log.Properties["Operater"] = nlog?.Operater?.Id;
            log.Properties["OperationType"] = nlog?.OperationType;
            log.Properties["IP"] = nlog?.IP;
            log.Level = LevelCast(nlog?.Level);
            log.Message = nlog?.Message;
            if (ex != null) log.Exception = ex;
             Task.Run(() => WriteLog(log));
          
        }

        private LogLevel LevelCast(Enums.EnumManager.LogLevelEnum? level)
        {
            if (!level.HasValue) return LogLevel.Debug;
            switch (level)
            {
                case Enums.EnumManager.LogLevelEnum.TRACE:
                    return LogLevel.Trace;
                case Enums.EnumManager.LogLevelEnum.DEBUG:
                    return LogLevel.Debug;
                case Enums.EnumManager.LogLevelEnum.INFO:
                    return LogLevel.Info;
                case Enums.EnumManager.LogLevelEnum.WARN:
                    return LogLevel.Warn;
                case Enums.EnumManager.LogLevelEnum.ERROR:
                    return LogLevel.Error;
                case Enums.EnumManager.LogLevelEnum.FATAL:
                    return LogLevel.Fatal;
                case Enums.EnumManager.LogLevelEnum.OFF:
                default:
                    return LogLevel.Off;
            }

        }
    }

}

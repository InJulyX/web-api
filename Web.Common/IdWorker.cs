using System;

namespace Web.Common
{
    public class IdWorker
    {
        private static long workerId;

        /// <summary>
        /// 唯一时间，避免重复的随机量，不要大于当前时间戳
        /// </summary>
        private static long twepoch = 687888001020L;

        private static long sequence = 0L;

        /// <summary>
        /// 机器码字节数，4字节用于保存机器码
        /// </summary>
        private const int WorkerIdBits = 4;

        private const long MaxWorkerId = -1L ^ -1L << WorkerIdBits;
        private const int SequenceBits = 10;
        private const int WorkerIdShift = SequenceBits + WorkerIdBits;
        private const int TimestampLeftShift = SequenceBits + WorkerIdBits;
        private static readonly long SequenceMask = -1L ^ -1L << SequenceBits;
        private long _lastTimestamp = -1L;

        public IdWorker(long workerId)
        {
            if (workerId > MaxWorkerId || workerId < 0)
            {
                throw new Exception($"worker Id can't be greater than {workerId} or less than 0 ");
            }

            IdWorker.workerId = workerId;
        }

        public long GetId()
        {
            lock (this)
            {
                var timestamp = DateTimeHelper.GetCurrentTimestamp();
                if (this._lastTimestamp == timestamp)
                {
                    IdWorker.sequence = (IdWorker.sequence + 1) & IdWorker.SequenceMask;
                    if (IdWorker.sequence == 0)
                    {
                        timestamp = DateTimeHelper.GetNextMillis(timestamp);
                    }
                }
                else
                {
                    IdWorker.sequence = 0;
                }

                if (timestamp < _lastTimestamp)
                {
                    throw new Exception(
                        $"Clock moved backwards.  Refusing to generate id for {this._lastTimestamp - timestamp} milliseconds");
                }

                this._lastTimestamp = timestamp;
                var nextId = (timestamp - twepoch << TimestampLeftShift) |
                             IdWorker.workerId << IdWorker.WorkerIdShift | IdWorker.sequence;
                return nextId;
            }
        }
    }
}
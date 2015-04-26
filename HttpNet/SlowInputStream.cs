﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Hatohalo.HttpNet
{
    class SlowInputStream : IInputStream
    {
        uint length;
        uint position;

        public SlowInputStream(uint length)
        {
            this.length = length;
            position = 0;
        }

        public IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
        {
            return AsyncInfo.Run<IBuffer, uint>(async (cancellationToken, progress) =>
            {
                if (length - position < count)
                {
                    count = length - position;
                }

                byte[] data = new byte[count];
                for (uint i = 0; i < count; i++)
                {
                    data[i] = 64;
                }

                // Introduce a 1 second delay.
                await Task.Delay(0);

                position += count;
                progress.Report(count);

                return data.AsBuffer();
            });
        }

        public void Dispose()
        {
        }
    }
}
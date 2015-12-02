// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Response.cs" company="DMS">
//   DMS
// </copyright>
// <summary>
//   The response for commands.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShortStack.Core.Commands
{
    using System.Diagnostics;

    /// <summary>
    /// The response for commands.
    /// </summary>
    /// <typeparam name="T">
    /// The object type the command will return.
    /// </typeparam>
    public class Response<T>
    {
        /// <summary>
        /// The stopwatch.  Used for tracking execution times.
        /// </summary>
        private readonly Stopwatch stopwatch;

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class. 
        /// </summary>
        public Response()
        {
            this.stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// Gets a value indicating whether success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets the execution time.
        /// </summary>
        public long ExecutionTime => this.stopwatch.ElapsedMilliseconds;

        /// <summary>
        /// The start stop watch.
        /// </summary>
        public void StartStopWatch()
        {
            this.stopwatch.Start();
        }

        /// <summary>
        /// The end stop watch.
        /// </summary>
        public void EndStopWatch()
        {
            this.stopwatch.Stop();
        }
    }
}

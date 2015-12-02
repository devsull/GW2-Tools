// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseIntegrationTest.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The base integration test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShortStack.Core.Testing
{
    /// <summary>
    /// The base integration test.
    /// </summary>
    /// <typeparam name="T">
    /// The type of system to test.
    /// </typeparam>
    public abstract class BaseIntegrationTest<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIntegrationTest{T}"/> class.
        /// </summary>
        protected BaseIntegrationTest()
        {
            ShortStack.BootStack();
            this.SystemUnderTest = Locator.GetInstance<T>();
        }

        /// <summary>
        /// Gets the system under test.
        /// </summary>
        public T SystemUnderTest { get; }
    }
}
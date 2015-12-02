// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseCommand.cs" company="Devin">
//   Sullivan
// </copyright>
// <summary>
//   The base command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShortStack.Core.Commands
{
    using FluentValidation.Results;

    using global::ShortStack.Core.Validation;

    /// <summary>
    /// The base command.
    /// </summary>
    /// <typeparam name="TRequest">
    /// The type of request that the command uses.
    /// </typeparam>
    /// <typeparam name="TResponseType">
    /// The type of response the command returns.
    /// </typeparam>
    public abstract class BaseCommand<TRequest, TResponseType>
        where TRequest : Request
    {
        /// <summary>
        /// The validator.
        /// </summary>
        private readonly IValidateObjects<TRequest> validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCommand{TRequest,TResponseType}"/> class.
        /// </summary>
        /// <param name="validator">
        /// The validator.
        /// </param>
        protected BaseCommand(IValidateObjects<TRequest> validator)
        {
            this.validator = validator;
        }

        /// <summary>
        /// Gets the validation.
        /// </summary>
        public ValidationResult Validation { get; private set; }
        
        /// <summary>
        /// Gets the request.
        /// </summary>
        protected TRequest Request { get; private set; }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Response"/>.
        /// </returns>
        public Response<TResponseType> Execute(TRequest request)
        {
            this.Request = request;
            var response = new Response<TResponseType>();

            // start timing execution
            response.StartStopWatch();

            this.Validation = this.validator.Validate(this.Request);
            
            if (this.Validation.IsValid)
            {
                response.Result = this.HandleRequest();
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }

        /// <summary>
        /// The handle request, the bulk of what the implemented command does will be here.
        /// </summary>
        /// <returns>
        /// The <see cref="TResponseType"/>.
        /// </returns>
        protected abstract TResponseType HandleRequest();
    }
}
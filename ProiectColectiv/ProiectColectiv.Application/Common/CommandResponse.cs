using FluentValidation.Results;

namespace ProiectColectiv.Application.Common
{
    public class CommandResponse : BaseResponse
    {
        protected CommandResponse(params string[] errors) : base(errors) { }

        public CommandResponse(IList<ValidationFailure> errors) : base() => base.SetErrors(errors);

        public static CommandResponse Failed(IList<ValidationFailure> errors) => new(errors);

        public static CommandResponse Failed(params string[] errors) => new(errors);

        public static CommandResponse Ok() => new();
    }

    public class CommandResponse<T> : CommandResponse
    {
        public T Result { get; init; }

        protected internal CommandResponse(T result) => Result = result;

        protected CommandResponse(params string[] errors) : base(errors) => Result = default;

        public CommandResponse(IList<ValidationFailure> errors) : base(errors) { }

        public static CommandResponse<T> Ok<T>(T result) => new(result);

        public static new CommandResponse<T> Failed(IList<ValidationFailure> errors) => new(errors);

        public static CommandResponse<T> Failed(IDictionary<string, IList<string>> errors) => new() { Errors = errors };

        public static new CommandResponse<T> Failed(params string[] errors) => new(errors);
    }
}

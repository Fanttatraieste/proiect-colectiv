using FluentValidation.Results;
using ProiectColectiv.Common.Extensions;

namespace ProiectColectiv.Application.Common
{
    public abstract class BaseResponse
    {
        public IDictionary<string, IList<string>> Errors { get; set; } = new Dictionary<string, IList<string>>();

        public bool IsValid => Errors == null || !Errors.Any();

        protected BaseResponse(params string[] errors)
        {
            if (!errors.IsNullOrEmpty())
            {
                SetErrors(errors);
            }
        }

        public void AddError(string propertyName, string error)
        {
            EnsureEntry(propertyName);
            Errors[propertyName].Add(error);
        }

        public void AddError(string error) => AddError(string.Empty, error);

        public void SetErrors(string propertyName, IEnumerable<string> errors) => Errors[propertyName] = errors.ToList();

        public void SetErrors(IEnumerable<string> errors) => Errors[string.Empty] = errors.ToList();

        public void SetErrors(IList<ValidationFailure> errors)
        {
            foreach (ValidationFailure item in errors)
            {
                EnsureEntry(item.PropertyName);
                Errors[item.PropertyName].Add(item.ErrorMessage);
            }
        }

        private void EnsureEntry(string propertyName)
        {
            if (!Errors.ContainsKey(propertyName))
            {
                Errors.Add(propertyName, new List<string>());
            }
            else if (Errors[propertyName] == null)
            {
                Errors[propertyName] = new List<string>();
            }
        }
    }
}

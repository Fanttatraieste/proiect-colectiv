using System.Collections;

namespace ProiectColectiv.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty(this IEnumerable enumerable) => enumerable == null || !enumerable.GetEnumerator().MoveNext();
    }
}

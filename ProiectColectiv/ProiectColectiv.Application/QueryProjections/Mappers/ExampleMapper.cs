using ProiectColectiv.Domain.Entities;

namespace ProiectColectiv.Application.QueryProjections.Mappers
{
    public static class ExampleMapper
    {
        public static IQueryable<ExampleListItemModel> ProjectToDto(this IQueryable<Example> query) => 
            query.Select(example => new ExampleListItemModel
            {
                Id = example.Id,
                Name = example.Name,
                Gender = example.Gender
            });
    }
}

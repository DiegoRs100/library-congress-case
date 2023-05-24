using Library.Shelf.Domain.ValueTypes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace Library.Shelf.Infra.Databases.Converters;

public class LanguageConverter : ValueConverter<Language, string>
{
    public LanguageConverter() 
        : base(
            valueType => valueType.IsoCode,
            isoCode => (Language)isoCode) { }
}

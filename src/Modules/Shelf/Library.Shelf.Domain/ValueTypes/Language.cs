namespace Library.Shelf.Domain.ValueTypes;

public struct Language
{
    private string _isoCode;
    private string _region;

    public static readonly Language PT_BR = new("pt-br", "Português (Brasil)");
    public static readonly Language EN_US = new("en-us", "English (United States)");
    public static readonly Language Undefined = new("undefined", "Undefined");

    private Language(string isoCode, string region)
        => (_isoCode, _region) = (isoCode, region);

    public string IsoCode => _isoCode;
    public string Region => _region;

    public override string ToString()
        => _region;

    public static implicit operator Language(string isoCode) 
        => isoCode switch
        {
            { } when PT_BR == isoCode => PT_BR,
            { } when EN_US == isoCode => EN_US,
            _ => Undefined
        };

    public static bool operator ==(Language language, string value)
        => string.Equals(language.IsoCode, value.Trim(), StringComparison.OrdinalIgnoreCase) ||
           string.Equals(language.Region, value.Trim(), StringComparison.OrdinalIgnoreCase);

    public static bool operator !=(Language language, string value)
        => string.Equals(language.IsoCode, value.Trim(), StringComparison.OrdinalIgnoreCase) &&
           string.Equals(language.Region, value.Trim(), StringComparison.OrdinalIgnoreCase) is false;
}

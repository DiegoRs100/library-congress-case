﻿namespace Library.Integration.DataTransferObjects;

public static class Dto
{
    public record Location(string Session, int Hall, int Bookcase, int Shelf);

    public record Book(string Name, string Description, string Author, string Language, int Pages, DateOnly PublicationAt, string PublishingCompany);
}
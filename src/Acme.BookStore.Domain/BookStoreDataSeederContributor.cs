using System;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookStore;

public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;

    public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.GetCountAsync() <= 0)
        {
            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "1984",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.84f,
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1995, 9, 27),
                    Price = 42.0f,
                },
                autoSave: true
            );
            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "Brave New World",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1932, 8, 18),
                    Price = 15.99f,
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "Fahrenheit 451",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1953, 10, 19),
                    Price = 12.99f,
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "To Kill a Mockingbird",
                    Type = BookType.Fiction,
                    PublishDate = new DateTime(1960, 7, 11),
                    Price = 18.99f,
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "The Great Gatsby",
                    Type = BookType.Fiction,
                    PublishDate = new DateTime(1925, 4, 10),
                    Price = 10.99f,
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "Moby Dick",
                    Type = BookType.Fiction,
                    PublishDate = new DateTime(1851, 10, 18),
                    Price = 22.50f,
                },
                autoSave: true
            );
        }
    }
}

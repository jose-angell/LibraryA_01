using LibraryA_01.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryA_01.Infrastructure
{
    public class BookConfiguration: IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasColumnName("title").HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Author).HasColumnName("author").HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.ISBN).HasColumnName("isbn").HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Year).HasColumnName("year").HasColumnType("int").IsRequired();
            builder.Property(x => x.NumberOfPages).HasColumnName("number_of_pages").HasColumnType("int").IsRequired();
            builder.Property(x => x.Available).HasColumnName("available").HasColumnType("boolean").IsRequired();

            builder.HasIndex(x =>x.ISBN ).IsUnique();
        }
    }
}

using Coworking.DA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coworking.DA
{
    public class FileConverterResultsConfiguration : IEntityTypeConfiguration<FileConverterResult>
    {
        public void Configure(EntityTypeBuilder<FileConverterResult> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FloorId).HasColumnType("integer");
            builder.HasIndex(x => x.FloorId);
            builder.Property(x => x.FloorLayoutContent).HasColumnType("text");
            builder.Property(x => x.ContentType).HasColumnType("character varying(50)");
        }
    }
}

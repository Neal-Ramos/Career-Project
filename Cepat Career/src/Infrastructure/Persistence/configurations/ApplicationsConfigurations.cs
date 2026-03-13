using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.configurations
{
    public class ApplicationsConfigurations: IEntityTypeConfiguration<JobApplications>
    {
        public void Configure(EntityTypeBuilder<JobApplications> builder)
        {
            builder.ToTable("JobApplications");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;

namespace NLayerProject.Data.Seeds
{
    public class PersonSeed: IEntityTypeConfiguration<Person>
    {
   
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person {Id = 1, Name = "Burak", SurName = "YILDIZ"}
            );
        }
    }
}

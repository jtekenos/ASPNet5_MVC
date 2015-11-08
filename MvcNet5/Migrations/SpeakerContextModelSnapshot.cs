using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MvcNet5.Models;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace MvcNet5.Migrations
{
    [DbContext(typeof(SpeakerContext))]
    partial class SpeakerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7-15540")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

            modelBuilder.Entity("MvcNet5.Models.Speaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<string>("Blog");

                    b.Property<string>("Email")
                        .Annotation("MaxLength", 50);

                    b.Property<string>("FirstName")
                        .Required()
                        .Annotation("MaxLength", 40);

                    b.Property<string>("LastName")
                        .Required()
                        .Annotation("MaxLength", 40);

                    b.Property<string>("MobilePhone")
                        .Annotation("MaxLength", 15);

                    b.Property<string>("PhotoURL")
                        .Annotation("MaxLength", 200);

                    b.Property<string>("Specialization")
                        .Annotation("MaxLength", 40);

                    b.Property<string>("Twitter")
                        .Annotation("MaxLength", 15);

                    b.Key("SpeakerId");
                });
        }
    }
}

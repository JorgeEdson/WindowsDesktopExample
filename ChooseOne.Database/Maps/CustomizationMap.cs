using ChooseOne.Core.Domain.Entities;
using ChooseOne.Database.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.Database.Maps
{
    public class CustomizationMap : EntityMap<Customization>
    {
        public CustomizationMap() : base("Customizations")
        {
        }

        public override void Configure(EntityTypeBuilder<Customization> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ChooseComponent).HasColumnName("ChooseComponent").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();            
            builder.Property(x => x.Content).HasColumnName("Content");
            builder.Property(x => x.BackGroundColor).HasColumnName("BackGroundColor");
            builder.Property(x => x.ForeGroundColor).HasColumnName("ForeGroundColor");
            builder.Property(x => x.CornerRadius).HasColumnName("CornerRadius");
            builder.Property(x => x.MaxValue).HasColumnName("MaxValue");
            builder.Property(x => x.MinValue).HasColumnName("MinValue");
            builder.Property(x => x.FontSize).HasColumnName("TextSize");
            builder.Property(x => x.Height).HasColumnName("Height");
            builder.Property(x => x.Width).HasColumnName("Width");
            builder.Property(x => x.DialogButton1).HasColumnName("DialogButton1");
            builder.Property(x => x.DialogButton2).HasColumnName("DialogButton2");
            builder.Property(x => x.DialogButton3).HasColumnName("DialogButton3");
        }
    }
}

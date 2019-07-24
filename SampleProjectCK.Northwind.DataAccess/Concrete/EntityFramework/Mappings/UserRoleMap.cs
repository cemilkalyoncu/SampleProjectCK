using SampleProjectCK.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectCK.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap: EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            ToTable(@"Role", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.RoleId).HasColumnName("RoleId");
            Property(x => x.UserId).HasColumnName("UserId");

        }
    }
}

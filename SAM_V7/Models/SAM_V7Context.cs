using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SAM_V7.Models
{
    public class SAM_V7Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SAM_V7Context() : base("name=SAM_V7Context")
        {
        }

        public System.Data.Entity.DbSet<SAM_V7.Models.Approvers> Approvers { get; set; }

        public System.Data.Entity.DbSet<SAM_V7.Models.File> Files { get; set; }

        public System.Data.Entity.DbSet<SAM_V7.Models.Organizations> Organizations { get; set; }

        public System.Data.Entity.DbSet<SAM_V7.Models.Proposal> Proposals { get; set; }

        public System.Data.Entity.DbSet<SAM_V7.Models.Staff> Staffs { get; set; }

        public System.Data.Entity.DbSet<SAM_V7.Models.Users> Users { get; set; }
    }
}

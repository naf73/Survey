using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model
{
    public partial class SurveyContext : DbContext
    {
        public SurveyContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
    }
}

using EFCorePro.Data;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EFCorePro.ValueGenerators
{
    public class IDValueGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            var context = (ApplicationDbContext)entry.Context;
            var id = context.TodoItem.LastOrDefault()?.Id == null ?
                    "A001"
                    : Regex.Replace(context.TodoItem.LastOrDefault()?.Id, "\\d+", m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
            return id;
        }
    }
}

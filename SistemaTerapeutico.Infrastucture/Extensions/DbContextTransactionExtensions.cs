using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Extensions
{
    public static class DbContextTransactionExtensions
    {
        public static void BeginTransaction(
            this DbContext context)
        {
            context.Database.BeginTransaction();
        }

        public static void CommitTransaction(
            this DbContext context)
        {
            context.Database.CommitTransaction();
        }

        public static void RollbackTransaction(
            this DbContext context)
        {
            context.Database.RollbackTransaction();
        }
    }
}

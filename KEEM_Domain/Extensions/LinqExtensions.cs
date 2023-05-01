using KEEM_Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Domain.Extensions
{
    public delegate int Checker<T>(T element);

    public static class LinqExtensions
    {
        public static int AnyReturnInt<T>(this List<T> elements, Checker<T> checker)
        {
            foreach (var e in elements)
            {
                return checker(e);
            }

            return -1;
        }

    }
}

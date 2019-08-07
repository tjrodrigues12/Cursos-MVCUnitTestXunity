using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest._Util
{
   public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException exception, string message)
        {
            if (exception.Message == message)
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem {message}");
        }
    }
}

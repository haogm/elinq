﻿using System;
using System.Linq.Expressions;

namespace NLite.Data.Dialect.Function.MySQL
{
    class PadRightFunctionView : IFunctionView
    {
        public void Render(ISqlBuilder builder, params Expression[] args)
        {
            if (args == null)
                throw new NotSupportedException("args");
            if (args.Length != 2 && args.Length != 3)
                throw new NotSupportedException(string.Format(Res.ArgumentCountError, "PadRight", "", "2 or 3"));
            builder.Append("RPAD(");
            builder.Visit(args[0]);
            builder.Append(",");
            builder.Visit(args[1]);
            builder.Append(",");
            if (args.Length == 2)
                builder.Append("' ')");
            else
            {
                builder.Visit(args[2]);
                builder.Append(")");
            }
        }
    }
}

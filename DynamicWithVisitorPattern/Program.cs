using System;
using System.Text;

namespace DynamicWithVisitorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Expression e = new Addition(
                new Addition(
                    new Literal(1),
                    new Addition(new Literal(5), new Literal(6))
                    ),
                new Literal(3)
                );

            var sb = new StringBuilder();
            ExpressionPrinter.Print((dynamic)e, sb);
            Console.WriteLine(sb);
        }
    }

    public abstract class Expression
    {
    }

    public class Literal : Expression
    {
        public Literal(double value)
        {
            Value = value;
        }

        public double Value { get; set; }
    }

    public class Addition : Expression
    {
        public Addition(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public Expression Left { get; set; }
        public Expression Right { get; set; }
    }

    public class ExpressionPrinter
    {
        public static void Print(Literal literal, StringBuilder sb)
        {
            sb.Append(literal.Value);
        }

        public static void Print(Addition addition, StringBuilder sb)
        {
            sb.Append('(');
            Print((dynamic)addition.Left, sb);
            sb.Append('+');
            Print((dynamic)addition.Right, sb);
            sb.Append(')');
        }
    }
}

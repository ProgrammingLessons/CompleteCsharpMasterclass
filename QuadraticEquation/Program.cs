using System;
using System.Numerics;

namespace QuadraticEquation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(12, 6);
            Console.WriteLine(c1);

            var solver = new QuadraticEquationSolver();
            Tuple<Complex, Complex> solution;
            // The result value is assigned to the variable given with the parameter with the word out.
            var flag = solver.Start(1, 10, 16, out solution);
            if (flag == WorkflowResult.Success)
            {
                // What is wanted to be done in the code flow is done.
            }
        }
    }

    public enum WorkflowResult
    {
        Success, Failure
    }

    public class QuadraticEquationSolver
    {
        // axA2+bx+c
        public WorkflowResult Start(double a, double b, double c, out Tuple<Complex, Complex> result)
        {
            // The values given with the parameter apply the zero rule.
            var disc = b * b - 4 * a * c;
            // According to the zero rule, if the result is less than zero, an error enum is sent back.
            if (disc < 0)
            {
                result = null;
                return WorkflowResult.Failure;
            }
            else
            {
                // Values are given to the method that will perform the mathematical operation.
                return SolveSimple(a, b, disc, out result);
            }

        }

        private WorkflowResult SolveSimple(double a, double b, double disc, out Tuple<Complex, Complex> result)
        {

            var rootDisc = Math.Sqrt(disc); //The square root operation is done.
            result = Tuple.Create(
               new Complex((-b + rootDisc) / (2 * a), 0),
               new Complex((-b - rootDisc) / (2 * a), 0)
            );
            return WorkflowResult.Success;
        }
    }
}

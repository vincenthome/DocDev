using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static ConsoleApp.StaticUtility;

namespace ConsoleApp
{

    public class UserDemo
    {
        private string firstName = "Vincent";
        private string lastName = "Leung";

        // Auto-Implemented Property Initializer. 
        // Before: initialization done inside ctor
        public string AutoPropertyInlineInitializer { get; set; } = "Auto Property 'Initialize Inline'";
        // Get-only Auto-Implemented Property
        // Before: Need BOTH get; and set; at the same time!
        public string AutoGetonlyProperty { get; } = "Get-only '{ get; }' Auto-Implemented Property";

        // Property - get only accessor using lambda expression
        //Before: public string MyProperty { get { return firstName + " " + lastName; } }
        public string OnelineLamdaExpProperty => firstName + " " + lastName;

        // 1 line function using lambda expression
        public string OnelineLamdaExpFunction() => firstName + " " + lastName;
        public string OnelineLamdaExpFunctionWithParam(string greeting) => greeting + " " + firstName + " " + lastName;

        // Before: string.Format("{0} {1}", firstName, lastName)
        public string StringInterpolation => $"{firstName} {lastName} ";

        // allowing you to set values to keys through any indexer that the new object has.
        // Before: {
        //  {100, "itemA"},
        //  {101, "itemB"},
        //  {102, "itemC"}
        //};
        public Dictionary<int, string> intStringDictionary = new Dictionary<int, string>() {
            [100] = "itemA",
            [101] = "itemB",
            [102] = "itemC",
            [1000] = "",
            [1001] = null
        };

        public string ExceptionFilter()
        {
            try
            {
                Random rnd = new Random();
                int broken = rnd.Next(3);
                if (broken != 0)
                    throw new MyException("Something Wrong!") { Severity = broken };
            }
            catch (MyException ex) when (ex.Severity == 1)
            {
                return "Broken! Fix it when you have time";
            }
            catch (MyException ex) when (ex.Severity == 2)
            {
                return "Broken! FIX IT NOW!!!";
            }

            return "Success";
        }

        public string NullConditionalOperator(Dictionary<int, string> d, int index)
        {
            string result = string.Empty;
            // Think fluent functional programming
            int? countNull = d?.Count(); // if d is null returns null, else call Count method
            if(countNull == null)
                result += "countNull is null, ";
            else
                result += $"countNull value {countNull}, ";

            int count = d?.Count() ?? 0; // if d is null ?? returns 0, else call Count method
            result += $"count value {count}, ";

            if (count == 0)
                return result;

            // ALWAYS convert to Empty String even it is null
            // if d is null returns empty string, if d[index] is null returns empty string, else returns d[index] value string
            string valEmptyString = d?[index] ?? ""; 
            if (valEmptyString == null)
                result += "valEmptyString is null. SHOULD NEVER REACH HERE, ";
            else
                result += $"valEmptyString value {valEmptyString}, ";

            // Null OR Empty String
            // if d is null returns null, if d[index] is null returns null, else returns d[index] value string
            string valNull = d?[index]; 
            if (valNull == null)
                result += "valNull is null, ";
            else
                result += $"valNull value {valNull}, ";

            return result;
        }

        public string nameofExpression(UserDemo user)
        {
            return $"'nameof(user.firstName)' returns: {nameof(user.firstName)}";
        }

        public async Task<string> AwaitInCatchFinally(bool throwException)
        {
            StreamWriter writer = null;
            string filename = "logerror.txt";
            try
            {                
                writer = File.CreateText(filename);
                if (throwException)
                    throw new MyException("Let's throw a MyException here!");
            }
            catch (MyException e)
            {
                if(writer != null)
                    // await is now available inside catch and finally
                    await writer.WriteAsync($"Log Exception to {filename} : {e.Message}");
            }
            finally
            {
                if(writer != null)
                    // await is now available inside catch and finally
                    await writer.FlushAsync();
            }

            if (throwException)
                return $"A MyException is thrown and a logfile {filename} is created.";
            else
                return "Success";
        }
    }

    public static class StaticUtility
    {
        public static string StaticFunction()
        {
            return "Static Function Called";
        }

        public static string staticAutoProperty { get; set; } = "Static Auto Property Accessed";
    }

    public class MyException : Exception
    {
        public int Severity { get; set; } = 0;

        public MyException(string message) : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserDemo user = new UserDemo();

            WriteLine($"Import Static - 'using static namespace.classname;': {StaticFunction()}, {staticAutoProperty} ");
            WriteLine($"String Interpolation: {user.StringInterpolation}");
            WriteLine($"AutoProperty Inline Initializer: {user.AutoPropertyInlineInitializer}");
            WriteLine($"AutoGetOnlyProperty: {user.AutoGetonlyProperty}");
            WriteLine($"OnelineLamdaExpProperty: {user.OnelineLamdaExpProperty}");
            WriteLine($"OnelineLamdaExpFunction: {user.OnelineLamdaExpFunction()}");
            WriteLine($"OnelineLamdaExpFunctionWithParam: {user.OnelineLamdaExpFunctionWithParam("Dear")}");
            WriteLine($"NullConditionalOperator outmost null: {user.NullConditionalOperator(null, 0)}");
            WriteLine($"NullConditionalOperator 0 count: {user.NullConditionalOperator(new Dictionary<int, string>(), 1)}");
            WriteLine($"NullConditionalOperator value empty string: {user.NullConditionalOperator(user.intStringDictionary, 1000)}");
            WriteLine($"NullConditionalOperator value null: {user.NullConditionalOperator(user.intStringDictionary, 1001)}");
            WriteLine($"NullConditionalOperator value string: {user.NullConditionalOperator(user.intStringDictionary, 100)}");
            WriteLine($"Index Initializer: " + user.intStringDictionary.Aggregate("", (keyString, pair) => $"{keyString}[{pair.Key}]='{pair.Value}' "));
            WriteLine($"nameof(): {user.nameofExpression(new UserDemo())}");
            WriteLine($"Exception Filter: {user.ExceptionFilter()}");
            Task<string> t = user.AwaitInCatchFinally(true);
            t.Wait();
            WriteLine($"Await In Catch Finally: {t.Result}");

            // Question:
            // Exception Filters using when or if???

        }

        
    }
}

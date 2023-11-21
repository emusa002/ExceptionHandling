namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicExceptionHandling();
            MultipleExceptionTypes();
            FinalyBlockUsage();
            CustomExceptionClass();
            ExceptionPropagation();
            UsingThrowAndCatch();
        }

        static void BasicExceptionHandling()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Convert the input to an integer using int.Parse().
            // Use a try-catch block to handle FormatException if the user enters a non-numeric value.
            // Display an error message in case of an exception.
            // Output the input if correct

            try
            {
                int inputNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Input Number is {inputNumber}");
            } catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            } 
        }

        static void MultipleExceptionTypes()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Include a catch block for OverflowException to handle cases where the number is too large or small for an int.
            // Display appropriate error messages for different exceptions.
            try
            {
                int inputNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Input Number is {inputNumber}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid Format. The input is not an int. Exception was : {e.Message}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Overflow Exception: Exception Details {e.Message}");
            }
        }

        static void FinalyBlockUsage()
        {
            Console.Write("Enter a number: ");
            bool exceptionThrown = false;
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Add a finally block to the program.
            // Use the finally block to display a message whether an exception was caught or not.

            try
            {
                int inputNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Input Number is {inputNumber}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                exceptionThrown = true;
            } finally
            {
                if (exceptionThrown)
                {
                    Console.WriteLine("The Exception was caught");
                } else
                {
                    Console.WriteLine("No exception thrown");
                }

            }
        }

        // Class for custom exception type
        class NegativeNumberException : ApplicationException
        {
            public NegativeNumberException(string message) : base(message) { }
        }

        static void CustomExceptionClass()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Modify your number input program to throw NegativeNumberException if the user enters a negative number.
            // Handle this exception in a separate catch block and display an appropriate message.

            try
            {
                int inputNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Input Number is {inputNumber}");

                if (inputNumber < 0)
                {
                    throw new NegativeNumberException($"{inputNumber} is a negative number");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            } catch (NegativeNumberException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        static void ExceptionPropagation()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumber that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // In this function, call CheckNumber inside a try block and handle the exception.

            try
            {
                int inputNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Input Number is {inputNumber}");

                CheckNumber( inputNumber );
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            } catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }
        }

        // NOTE: You can implement the CheckNumber here
        static bool CheckNumber(int number)
        {
            if (number > 100)
            {
                throw new ArgumentOutOfRangeException($"{number} is greater than 100");
            }

            return true;
        }

        static void UsingThrowAndCatch()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumberWithLogging that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // Modify the CheckNumberWithLogging function to log the exception message before throwing it.
            // In this function, catch the exception in the main program and display the logged message.

            try
            {
                int inputNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Input Number is {inputNumber}");

                CheckNumberWithLogging( inputNumber );

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            } catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e + Environment.NewLine + e.StackTrace);
            }
        }

        // NOTE: You can implement the CheckNumberWithLogging here

        static void CheckNumberWithLogging(int number)
        {

            try
            {
                if (number > 100)
                {
                    throw new ArgumentOutOfRangeException($"{number} is greater than 100");

                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }
    }
}
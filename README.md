# C# vs .NET
- C# is a programming language
- .NET is a framework that provides a runtime environment and libraries for building and running applications. C# is one of the primary languages used to develop applications on the .NET platform. In summary, C# is a language, and .NET is a framework that supports multiple languages, including C#.

# .NET
- CLR (Common Language Runtime)
	- A runtime application that traslate IL CODE (Intermediate Language) to machine code and execute it. 
	-  JIT (Just In Time) compiler: A component of the CLR that compiles IL code into machine code at runtime, allowing for platform independence and optimization.
- Class Library

# C# Basics concepts
- Namespace: A way to organize code and prevent naming conflicts by grouping related classes, interfaces, and other types together.
- Assembly: A compiled code (DLL OR EXE) library used for deployment, versioning, and security in .NET applications. It can contain one or more namespaces and types. 
-  Variables: they are defined camelCase, and they are used to store data and the constants are defined in PascalCase.
- Primitives types: byte - Byte en .NET (numeric from 0 to 255), short Int16 en .NET  (numeric from -32,768 to 32,767), int Int32 en .NET (numeric from -2.1B to 2.1B), long Int64 en .NET (numeric from -9.2Q to 9.2Q), float Single en .NET (numeric with 7 digits of precision), double Double en .NET (numeric with 15-16 digits of precision), decimal Decimal en .NET (numeric with 28-29 digits of precision, used for financial calculations), char Char en .NET (a single Unicode character), bool Boolean en .NET (true or false). 
	- double is the default type for floating-point literals, so when asigning a floating-point number to a variable, it is treated as a double unless specified otherwise (e.g., using the 'f' suffix for float). for example: float myFloat = 3.14f; // 'f' suffix indicates a float literal.
	- if you want to use a decimal literal, you can use the 'm' suffix to indicate that it is a decimal value. for example: decimal myDecimal = 3.14m; // 'm' suffix indicates a decimal literal.
	- Overflowing : When a value exceeds the maximum or minimum limit of a data type, it can cause an overflow. In C#, you can use the 'checked' keyword to enable overflow checking, which will throw an exception if an overflow occurs. For example:  byte myByte = 255; // Maximum value for byte  myByte++; // This will cause an overflow  checked { myByte++; } // This will throw an OverflowException.
	- correct way to use checked:   // Maximum value for byte  checked { byte myByte = 255; myByte++; } // This will throw an OverflowException.
-  Template consoleWriteLine: Console.WriteLine("{0} {1}",15,30); // Output: 15 30 es una forma de formatear la salida, donde {0} se reemplaza por el primer argumento (15) y {1} se reemplaza por el segundo argumento (30).
- Implicit conversion: When a value of one data type is automatically converted to another data type without explicit casting. For example: int myInt = 10; double myDouble = myInt; // Implicit conversion from int to double.
- explicit conversion (casting): When you manually convert a value from one data type to another using a cast operator. For example: double myDouble = 3.14; int myInt = (int)myDouble; // Explicit conversion from double to int, resulting in 3, this is necessary because converting from a larger data type (double) to a smaller data type (int) can lead to data loss, so you need to explicitly indicate that you want to perform the conversion.
- Non compatible conversions: When you try to convert between incompatible data types, it can lead to a compile-time error. For example: string myString = "Hello"; int myInt = (int)myString; // This will cause a compile-time error because string cannot be directly converted to int.
	- but you can use the Convert class to perform conversions between compatible types. For example: string myString = "123"; int myInt = Convert.ToInt32(myString); // This will convert the string "123" to the integer 123. or you can use int.Parse() method: string myString = "123"; int myInt = int.Parse(myString); // This will also convert the string "123" to the integer 123.
	Convert can me use with the following methods: ToByte(), ToInt16(), ToInt32(), ToInt64(), ToSingle(), ToDouble(), ToDecimal(), ToChar(), ToBoolean(), etc.
- Operators: Arithmetic operators (+, -, *, /, %), Comparison operators (==, !=, >, <, >=, <=), Logical operators (&&, ||, !), Assignment operators (=, +=, -=, *=, /=, %=), Increment and Decrement operators (++, --).
post-increment: int x = 5; int y = x++; // y will be 5, and x will be 6 after this line is executed.
- pre-increment: int x = 5; int y = ++x; // y will be 6, and x will also be 6 after this line is executed.
- Access Modifiers, are used to control the visibility and accessibility of classes, methods, and other members in C#. The main access modifiers are:
	- public: The member is accessible from any code in the same assembly or another assembly that references it.
	- private: The member is accessible only within the body of the class or struct in which it is declared.
	- protected: The member is accessible within its class and by derived class instances.
	- internal: The member is accessible only within files in the same assembly.
	- protected internal: The member is accessible within its class, by derived class instances, and within the same assembly.
- Generics: A feature that allows you to define classes, methods, and data structures with a placeholder for the type of data they store or use. This promotes code reusability and type safety. For example: public class GenericList<T> { private T[] items; public void Add(T item) { // Implementation to add item to the list } }
# Events and Delegates
## Events
Are a mechanism for a class to notify other classes or objects when something of interest occurs. They are based on the observer design pattern and are commonly used in GUI programming, but can be used in any scenario where you want to implement a publish-subscribe model. An event is typically associated with a delegate, which defines the signature of the method that will handle the event.
used in buiding loosely coupled applications, where the publisher of the event does not need to know about the subscribers, and vice versa. This promotes separation of concerns and makes it easier to maintain and extend the application.
## Delegates
Is an Agreement / Contract between Publisher an Subscriber, it is a type that represents references to methods with a particular parameter list and return type. Delegates are used to define the signature of the method that will handle an event. They can be thought of as function pointers in C#, allowing you to pass methods as parameters, store them in variables, and invoke them dynamically at runtime. Delegates are commonly used in event handling, callbacks, and implementing the observer pattern in C#.
**Example**

<pre>
public class Video
{
    public string Title { get; set; }
}

public class VideoEncoder
{
    // 1- Define a delegate
    public delegate void VideoEncodedEventHandler(object source, EventArgs args);

    // 2- Define an event based on that delegate
    public event VideoEncodedEventHandler VideoEncoded;

    public void Encode(Video video)
    {
        Console.WriteLine("Encoding Video...");
        Thread.Sleep(3000);

        // 3- Raise the event
        OnVideoEncoded();
    }

    protected virtual void OnVideoEncoded()
    {
        if (VideoEncoded != null)
            VideoEncoded(this, EventArgs.Empty);
    }
}
<pre>
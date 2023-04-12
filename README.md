# What is this project?

In this repo, sample codes were written as a result of the examples followed in the training and the researches.

# Polymorphism
For the subject of polymorphism, an example car class and the classes derived from them have been created. 
https://github.com/ProgrammingLessons/CompleteCsharpMasterclass/tree/main/PolymorphicParameters

References for polymorphism
* https://www.tutorialspoint.com/csharp/csharp_polymorphism.htm
* https://www.youtube.com/watch?v=xUadTirOJeU


# Event Handler & Delegate
Classes that handle publisher and subscriber operations like message brokers have been created. There is an example of capturing this message from the subscriber class after the message is broadcast from the broadcaster class.

* The code at https://gist.github.com/GorvGoyl/56e5ff46731d0861a173 has been reviewed.

Another different example: https://gist.github.com/danhakin/f02b05c4764073727d20


# WPF
It has received the exchange rate information at http://www.tcmb.gov.tr/kurlar/today.xml and displayed it in the wpf project.
https://github.com/ProgrammingLessons/CompleteCsharpMasterclass/tree/main/Currency

Sample Code : https://github.com/selenaysolmaz/dovizXMLex
https://www.tutorialspoint.com/wpf/index.htm has been reviewed.


# Thread
A structure has been made that allows two threads to communicate with each other.
https://github.com/ProgrammingLessons/CompleteCsharpMasterclass/tree/main/ThreadExamp

* https://www.c-sharpcorner.com/article/Threads-in-CSharp/
* https://medium.com/caglargul-blog/c-net-sinyal-yap%C4%B1lar%C4%B1-1a81fc6d3cc3
* https://github.com/shawnmullings/threading/blob/master/Threading/Program.cs


# ExpandoObject
With C# 4.0, a new feature has been added with dynamic innovations. We can add fields or methods at runtime and use them.
Example 1: https://github.com/ProgrammingLessons/CompleteCsharpMasterclass/tree/main/ExpandoObjectExam1
Example 2: https://github.com/ProgrammingLessons/CompleteCsharpMasterclass/tree/main/DynamicWithVisitorPattern

* https://www.ilkayilknur.com/expando-object-icerisine-dinamik-olarak-member-ekleme
* https://www.gencayyildiz.com/blog/c-expandoobject-ile-dinamik-nesne-olusturma/


# ExtensionMethods
Extension methods are helper methods.
https://github.com/ProgrammingLessons/CompleteCsharpMasterclass/tree/main/ExtensionMethodsExam

* https://github.com/adessoTurkey-dotNET/LINQExtension


# Assorted Topics
An example is made that allows the object to be removed from memory after its use is over.
https://github.com/ProgrammingLessons/CompleteCsharpMasterclass/tree/main/DisposableTopic

A mathematical code writing example has been made.
https://github.com/ProgrammingLessons/CompleteCsharpMasterclass/tree/main/QuadraticEquation

# Debugging
I learned how to debug remote server while debugging. We learned that it is possible to work with remote debugging of the codes on the remote server, and in this way, problems such as file path problems, reading and writing to the file can be examined with this method.

https://bhdryrdm.blogspot.com/2016/09/remote-debugging-nedir-ve-nasl-uygulanr.html
http://www.sinanbozkus.com/visual-studio-ile-remote-debugging-nasil-yapilir/
https://www.youtube.com/watch?v=Eod7mC2W5VA

# Loops
In different loops such as for, foreach, while, do-while, which one is faster is a matter of curiosity. As a result of my research, how we use it is more important than which loop we should use. In the tests shared on the source sites, foreach is faster, in another test, for is faster, and in another test, while is faster.
How we use the loop is important.
What can be done to speed up the cycle;
* Not unboxing and unboxing in the loop.
* Not doing database operations in the loop as much as possible. Before the loop, it is necessary to pull the data from the database and process this data in the loop.
* Get the number of elements of the list before the loop. It is necessary to specify so that as many loops can run as this number.
![image](https://user-images.githubusercontent.com/29948990/231398210-829a1c88-ecff-4e80-8474-82152215782a.png)

Operations like this will speed up our operations regardless of the cycle we use.
<hr>

I benefited from different resources during my udemy training.
My most used resource
* https://www.gencayyildiz.com/blog/
* https://www.c-sharpcorner.com/
* https://www.tutorialspoint.com
* https://www.geeksforgeeks.org/
* https://medium.com/

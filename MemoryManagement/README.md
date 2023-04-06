# Memory Management
The use of ref, in is important for memory management and speed. Performance can be improved by sending the reference address of the variable in the method.
I added and applied the benchmark made by Albert myself.

https://github.com/albertherd/csharpmopt2-in
https://albertherd.com/2019/06/26/c-micro-optimizations-part-2-in-arguments/
https://www.c-sharpcorner.com/article/c-sharp-7-2-in-parameter-and-performance/


Span, ReadOnlySpan, Memory, Stackalloc, AsSpan
types increase performance as they use the stack region of memory.

It's also a topic that has been discussed on StackOverFlow. What can be done to better use memory management.
As long as it is not possible to increase the use of Dispose, it is necessary to keep the use of static low.

https://code-maze.com/csharp-span-to-improve-application-performance/
https://www.borakasmer.com/net-coreda-span/
https://www.ilkayilknur.com/net-coreda-span-ve-memory-tipleri
https://medium.com/c-programming/c-memory-management-part-1-c03741c24e4b
https://stackoverflow.com/questions/21046409/best-practices-to-optimize-memory-in-c-sharp

StackOverFlow üzerinde de konuşulmuş bir konudur. Bellek yönetimini daha iyi kullabilmek için neler yapılabiir.
Dispose kullanımını artırıp mümkün olmadığı sürece static kullanımını az tutmak gerekiyor.
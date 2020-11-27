
using System;

namespace Ejer_39
{
class Class1
{
private ReaderWriterLock rwl = new ReaderWriterLock();
private long myNumber;
public long Number   // the Number property
{
get
{
//Acquire a read lock on the resource.
rwl.AcquireReaderLock(Timeout.Infinite);                
try
{
Console.WriteLine("Thread:{0} starts getting the Number", Thread.CurrentThread.GetHashCode());
Thread.Sleep(50);
Console.WriteLine("Thread:{0} got the Number", Thread.CurrentThread.GetHashCode());

}
finally
{
//Release the lock.
rwl.ReleaseReaderLock();
}
return myNumber;
}
set
{
//Acquire a write lock on the resource.
rwl.AcquireWriterLock(Timeout.Infinite);
try
{
Console.WriteLine("Thread: {0} start writing the Number", Thread.CurrentThread.GetHashCode());
Thread.Sleep(50);
myNumber = value;
Console.WriteLine("Thread: {0} written the Number", Thread.CurrentThread.GetHashCode());
}
finally
{
//Release the lock.
rwl.ReleaseWriterLock();
}
}
}

[STAThread]
static void Main(string[] args)
{
Thread []threadArray = new Thread[20]; 
int threadNum;


Class1 Myclass = new Class1();
ThreadStart myThreadStart = new ThreadStart(Myclass.AccessGlobalResource);

//Create 20 threads.
for( threadNum = 0; threadNum < 20; threadNum++)
{
threadArray[threadNum] = new Thread(myThreadStart);
}

//Start the threads.
for( threadNum = 0; threadNum < 20; threadNum++)
{   
threadArray[threadNum].Start();
}

//Wait until all the thread spawn out finish.
for( threadNum = 0; threadNum < 20; threadNum++)
threadArray[threadNum].Join();

Console.WriteLine("All operations have completed. Press enter to exit");
Console.ReadLine();
}

public void AccessGlobalResource()
{
Random rnd = new Random();
long theNumber;

if (rnd.Next() % 2 != 0)
theNumber = Number;
else
{
theNumber = rnd.Next();
Number = theNumber;
}

}
}
}
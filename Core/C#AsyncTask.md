#Concurrency & Async

##Create new thread and pass data

Lambda expression can capture variable in the outer scope.  But you must be careful about modifying the variable AFTER the thread started because thread will use the latest value at runtime.

```csharp
int i = 1;
new Thread (() =>
{
Console.WriteLine ($"I'm running on another thread {i}!");
Console.WriteLine ("This is so easy!");
}).Start();
```

By default, threads you create explicitly are foreground threads. Once all foreground threads finish, the application ends, and any background threads still running abruptly terminate

##ThreadPool - background threads

```
Task.Run (() => Console.WriteLine ("Hello from the thread pool"));
```

######p.s. ThreadPool.QueueUserWorkItem obsolete

##Task

Task vs Thread. 

 1. Thread has no easy way to **return value** except using shared state which has to be synchronized to ensure thread-safe.
 2.  Thread has no easy way to **compose results** of multiple threads


A Task is a higher-level abstraction—it represents a concurrent operation that **may or may not be backed by a thread**. Tasks are compositional. They can **use the thread pool** to lessen startup latency in **CPU-bound** operation, and with a **TaskCompletionSource**, they can leverage a callback approach that **avoid threads altogether** e.g. using a system Timer or **Manually create new Thread** for **I/O-bound** operations.

###Starting a Task

**CPU-bound or short-running task**. Using thread pool by default. Must block the Foreground thread using .Wait()/Console.Readline() to avoid early exit.

```csharp
Task task = Task.Run (() =>
{
	Thread.Sleep (2000);
	Console.WriteLine ("Foo");
});
Console.WriteLine (task.IsCompleted); // False
task.Wait(); // Blocks until task is complete
```

**For I/O-bound or long running task**. 

####Task.Factory

```csharp
// This will not use thread-pool
Task task = Task.Factory.StartNew (() => ..., TaskCreationOptions.LongRunning);
```
####TaskCompletionSource

```csharp
public class TaskCompletionSource<TResult>
{
	public void SetResult (TResult result);
	public void SetException (Exception exception);
	public void SetCanceled();
	...
}
```

You can create a Task by Manually create a Thread

```csharp
With TaskCompletionSource, we can write our own Run method:
Task<TResult> Run<TResult> (Func<TResult> function)
{
	var tcs = new TaskCompletionSource<TResult>();
	new Thread (() =>
	{
		try { tcs.SetResult (function()); }
		catch (Exception ex) { tcs.SetException (ex); }
	}).Start();
	return tcs.Task;
}
```

You can create a Task by avoid creating Thread or avoid block ANY Thread. e.g. use System.Timers.Timer which **ONLY** use thread from Thread Pool **WHEN** fire callback.

```csharp
Task<int> GetAnswerToLife()
{
	var tcs = new TaskCompletionSource<int>();
	// Create a timer that fires once in 5000 ms:
	var timer = new System.Timers.Timer (5000) { AutoReset = false };
	timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult (42); };
	timer.Start();
	return tcs.Task;
}

Task Delay (int milliseconds)
{
	var tcs = new TaskCompletionSource<object>();
	var timer = new System.Timers.Timer (milliseconds) { AutoReset = false };
	timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult (null); };
	timer.Start();
	return tcs.Task;
}
```

Example:
```
for (int i = 0; i < 10000; i++)
	Delay (5000).GetAwaiter().OnCompleted (() => Console.WriteLine (42));
```
p.s. Timers fire their callbacks on pooled threads, so after five seconds,
the thread pool will receive 10,000 requests to call SetRe
sult(null) on a TaskCompletionSource. If the requests arrive
faster than they can be processed, the thread pool will respond
by enqueuing and then processing them at the optimum level
of parallelism for the CPU. This is ideal if the thread-bound jobs
are short-running, which is true in this case: the thread-bound
job is merely the call to SetResult.

###Getting Return Value

```csharp
// No return value
Task task = Task.Run (() => Console.WriteLine ("Foo"));
```

```csharp
// Yes return value
Task<int> task = Task.Run (() => { Console.WriteLine ("Foo"); return 3; });
```

Notice that we **don’t explicitly return a task** in the method body. The compiler manufactures the task for asynchronous functions. That means you only need for bottom-level methods, that **initiate I/O-bound** you create the task with **TaskCompletionSource**. And for methods that **initiate CPU-bound**, you create the task with **Task.Run**.

###Exceptions - AggregateException

Exceptions are thrown AT the blocking statement. e.g. task.Wait, task.Result

```csharp
Task task = Task.Run (() => { throw null; });
try
{
	task.Wait(); // thrown at blocking statement
}
catch (AggregateException aex)
{
	if (aex.InnerException is NullReferenceException)
		Console.WriteLine ("Null!");
	else
		throw;
}
```

###Task.Delay(millsec)


##Asynchronous Programming

###Why?

- A typically server-side applications that deal efficiently with a lot of concurrent I/O. The challenge here is not thread-safety (as there’s usually minimal shared state) but thread-efficiency; in particular, not consuming a thread per network request.
- To simplify thread-safety in rich-client applications. 

###Asynchronous Function - async & await

Regular Method

```csharp
async Task DisplayPrimesCount()
{
	int result = await GetPrimesCountAsync (2, 1000000);
	Console.WriteLine (result);
}
```

Lambda Expression


**async () => { ... }**

```csharp
// anonymous methods
Func<Task> foo= async () =>
{
	await Task.Delay (1000);
	Console.WriteLine ("Foo");
};
// calling
await foo();
```

Attaching event handler

```csharp
myButton.Click += async (sender, args) =>
{
	await Task.Delay (1000);
	myButton.Content = "Done";
};
```


The real power of await expressions is that they can appear almost anywhere in code. When the method completes (or faults), execution resumes where it left off, with the values of local variables and loop counters preserved.

###Parallelism

Calling an asynchronous method without awaiting it allows the code that follows
to execute in parallel. 

```csharp
var task1 = PrintAnswerToLife();
var task2 = PrintAnswerToLife();
await task1; await task2; // (By awaiting both operations afterward, we “end” the parallelism at that point.
```

###Task Combinators

The CLR includes two task combinators: Task.WhenAny and Task.

####Task.WhenAny

```csharp
Task<int> winningTask = await Task.WhenAny (Delay1(), Delay2(), Delay3());
Console.WriteLine ("Done");
Console.WriteLine (await winningTask); // 1
```

**await twice** within 1 step
```
int answer = await await Task.WhenAny (Delay1(), Delay2(), Delay3());
```

p.s. If a non-winning task subsequently faults, the exception will go unobserved unless
you subsequently await the task (or query its Exception property).

####Task.WhenAll

```
await Task.WhenAll (Delay1(), Delay2(), Delay3());
```

We could get a similar result by awaiting task1, task2 and task3 in turn:

```csharp
Task task1 = Delay1(), task2 = Delay2(), task3 = Delay3();
await task1; await task2; await task3;
```

**The difference is that should task1 fault, we’ll never get to await task2/task3, and
any of their exceptions will go unobserved.**

In contrast, Task.WhenAll doesn’t complete until all tasks have completed—even
when there’s a fault. And if there are multiple faults, their exceptions are combined
into the task’s AggregateException

**Task.WhenAll returns - `Task<T[]>`**

```csharp
Task<int> task1 = Task.Run (() => 1);
Task<int> task2 = Task.Run (() => 2);
int[] results = await Task.WhenAll (task1, task2); // { 1, 2 }
```


###Cancellation

To support cancellation, async method needs to accept a "cancellation token".

To get a cancellation token, we first instantiate a **CancellationTokenSource** and use its **Token** property.

```csharp
var cancelSource = new CancellationTokenSource();
Task foo = await FooAsync (cancelSource.Token);
...
// some time later
cancelSource.Cancel();
```

You can specify a time interval when constructing CancellationTokenSource to initiate cancellation after a set period of time. It’s useful for implementing timeouts.

```csharp
var cancelSource = new CancellationTokenSource (5000);
try { await Foo (cancelSource.Token); }
catch (OperationCanceledException ex) { Console.WriteLine ("Cancelled"); }
```

Tasks generated by the compiler’s asynchronous functions automatically enter a
“Canceled” state upon an unhandled OperationCanceledException (IsCanceled returns
true and IsFaulted returns false). 

###Progress - IProgress<T> and Progress<T>

```csharp
public interface IProgress<in T>
{
	void Report (T value);
}
```

```csharp
Task Foo (IProgress<int> onProgressPercentChanged)
{
	return Task.Run (() =>
	{
		for (int i = 0; i < 1000; i++)
		{
			if (i % 10 == 0) onProgressPercentChanged.Report (i / 10);
			// Do something compute-bound...
		}
	});
}
```

The Progress<T> class has a constructor that accepts a delegate of type Action<T>

```csharp
var progress = new Progress<int> (i => Console.WriteLine (i + " %"));
await Foo (progress);
```

##Async in MVC Controller

[http://www.asp.net/mvc/overview/performance/using-asynchronous-methods-in-aspnet-mvc-4](http://www.asp.net/mvc/overview/performance/using-asynchronous-methods-in-aspnet-mvc-4)

###Async Action returns ActionResult

```
public async Task<ActionResult> GizmosAsync()
{
    ViewBag.SyncOrAsync = "Asynchronous";
    var gizmoService = new GizmoService();
    return View("Gizmos", await gizmoService.GetGizmosAsync());
}
```

###Async Action returns Task ActionResult of IEnumerable&lt;List&lt;MyVM&gt;&gt;

```
public async Task<ActionResult> Index()
{
    using (HttpClient httpClient = new HttpClient())
    {
        var burl = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
        httpClient.BaseAddress = new Uri(burl);
        var uri = "/api/test";
        var response = await httpClient.GetAsync(uri);
        return View (await response.Content.ReadAsAsync<List<MyVM>>());
    }
}
```

###Parallel Operations using Task.WhenAll

```
public async Task<ActionResult> PWGasync()
{
    ViewBag.SyncType = "Asynchronous";
    var widgetService = new WidgetService();
    var prodService = new ProductService();
    var gizmoService = new GizmoService();

    var widgetTask = widgetService.GetWidgetsAsync();
    var prodTask = prodService.GetProductsAsync();
    var gizmoTask = gizmoService.GetGizmosAsync();

    await Task.WhenAll(widgetTask, prodTask, gizmoTask);

    var pwgVM = new ProdGizWidgetVM(
       widgetTask.Result,
       prodTask.Result,
       gizmoTask.Result
       );

    return View("PWG", pwgVM);
}
```

##Asynchronous Pattern

###TAP

- method `returns Task / Task<T>`
- method has Async suffix
- overload to accept cancellation token, `IProgress<T>`

###APM - Obsolete

- method return IAsyncResult
- method Beginxxx
- method Endxxx

###EAP - Obsolete

- class offers a family of members that internally manage concurrency
- e.g. WebClient class with async methods and event handler for complete

###BackgroundWorker - Obsolete

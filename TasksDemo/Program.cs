using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq;

namespace TasksDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("waiting....\n");

            #region Parallel example 1
            /*
            var watch = Stopwatch.StartNew();
            watch.Start();

            run1();
            run2();

            Console.WriteLine("i am serial,i use time:" + watch.ElapsedMilliseconds+Environment.NewLine);

            watch.Restart();

            Parallel.Invoke(run1, run2);

            watch.Stop();

            Console.WriteLine("i am parallel,i use time:" + watch.ElapsedMilliseconds);
            */
            #endregion

            #region Parallel example 2
            /*
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine("\nThe {0} compare", j);

                ConcurrentBag<int> bag = new ConcurrentBag<int>();
                var watch = Stopwatch.StartNew();
                watch.Start();

                for (int i = 0; i < 2000000; i++)
                {
                    bag.Add(i);
                }
                Console.WriteLine("serial computing,lists count:{0} ,use time:{1}", bag.Count, watch.ElapsedMilliseconds);
                watch.Stop();
                GC.Collect();

                bag = new ConcurrentBag<int>();
                watch.Restart();

                Parallel.For(0, 2000000, i =>
                {
                    bag.Add(i);
                });
                Console.WriteLine("parallel-for computing,lists count:{0} ,use time:{1}", bag.Count, watch.ElapsedMilliseconds);
                watch.Stop();
                GC.Collect();

                bag = new ConcurrentBag<int>();
                watch.Restart();

                Parallel.ForEach(Partitioner.Create(0, 2000000), i =>
                {
                    for (int m = i.Item1; m < i.Item2; m++)
                    {
                        bag.Add(m);
                    }
                });
                Console.WriteLine("parallel-foreach computing,lists count:{0} ,use time:{1}", bag.Count, watch.ElapsedMilliseconds);
                watch.Stop();
                GC.Collect();
            }
            */
            #endregion

            #region Parallel example 3
            /*
            ConcurrentBag<int> bags = new ConcurrentBag<int>();

            Parallel.For(0, 2000000, (i, state) =>
            {
                if (bags.Count == 1000)
                {
                    state.Break();
                    return;
                }
                bags.Add(i);
            });
            Console.WriteLine("current lists count:{0}", bags.Count);
            */
            #endregion

            #region Parallel example 4
            /*
            try
            {
                Parallel.Invoke(exception1, exception2);
            }
            catch (AggregateException ex)
            {
                foreach (var single in ex.InnerExceptions)
                {
                    Console.WriteLine(single.Message);
                }
            } 
            */
            #endregion

            #region Parallel example 5
            /*
            var watch = Stopwatch.StartNew();
            watch.Start();

            var vbag = new ConcurrentBag<int>();
            ParallelOptions paoption = new ParallelOptions();
            paoption.MaxDegreeOfParallelism = 8;

            Parallel.For(0, 30000000, paoption, i =>
            {
                vbag.Add(i);
            });
            watch.Stop();
            Console.WriteLine("parallel computing,lists count:{0},use time:{1}", vbag.Count, watch.ElapsedMilliseconds);

            paoption.MaxDegreeOfParallelism = 1;
            watch.Restart();
            vbag = new ConcurrentBag<int>();
            Parallel.For(0, 30000000, paoption, i =>
            {
                vbag.Add(i);
            });
            watch.Stop();
            Console.WriteLine("parallel computing,lists count:{0},use time:{1}", vbag.Count, watch.ElapsedMilliseconds);
            */
            #endregion

            #region Parallel example 6
            /*
            // Source must be array or IList.
            var source = Enumerable.Range(0, 30000000).ToArray();

            // Partition the entire source array.
            var rangePartitioner = Partitioner.Create(0, source.Length);

            double[] results = new double[source.Length];
            ParallelOptions po = new ParallelOptions();
            var watch = Stopwatch.StartNew();
            watch.Start();
            po.MaxDegreeOfParallelism = 1;
            // Loop over the partitions in parallel.
            //Parallel.ForEach(rangePartitioner,po, (range, loopState) =>
            //{
            //    // Loop over each range element without a delegate invocation.
            //    for (int i = range.Item1; i < range.Item2; i++)
            //    {
            //        results[i] = source[i] * Math.PI;
            //    }
            //});
            Parallel.For(0, 30000000, i =>
            {
                results[i] = source[i] * Math.PI;
            });
            watch.Stop();

            Console.WriteLine("Operation complete. use time:{0}", watch.ElapsedMilliseconds);
            */
            #endregion

            #region Task example 1
            /*
            var watch = Stopwatch.StartNew();
            watch.Start();

            run1();
            run2();
            watch.Stop();
            Console.WriteLine("i am no task computing,use time:{0}\n", watch.ElapsedMilliseconds);

            Task task2 = Task.Factory.StartNew(new Action(run2));
            Task task1 = new Task(run1);
            //Task task2 = new Task(run2);

            watch.Restart();
            //task2.Start();
            task1.Start();
            watch.Stop();
            Console.WriteLine("i am task compting,use time:{0}", watch.ElapsedMilliseconds);
            */
            #endregion

            #region Task example 2
            /*
            var watch = Stopwatch.StartNew();
            watch.Start();

            Task<char> task = Task.Factory.StartNew(s => taskDisplay(s), DateTime.Now);
            Console.WriteLine("\n{0}", task.Result);

            Task task2 = Task.Factory.StartNew(s => taskDisplay(s), DateTime.Now);
            Console.WriteLine(task2.AsyncState);
            */
            #endregion

            #region Task cancel example
            /*
            CancellationTokenSource s = new CancellationTokenSource();
            CancellationToken token = s.Token;

            Task task1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("1-1 the task has cancel");
                        Console.WriteLine("task1 :{0}", task1.IsCompleted);
                        //throw new OperationCanceledException(token);

                        return;
                    }
                    else
                    {
                        Console.WriteLine("2-1 current value:{0}", i);
                    }
                }
            });
            Task task2 = Task.Factory.StartNew(() =>
            {
                for (int j = 0; j < int.MaxValue; j++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("1-2 the task has cancel");

                        Console.WriteLine("task2 :{1}", task2.IsCompleted);
                        //throw new OperationCanceledException(token);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("2-2 current value:{0}", j);
                    }
                }
            });

            token.Register(() =>
            {
                Console.WriteLine("3 i am the callback when the task has cancel");
            });
            Console.ReadLine();
            Console.WriteLine("4 do cancel");
            s.Cancel();

            Console.WriteLine("5 main() exec over");
            */
            #endregion

            #region Task waitOne example
            /*
            CancellationTokenSource s = new CancellationTokenSource();
            CancellationToken token = s.Token;

            Task task1 = new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine("任务1 中i的值是{0}", i);
                    //token.WaitHandle.WaitOne(1000);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("任务1 执行完毕");
            });
            Console.WriteLine("任务1 当前状态:{0}", task1.Status);

            Task task2 = new Task(() =>
            {
                Console.WriteLine("任务2 执行完毕");
            });

            task1.Start();
            task2.Start();
            Console.WriteLine("任务1 当前状态:{0}", task1.Status);

            Console.WriteLine("等待所有任务执行完毕....\n");
            Console.ReadLine();
            s.Cancel();
            Task.WaitAll(task1, task2);
            Console.WriteLine("任务1 当前状态:{0}", task1.Status);

            Console.WriteLine("all tasks is exec over");
            */
            #endregion

            #region Task exception example 1,2
            /*
            Task task1 = Task.Factory.StartNew(() =>
            {
                throw new NotImplementedException("没有实现的异常");
            });
            Task task2 = Task.Factory.StartNew(() =>
            {
                throw new ArgumentException("参数为空的异常");
            });
            Task task3 = Task.Factory.StartNew(() =>
            {
                throw new Exception("异常");
            });
            Task task4 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("正常");
            });

            try
            {
                Task.WaitAll(task1, task2, task3, task4);
            }
            catch (AggregateException exs)
            {
                //处理方法 1
                //foreach (var ex in exs.InnerExceptions)
                //{
                //    Console.WriteLine("异常:{0}", ex.Message);
                //}

                //处理方法 2
                exs.Flatten().Handle(ex =>
                {
                    if (ex is NotImplementedException)
                    {
                        Console.WriteLine("忽略");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("异常内容:{0}", ex.Message);
                        return true;
                    }
                });
            } 
            */
            #endregion

            #region Task exception example 3
            /*
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                e.SetObserved();
                e.Exception.Flatten().Handle(ex =>
                {
                    Console.WriteLine("异常为:{0}", ex.Message);
                    return true;
                });
            };
            Task task1 = Task.Factory.StartNew(() =>
            {
                throw new NullReferenceException();
            });
            Task task2 = Task.Factory.StartNew(() =>
            {
                throw new ArgumentOutOfRangeException();
            });
            while (!task1.IsCompleted || !task2.IsCompleted)
            {
                Console.WriteLine("task1 status:{0}\ntask2 status:{1}", task1.Status, task2.Status);
                Thread.Sleep(500);
            }
            Console.WriteLine("task1 status:{0}\ntask2 status:{1}", task1.Status, task2.Status);
            */
            #endregion

            #region Task wait example 1
            /*
            var task1 = Task.Factory.StartNew<List<string>>(() => GetList());
            task1.Wait();

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task1 return list is :{0}", string.Join("-", task1.Result));
            });
            */
            #endregion

            #region Task continuewith example 1
            /*
            var task1 = Task.Factory.StartNew<List<string>>(() => GetList());

            var task2 = task1.ContinueWith(result =>
            {
                Console.WriteLine("task1 result is: {0}", string.Join(" . ", result.Result));
            });
            */
            #endregion

            #region Task continuewith example 2
            /*
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            var t1 = Task.Factory.StartNew(() =>
            {
                stack.Push(1);
                stack.Push(2);
            });

            var t2 = t1.ContinueWith(t =>
            {
                int result;
                stack.TryPop(out result);
            });
            var t3 = t1.ContinueWith(t =>
            {
                int result;
                stack.TryPop(out result);
            });

            Console.WriteLine("t2 statue is:{0} ,t3 statue is:{1} ,stack is:{2}", t2.Status, t3.Status, string.Join("-", stack.ToArray()));
            Console.ReadLine();

            Task.WaitAll(t2, t3);

            var t4 = Task.Factory.StartNew(() =>
            {
                stack.Push(1);
                stack.Push(2);
            });

            var t5 = t4.ContinueWith(t =>
            {
                int result;
                stack.TryPop(out result);
            });
            var t6 = t4.ContinueWith(t =>
            {
                int result;
                stack.TryPeek(out result);
            });
            Task.WaitAll(t5, t6);

            var t7 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("stack's count is:{0}", stack.Count);
            }); 
            */
            #endregion

            #region Task continuewith<T> example 1
            /*
            Task<BankAccount> rootTask = new Task<BankAccount>(() =>
            {
                BankAccount account = new BankAccount();
                for (int i = 0; i < 1000; i++)
                {
                    account.Balance++;
                }
                return account;
            });

            var continueTask1 = rootTask.ContinueWith(resu =>
            {
                Console.WriteLine("Interim Balance 1:{0}", resu.Result.Balance);
                return resu.Result.Balance * 2;
            });

            Task continueTask2 = continueTask1.ContinueWith(resu =>
            {
                Console.WriteLine("Final Balance 1:{0}", resu.Result);
            });

            rootTask.ContinueWith<int>(resu =>
            {
                Console.WriteLine("Interim Balance 2:{0}", resu.Result.Balance);
                return resu.Result.Balance / 2;

            }).ContinueWith(resu2 =>
            {
                Console.WriteLine("Final Balance 2:{0}", resu2.Result);
            });

            rootTask.Start();
            */
            #endregion

            #region Task.Factory.ContinueWhenAll<T> example
            /*
            CancellationTokenSource s = new CancellationTokenSource();
            CancellationToken token = s.Token;

            int taskCount = 10;
            BankAccount account = new BankAccount();
            Task<int>[] tasks = new Task<int>[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = new Task<int>(stateObject =>
                {
                    int tmp = (int)stateObject;
                    for (int j = 0; j < 10000; j++)
                    {
                        tmp++;
                    }
                    return tmp;
                }, account.Balance);
            }

            Task continueTask = Task.Factory.ContinueWhenAll<int>(tasks, antecedents =>
            {
                foreach (Task<int> item in antecedents)
                {
                    account.Balance += item.Result;
                }
            });
            foreach (var task in tasks)
            {
                task.Start();
            }
            try
            {
                s.Cancel();
                continueTask.Wait();
            }
            catch (AggregateException aex)
            {
                aex.Flatten().Handle(inner =>
                {
                    Console.WriteLine("handled exception of type:{0}", inner);
                    return true;
                });
            }
            Console.WriteLine("Exception value:{0} ,Balance:{1}", 10000, account.Balance);
            */
            #endregion
                        
            #region Parallel For example 1
            /*
            var watch = Stopwatch.StartNew();
            watch.Start();

            Console.WriteLine("use for{0}-----------{0}", Environment.NewLine);

            for (int i = 0; i < 5000; i++)
            {
                Console.WriteLine("i = {0} thread id = {1}", i, Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("for: use time:{0}\npress enter key to continue...\n", watch.ElapsedMilliseconds);

            Console.ReadLine();
            watch.Restart();

            Console.WriteLine("{0}use Parallel.For{0}-----------{0}", Environment.NewLine);
            Parallel.For(0, 5000, i =>
            {
                Console.WriteLine("i = {0} thread id = {1}", i, Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("parallel.for: use time:{0}", watch.ElapsedMilliseconds);
            */
            #endregion

            #region Parallel ForEach example 2
            /*
            Action ac1 = () =>
            {
                Console.WriteLine("thread id = {0}", Thread.CurrentThread.ManagedThreadId);
            };
            Action ac2 = () =>
            {
                Console.WriteLine("thread id = {0}", Thread.CurrentThread.ManagedThreadId);
            };
            Action ac3 = () =>
            {
                Console.WriteLine("thread id = {0}", Thread.CurrentThread.ManagedThreadId);
            };
            Action ac4 = () =>
            {
                Console.WriteLine("thread id = {0}", Thread.CurrentThread.ManagedThreadId);
            };
            Parallel.Invoke(ac1, ac2, ac3, ac4);

            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            ParallelLoopResult result = Parallel.ForEach(list, (i, state) =>
            {

                if (i == 5)
                    state.Break();

                Console.WriteLine("i = {0} ,thread id = {1}", i, Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("iscompleted = {0} ,breakValue = {1}", result.IsCompleted, result.LowestBreakIteration);
            */
            #endregion

            #region Parallel For cancel example
            /*
            CancellationTokenSource token = new CancellationTokenSource();
            ParallelOptions option = new ParallelOptions()
            {
                CancellationToken = token.Token
            };
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(10000);
                token.Cancel();
                Console.WriteLine("task canceled.");
            });
            try
            {
                Parallel.For(0, int.MaxValue, option, i =>
                {
                    Console.WriteLine("i = {0} ,thread id = {1}", i, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                });
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("exception...");
            }
            */
            #endregion

            #region Plinq AsParallel example 1
            /*
            int[] source = new int[10];
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = i;
            }
            var p1 = source.AsParallel().Where(p => p % 2 == 0);
            foreach (var item in p1)
            {
                Console.WriteLine("AsParallel result is: {0}", item);
            }
            var p2 = source.AsParallel().AsSequential().Where(p => p % 2 == 0);
            foreach (var item in p2)
            {
                Console.WriteLine("AsParallel.AsSequential is: {0}", item);
            }
            var p3 = source.AsParallel().AsOrdered().Where(p => p % 2 == 0);
            foreach (var item in p3)
            {
                Console.WriteLine("AsParallel.AsOrdered is: {0}", item);
            }
            var p4 = source.AsParallel().AsUnordered().Where(p => p % 2 == 0);
            foreach (var item in p4)
            {
                Console.WriteLine("AsParallel.AsUnordered is: {0}", item);
            }
            */
            #endregion

            #region Plinq AsParallel().With... example 2
            /*
            CancellationTokenSource s = new CancellationTokenSource();
            IEnumerable<int> source = Enumerable.Range(0, 1000000);

            var result1 = source.AsParallel().WithCancellation(s.Token).WithExecutionMode(ParallelExecutionMode.ForceParallelism).WithMergeOptions(ParallelMergeOptions.NotBuffered).Where(c => c % 2 == 0);
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                s.Cancel();
                Console.WriteLine("task is canceled");
            });
            try
            {
                foreach (int item in result1)
                {
                    Console.WriteLine("CancellationTokenSource result: {0},thread id is: {1}", item, Thread.CurrentThread.ManagedThreadId);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("task cancel exception");
            }
            */
            #endregion

            #region Plinq AsParallel().ForAll example 3
            /*
            IEnumerable<int> source = ParallelEnumerable.Range(0, 100000);
            source.AsParallel().ForAll(i =>
            {
                Console.WriteLine("current i is:{0} ,thread id is:{1}", i, Thread.CurrentThread.ManagedThreadId);
            });
            */
            #endregion

            #region Plinq ParallelEnumerable.Range example
            /*
            var sour = from a in ParallelEnumerable.Range(0, 10)
                       where a % 2 == 0
                       select a;
            foreach (var item in sour)
            {
                Console.WriteLine("current item is:{0} ,thread id is:{1}", item, Thread.CurrentThread.ManagedThreadId);
            }
            */
            #endregion

            #region Plinq ParallelEnumerable.Repeat example
            /*
            var sour2 = ParallelEnumerable.Repeat(10, 10).Select(i => Math.Pow(i, 2));
            foreach (var item in sour2)
            {
                Console.WriteLine("current item is:{0} ,thread id is:{1}", item, Thread.CurrentThread.ManagedThreadId);
            } 
            */
            #endregion

            #region Plinq AsParallel example 1
            /*
            var source = LoadData();
            var watch = Stopwatch.StartNew();
            watch.Start();

            var query1 = (from s in source.Values
                          where s.Age > 20 && s.Age < 25
                          select s).ToList();
            watch.Stop();
            Console.WriteLine("串行查询时间:{0}", watch.ElapsedMilliseconds);

            watch.Restart();

            var query2 = (from s in source.Values.AsParallel()
                          where s.Age > 20 && s.Age < 25
                          select s).ToList();
            watch.Stop();
            Console.WriteLine("并行查询时间:{0}", watch.ElapsedMilliseconds);
            */
            #endregion

            #region Plinq AsParallel example 2
            /*
            var dic = LoadData();

            var query1 = (from s in dic.Values.AsParallel()
                          where s.Age > 20 && s.Age < 25
                          select s).ToList();

            Console.WriteLine("不排序查询时间:");
            query1.Take(10).ToList().ForEach(i =>
            {
                Console.WriteLine(i.CreateTime);
            });
            Console.WriteLine(Environment.ProcessorCount);
            var query2 = (from s in dic.Values.AsParallel()
                          .WithDegreeOfParallelism(Environment.ProcessorCount - 1)
                          where s.Age > 20 && s.Age < 25
                          orderby s.CreateTime descending
                          select s).ToList();
            Console.WriteLine("排序后查询时间:");
            query2.Take(10).ToList().ForEach(i =>
            {
                Console.WriteLine(i.CreateTime);
            });
            */
            #endregion

            #region Barrier example 1
            /*
            int count = 5;
            BankAccount[] accounts = new BankAccount[count];
            for (int i = 0; i < count; i++)
            {
                accounts[i] = new BankAccount();
            }

            int totalBalance = 0;
            Barrier barrier = new Barrier(count, b =>
            {
                totalBalance = 0;
                foreach (var account in accounts)
                {
                    totalBalance += account.Balance;
                }

                Console.WriteLine("total balance is:{0}", totalBalance);
            });

            Task[] tasks = new Task[count];
            for (int i = 0; i < count; i++)
            {
                tasks[i] = new Task(indata =>
                {
                    BankAccount inAccount = indata as BankAccount;

                    Random rnd = new Random();
                    for (int j = 0; j < 1000; j++)
                    {
                        inAccount.Balance += rnd.Next(0, 100);
                    }

                    Console.WriteLine("task {0} ,phase {1} ended", Task.CurrentId, barrier.CurrentPhaseNumber);
                    barrier.SignalAndWait();

                    inAccount.Balance -= (totalBalance - inAccount.Balance) / 10;
                    Console.WriteLine("task {0} ,phase {1} ended", Task.CurrentId, barrier.CurrentPhaseNumber);
                    barrier.SignalAndWait();

                }, accounts[i]);
            }
            foreach (var t in tasks)
            {
                t.Start();
            }
            Task.WaitAll(tasks);
            */
            #endregion

            #region CountdownEvent example
            /*
            CountdownEvent cd = new CountdownEvent(3);
            Random rnd = new Random();
            Task[] tasks = new Task[6];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(rnd.Next(500, 1000));
                    Console.WriteLine("task {0} signalling event", Task.CurrentId);
                    cd.Signal();
                    Console.WriteLine("cd {0}", cd.CurrentCount);
                });
            }
            tasks[0] = new Task(() =>
            {
                cd.Wait();
                Console.WriteLine("Event 0 has been set ,task is {0}", Task.CurrentId);
            });
            tasks[2] = new Task(() =>
            {
                cd.Wait();
                Console.WriteLine("Event 2 has been set ,task is {0}", Task.CurrentId);
            });
            foreach (var t in tasks)
            {
                t.Start();
            }
            Task.WaitAll(tasks);
            */
            #endregion

            #region ManualRestEventSlim example
            /*
            ManualResetEventSlim manualEvent = new ManualResetEventSlim();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Task waitingTask = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    manualEvent.Wait(tokenSource.Token);
                    Console.WriteLine("waiting task active ,task id:{0}", Thread.CurrentThread.ManagedThreadId);
                }
            });

            Task signallingTask = Task.Factory.StartNew(() =>
            {
                Random rnd = new Random();

                while (!tokenSource.Token.IsCancellationRequested)
                {
                    tokenSource.Token.WaitHandle.WaitOne(rnd.Next(500, 2000));
                    manualEvent.Set();
                    Console.WriteLine("---------------------------------------ManualEvent set ,task id:{0}", Thread.CurrentThread.ManagedThreadId);

                    tokenSource.Token.WaitHandle.WaitOne(rnd.Next(500, 2000));
                    manualEvent.Reset();
                    Console.WriteLine("ManualEvent reset ,task id:{0}", Thread.CurrentThread.ManagedThreadId);
                }
            });

            Console.WriteLine("press enter key to cancel task");
            Console.ReadLine();

            tokenSource.Cancel();

            try
            {
                Task.WaitAll(waitingTask, signallingTask);
            }
            catch (AggregateException aex)
            {
                aex.Flatten().Handle(ex =>
                {
                    Console.WriteLine("Exception is {0}", ex.Message);
                    return true;
                });
            }
            */
            #endregion

            #region AutoResetEvent example
            /*
            var arEvent = new AutoResetEvent(false);

            CancellationTokenSource tokenSource = new CancellationTokenSource();

            for (int i = 0; i < 3; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    while (!tokenSource.Token.IsCancellationRequested)
                    {
                        arEvent.WaitOne();
                        Console.WriteLine("Task {0} released", Task.CurrentId);
                    }
                }, tokenSource.Token);
            }

            Task signallingTask = Task.Factory.StartNew(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    tokenSource.Token.WaitHandle.WaitOne(500);
                    arEvent.Set();
                    Console.WriteLine("Event set");
                }
            });

            Console.ReadLine();
            tokenSource.Cancel();
            */
            #endregion

            #region SemaphoreSlim example
            /*
            var semap = new SemaphoreSlim(0);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        semap.Wait(tokenSource.Token);
                        Console.WriteLine("Task {0} released ,thread id {1}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
                    }
                });
            }

            Task signalling = Task.Factory.StartNew(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    tokenSource.Token.WaitHandle.WaitOne(500);
                    semap.Release(6);
                    Console.WriteLine("Semaphore released");
                }
                tokenSource.Token.ThrowIfCancellationRequested();
            });

            Console.ReadLine();
            tokenSource.Cancel();
            */
            #endregion

            #region ConcurrentQueue(Enqueue,TryDequeue),ConcurrentStack(Push,TryPop),ConcurrentBag(Add,TryTake),ConcurrentDictionary(TryAdd,TryGetValue) example
            /*
            ConcurrentQueue<int> sharedQueue = new ConcurrentQueue<int>();
            for (int i = 0; i < 10000000; i++)
            {
                sharedQueue.Enqueue(i);
            }
            int itemcount = 0;
            int tmp = 0;
            Task[] tasks = new Task[10];
            for (int j = 0; j < tasks.Length; j++)
            {
                tasks[j] = Task.Factory.StartNew(() =>
                {
                    while (sharedQueue.Count > 0)
                    {
                        int queueElement;
                        bool gotElement = sharedQueue.TryDequeue(out queueElement);
                        if (gotElement)
                        {
                            Interlocked.Increment(ref itemcount);//安全递增(保证原子性)
                            tmp += 1;//不安全递增(内存取出,然后+1,再覆盖原来的内存,所以会产生同时覆盖的问题)
                        }
                    }
                });
            }
            Task.WaitAll(tasks);
            Console.WriteLine("Items process is {0} ,tmp is {1}", itemcount, tmp);
            */
            #endregion
            
            
            Console.Read();
        }

        static ConcurrentDictionary<int, Studen> LoadData()
        {
            ConcurrentDictionary<int, Studen> dic = new ConcurrentDictionary<int, Studen>();

            Parallel.For(0, 6000000, i =>
            {
                Studen s = new Studen()
                {
                    ID = i,
                    Name = "hxc" + i,
                    Age = (uint)i % 131,
                    CreateTime = DateTime.Now.AddSeconds(i)
                };
                dic.TryAdd(i, s);
            });
            return dic;
        }

        static List<string> GetList()
        {
            return new List<string>() { "1", "2", "3", "4" };
        }

        static void exception1()
        {
            Thread.Sleep(3000);
            throw new Exception("i am exception1 wait 3s,i throw the exception");
        }
        static void exception2()
        {
            Thread.Sleep(5000);
            throw new Exception("i am exception2 wait 5s,i throw the exception");
        }

        static void run1()
        {
            Thread.Sleep(3000);
            Console.WriteLine("i am run1,i run 3s");
        }
        static void run2()
        {
            Thread.Sleep(5000);
            Console.WriteLine("i am run2,i run 5s");
        }

        static char taskDisplay(object time)
        {
            Console.WriteLine("current time is:{0}\n", time);
            return 'y';
        }
    }
    class Studen
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public uint Age { get; set; }
        public DateTime CreateTime { get; set; }
    }
    class BankAccount
    {
        public int Balance { get; set; }
    }
}

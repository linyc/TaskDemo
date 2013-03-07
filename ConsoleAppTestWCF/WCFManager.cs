using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CN100.AssistantService.IBLL;
using CN100.AssistantService.Entity;
using CN100.EnterprisePlatform.Wcf;
using CN100.EnterprisePlatform.Wcf.Core;
using CN100.EnterprisePlatform.Wcf.Core.Config;
using System.IO;
using System.Threading;

namespace ConsoleAppTestWCF
{
    class WCFManager
    {
        private static readonly object obj1 = new object();
        private static readonly object obj2 = new object();

        public static readonly WCFManager Instance = new WCFManager();
        private WcfClientFactory WCF = null;

        public WCFManager()
        {
            WCF = WcfClients.Default;
        }

        public int TestIProductInfoService(int count)
        {
            List<WcfTcpClient<IProductInfoService>> clientList = new List<WcfTcpClient<IProductInfoService>>(count);
            int counter = 0;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    counter++;
                    Func<int,int> act = n => {

                        clientList.Add(WCF.CreateClient<IProductInfoService>());

                        Guid randomGuid = Guid.Parse("a189ce57-5aac-476c-b2d8-9fd6d514bc9e");
                        string datfile = @"G:\Desktop\新建文件夹\a189ce57-5aac-476c-b2d8-9fd6d514bc9e.dat";
                        string zipfile = @"G:\Desktop\新建文件夹\a189ce57-5aac-476c-b2d8-9fd6d514bc9e.zip";
                        lock (obj1)
                        {
                            DateTime dt1 = DateTime.Now;
                            Console.WriteLine("No.{0}\nStart:{1}\nCall Function UpLoadListCSVModel Please wait...",n,dt1.ToString("HH:mm:ss"));
                            Stream jsonFileStream = new FileStream(datfile, FileMode.Open, System.Security.AccessControl.FileSystemRights.ReadAndExecute, FileShare.Read, 8, FileOptions.Asynchronous);// File.Open(datfile, FileMode.Open);
                            UpLoadListCSVModelArgs args = new UpLoadListCSVModelArgs(3342, randomGuid, jsonFileStream, 10240000);
                            UpLoadListCSVModelResult actual = clientList[n].Channel.UpLoadListCSVModel(args);
                            jsonFileStream.Close();
                            Console.WriteLine("No.{0}\nEnd:{1}\nCall Function UpLoadListCSVModel Complated.", n,DateTime.Now.Subtract(dt1).Minutes);
                          
                            if (actual.Success)
                            {
                                DateTime dt2 = DateTime.Now;
                                Console.WriteLine("No.{0}\nStart:{1}\nCall Function UpLoadImgZipFile Please wait...", n, dt2.ToString("HH:mm:ss"));
                                jsonFileStream = new FileStream(zipfile, FileMode.Open, System.Security.AccessControl.FileSystemRights.ReadAndExecute, FileShare.Read, 8, FileOptions.Asynchronous);// File.Open(zipfile, FileMode.Open);
                                UploadImgZipFileArgs ziparg = new UploadImgZipFileArgs(randomGuid, 3342, 0, "", 0, @"\\192.168.0.99\PublicImage1\20130119002\", 0, jsonFileStream);
                                UpLoadImgZipFileResult zipres = clientList[n].Channel.UpLoadImgZipFile(ziparg);
                                Console.WriteLine("No.{0}\nEnd:{1}\nCall Function UpLoadImgZipFile Complated.", n, DateTime.Now.Subtract(dt2).Minutes);
                            }
                        }
                        return n;
                    };
                    act.BeginInvoke(i, ia => { Console.WriteLine("No.{0}\tCall Complated!",act.EndInvoke(ia)); },null);

                    //System.Threading.Thread.Sleep(500);
                }
                return counter;
            }
            catch
            {
                return counter;
            }
            finally
            {
                foreach (var item in clientList)
                {
                    item.Dispose();
                }
            }
        }
    }
}

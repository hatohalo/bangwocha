using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Hatohalo.HttpNet
{

    /// <summary>
    /// 用于线程的委托。显示回调。用于显示线程的处理结果
    /// </summary>
    /// <param name="OutPutHT">需要返回的数据集合</param>
    public delegate void delegateForThread(HttpProgress progress);

 
    class ClassHttp
    {

        /// <summary>
        /// 头部数据
        /// </summary>
        public readonly string RE_Headers = "头部数据";
        /// <summary>
        /// 返回内容
        /// </summary>
        public readonly string RE_Bodys = "返回内容";
        /// <summary>
        /// 访问错误
        /// </summary>
        public readonly string RE_ERR = "访问错误";
        /// <summary>
        /// 缓存标记
        /// </summary>
        public readonly string RE_Cache = "缓存标记";

        private HttpBaseProtocolFilter filter;
        private HttpClient httpClient;
        private CancellationTokenSource cts;
        private IDictionary<string, object> RE;
        private string url;
       
        /// <summary>
        /// 设置或获取远程地址的URL，只支持http和https
        /// </summary>
        public string HttpURL
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        private bool _OpenCache = false;
        /// <summary>
        /// 设置或获取是否获取数据后，在本地进行缓存，默认不使用
        /// </summary>
        public bool OpenCache
        {
            get
            {
                return _OpenCache;
            }
            set
            {
                _OpenCache = value;
            }
        }




        private string _CacheID = "null_temp_no";
        /// <summary>
        /// 设置或获取本地缓存标记
        /// </summary>
        public string CacheID
        {
            get
            {
                return _CacheID;
            }
            set
            {
                _CacheID = value;
            }
        }



        public delegateForThread dftThis;
 
        public ClassHttp()
        {
            init();
        }

        public ClassHttp(delegateForThread dft)
        {
            init();
            dftThis = dft;
        }

        private void init()
        {
            filter = new HttpBaseProtocolFilter();
            httpClient = new HttpClient(filter);
            cts = new CancellationTokenSource();
            RE = new Dictionary<string, object>();

            RE.Add("头部数据", null);
            RE.Add("返回内容", null);
            RE.Add("访问错误", null);
            RE.Add("缓存标记", null);
        }


        /// <summary>
        /// 根据缓存标记，获得从缓存获取文本
        /// </summary>
        /// <returns></returns>
        public async Task<IDictionary<string, object>> LoadTextFormCache()
        {
            RE["头部数据"] = null;
            RE["返回内容"] = null;
            RE["访问错误"] = null;
            RE["缓存标记"] = null;

            try
            {
                    StorageFile sampleFile = await ApplicationData.Current.TemporaryFolder.GetFileAsync("/MyCache/" + _CacheID);
                    string hc = await FileIO.ReadTextAsync(sampleFile, Windows.Storage.Streams.UnicodeEncoding.Utf8);
                   
                    RE.Add("返回内容", hc);
            }
            catch (Exception ex)
            {
                RE["访问错误"] = "缓存意外错误：" + ex.Message;
            }

            return RE;
        }


        /// <summary>
        /// 根据缓存标记，获得从缓存获取byte[]
        /// </summary>
        /// <returns></returns>
        public async Task<IDictionary<string, object>> LoadByteFormCache()
        {
            RE["头部数据"] = null;
            RE["返回内容"] = null;
            RE["访问错误"] = null;
            RE["缓存标记"] = null;

            try
            {

                    StorageFile sampleFile = await ApplicationData.Current.TemporaryFolder.GetFileAsync("/MyCache/" + _CacheID);
                    IBuffer buffer = await FileIO.ReadBufferAsync(sampleFile);

                    RE.Add("返回内容", WindowsRuntimeBufferExtensions.ToArray(buffer));

            }
            catch (Exception ex)
            {
                RE["访问错误"] = "缓存意外错误：" + ex.Message;
            }

            return RE;
        }


        /// <summary>
        /// 根据网址获取字符串。同时返回头部数据、返回内容、错误内容、缓存标记
        /// </summary>
        /// <param name="CS">若参数为null或没有键值，执行Get类型，具体参数在网址中拼接。 其他执行Post类型，直接设置参数。</param>
        /// <returns></returns>
        public async Task<IDictionary<string, object>> LoadHttpText(IDictionary<string, string> CS)
        {
            //初始化返回值
            RE["头部数据"] = null;
            RE["返回内容"] = null;
            RE["访问错误"] = null;
            RE["缓存标记"] = null;

            try
            {


                //定义一个目标url实例
                Uri resourceUri;
                // 检测url是否合法，并创建实例，如果不合法，给出提示
                if (!HttpHelp.TryGetUri(url, out resourceUri))
                {
                    RE["访问错误"] = "非法地址，访问失败。";
                    return RE;
                }
                //开始获取数据

                HttpResponseMessage response;

                HttpMultipartFormDataContent form = new HttpMultipartFormDataContent();
                //若有参数传递
                if (CS != null && CS.Count() > 0)
                {
    
                    List<KeyValuePair<string, string>> CSgogo = new List<KeyValuePair<string, string>> ();
                    foreach (KeyValuePair<string, string> kv in CS)
                    {
                        CSgogo.Add(kv); 
                    }
                    // 需要 post 的数据
                    HttpFormUrlEncodedContent postData = new HttpFormUrlEncodedContent(CSgogo);
                    response = await httpClient.PostAsync(resourceUri, postData).AsTask(cts.Token);
                }
                else
                {
                    //没有设置独立参数，直接执行GET
                    response = await httpClient.GetAsync(resourceUri).AsTask(cts.Token);
                }




                //获取响应的内容
                RE["头部数据"] = HttpHelp.SerializeHeaders(response);
                string neirong = await response.Content.ReadAsStringAsync().AsTask(cts.Token);
                RE["返回内容"] = neirong;

                //处理缓存
                if (_OpenCache)
                {
                    StorageFile sampleFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(_CacheID, CreationCollisionOption.ReplaceExisting);
                    await FileIO.WriteTextAsync(sampleFile, neirong, Windows.Storage.Streams.UnicodeEncoding.Utf8);
                    RE["缓存标记"] = _CacheID;
                }

                //定义中途取消
                cts.Token.ThrowIfCancellationRequested();

            }
            catch (TaskCanceledException)
            {
                RE["访问错误"] = "请求被取消。";
            }
            catch (Exception ex)
            {
                RE["访问错误"] = "其他意外错误：" + ex.Message;
            }
            return RE;

        }



        /// <summary>
        /// 根据网址获取byte[]流。同时返回头部数据、返回内容、错误内容、缓存标记
        /// </summary>
        /// <param name="CS">若参数为null或没有键值，执行Get类型，具体参数在网址中拼接。 其他执行Post类型，直接设置参数。</param>
        /// <returns></returns>
        public async Task<IDictionary<string, object>> LoadHttpByte(IDictionary<string, string> CS)
        {

            RE["头部数据"] = null;
            RE["返回内容"] = null;
            RE["访问错误"] = null;
            RE["缓存标记"] = null;
            try
            {
                //定义一个目标url实例
                Uri resourceUri;
                // 检测url是否合法，并创建实例，如果不合法，给出提示
                if (!HttpHelp.TryGetUri(url, out resourceUri))
                {
                    RE["访问错误"] = "非法地址，访问失败。";
                    return RE;
                }

                HttpRequestMessage request;
                //若有参数传递
                if (CS != null && CS.Count() > 0)
                {
                    request = new HttpRequestMessage(HttpMethod.Post, resourceUri);

                    List<KeyValuePair<string, string>> CSgogo = new List<KeyValuePair<string, string>>();
                    foreach (KeyValuePair<string, string> kv in CS)
                    {
                        CSgogo.Add(kv);
                    }
                    // 需要 post 的数据
                    HttpFormUrlEncodedContent postData = new HttpFormUrlEncodedContent(CSgogo);
                    request.Content = postData;
                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Get, resourceUri);
                }
                request.Headers.Add("hatohalo", "isgetbyte");
             
             
                //获取头部
                HttpResponseMessage response = await httpClient.SendRequestAsync(request,  HttpCompletionOption.ResponseHeadersRead).AsTask(cts.Token);

                RE["头部数据"] = HttpHelp.SerializeHeaders(response);


                //获取数据
                byte[] REbyte;
                using (Stream responseStream = (await response.Content.ReadAsInputStreamAsync()).AsStreamForRead())
                {
                    int read = 0;
                    byte[] responseBytes = new byte[1000];

                    List<byte> lTemp = new List<byte>();
                    Int64 allLength = 0;

                    do
                    {
                        read = await responseStream.ReadAsync(responseBytes, 0, responseBytes.Length);

                        if (read != 0 )
                        {
                            allLength = allLength + read;
                            IBuffer responseBuffer = CryptographicBuffer.CreateFromByteArray(responseBytes);
                            responseBuffer.Length = (uint)read;
                            byte[] bytes_this = WindowsRuntimeBufferExtensions.ToArray(responseBuffer);
                            lTemp.AddRange(bytes_this);
                        }

                    } while (read != 0);

                    REbyte = new byte[allLength];
                    lTemp.CopyTo(REbyte);



                }
                RE["返回内容"] = REbyte;

 
                //处理缓存
                if (_OpenCache)
                {
                    StorageFile sampleFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(_CacheID, CreationCollisionOption.ReplaceExisting);
                    await FileIO.WriteBytesAsync(sampleFile,REbyte);
                    RE["缓存标记"] =  _CacheID;
                }


                //定义中途取消
                cts.Token.ThrowIfCancellationRequested();

            }
            catch (TaskCanceledException)
            {
                RE["访问错误"] = "请求被取消。";
            }
            catch (Exception ex)
            {
                RE["访问错误"] = "其他意外错误：" + ex.Message;
            }
            return RE;

        }


        /// <summary>
        /// 上传文件，不能超过9.9M，超过后，就不适合这种方式。 为防止大量上传的拒绝攻击，应该用套接字接收或BackgroundUploader
        /// </summary>
        /// <param name="CS"></param>
        /// <returns></returns>
        public async Task<IDictionary<string, object>> LoadHttpForUpLoad(byte[] file)
        { 
            RE["头部数据"] = null;
            RE["返回内容"] = null;
            RE["访问错误"] = null;
            RE["缓存标记"] = null;
            try
            {
                //定义一个目标url实例
                Uri resourceUri;
                // 检测url是否合法，并创建实例，如果不合法，给出提示
                if (!HttpHelp.TryGetUri(url, out resourceUri))
                {
                    RE["访问错误"] = "非法地址，访问失败。";
                    return RE;
                }
                if (file == null || file.Count() < 1)
                {
                    RE["访问错误"] = "没有需要上传的内容，上传失败。";
                    return RE;
                }

                //9.9M  .  10485759
                //uint streamLength = 10485759;


                MemoryStream ms = new MemoryStream(file);
                HttpStreamContent streamContent = new HttpStreamContent(ms.AsInputStream());
                streamContent.Headers.ContentLength = Convert.ToUInt32(ms.Length);
          
                HttpResponseMessage response = await httpClient.PostAsync(resourceUri, streamContent).AsTask(cts.Token);
                //获取响应的内容
                RE["头部数据"] = HttpHelp.SerializeHeaders(response);
                string neirong = await response.Content.ReadAsStringAsync().AsTask(cts.Token);
                RE["返回内容"] = neirong;


                //定义中途取消
                cts.Token.ThrowIfCancellationRequested();
            }
            catch (TaskCanceledException)
            {
                RE["访问错误"] = "请求被取消。";
            }
            catch (Exception ex)
            {
                RE["访问错误"] = "其他意外错误：" + ex.Message;
            }
            return RE;
        
        
        }
 





 

        /// <summary>
        /// 中断一个正在进行的请求
        /// </summary>
        public void HttpGetText_Cancel()
        {
            //取消请求，并实例化一个新的待选任务
            cts.Cancel();
            cts.Dispose();
            cts = new CancellationTokenSource();
        }

 
        public void Dispose()
        {
            if (filter != null)
            {
                filter.Dispose();
                filter = null;
            }

            if (httpClient != null)
            {
                httpClient.Dispose();
                httpClient = null;
            }

            if (cts != null)
            {
                cts.Dispose();
                cts = null;
            }
        }

    }
}

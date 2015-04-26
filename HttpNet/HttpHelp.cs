using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;

namespace Hatohalo.HttpNet
{
 

    internal static class HttpHelp
    {
        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }

        /// <summary>
        /// 获得本地网卡上所有的ip地址。(需要改改)
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            string strIPAddress = null;
            List<string> arrayIPAddress = new List<string>();
            // Windows.Networking.Connectivity.
            var hostNames = Windows.Networking.Connectivity.NetworkInformation.GetHostNames();
            foreach (var hn in hostNames)
            {
                if (hn.IPInformation != null)
                {
                    string ipAddress = hn.DisplayName;
                    arrayIPAddress.Add(ipAddress);
                }
            }
            if (arrayIPAddress.Count < 1)
            {
                return null;
            }
            if (arrayIPAddress.Count == 1)
            {
                strIPAddress = arrayIPAddress[0];
            }
            if (arrayIPAddress.Count > 1)
            {
                strIPAddress = arrayIPAddress[arrayIPAddress.Count - 1];
            }
            // System.Console.WriteLine();
            for (int i = 0; i < arrayIPAddress.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("No.{0} host IP is: {1}", i + 1, arrayIPAddress[i]);
            }
            return strIPAddress;
        }

        /// <summary>
        /// 序列化返回的头部消息
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static string SerializeHeaders(HttpResponseMessage response)
        {
            StringBuilder output = new StringBuilder();
            output.Append(((int)response.StatusCode) + " " + response.ReasonPhrase + "\r\n");

            SerializeHeaderCollection(response.Headers, output);
            SerializeHeaderCollection(response.Content.Headers, output);
            output.Append("\r\n");
            return output.ToString();
        }

        /// <summary>
        /// 将头部信息转化成StringBuilder
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="output"></param>
        internal static void SerializeHeaderCollection(
            IEnumerable<KeyValuePair<string, string>> headers,
            StringBuilder output)
        {
            foreach (var header in headers)
            {
                output.Append(header.Key + ": " + header.Value + "\r\n");
            }
        }

        /// <summary>
        /// 将byete[]转化成图像类型，便于界面上使用
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        internal async static Task<BitmapImage> Byte2Bitmap(byte[] b)
        {
            BitmapImage bitImg = new BitmapImage();
            try
            {
            InMemoryRandomAccessStream memoryStream = new InMemoryRandomAccessStream();
            DataWriter datawriter = new DataWriter(memoryStream.GetOutputStreamAt(0));
            datawriter.WriteBytes(b);
            await datawriter.StoreAsync();

       

                await bitImg.SetSourceAsync(memoryStream);
            }
            catch
            {
                return new BitmapImage();
            }
        
            return bitImg;
        }

    


        /// <summary>
        /// 检测url是否合法，并创建实例
        /// </summary>
        /// <param name="uriString">url字符串</param>
        /// <param name="uri">创建后的url实例(输出)</param>
        /// <returns>返回是否创建成功</returns>
        internal static bool TryGetUri(string uriString, out Uri uri)
        {
            //判定是否能够根据url字符串，构建一个可用的url实例。 值允许绝对url，也就是完整的带有网址host的地址。
            if (!Uri.TryCreate(uriString.Trim(), UriKind.Absolute, out uri))
            {
                return false;
            }
            //只允许http和https协议。
            if (uri.Scheme != "http" && uri.Scheme != "https")
            {
                return false;
            }

            return true;
        }







        /// <summary>
        /// 保存远程url地址图片,到本地
        /// </summary>
        /// <param name="uri">远程地址</param>
        /// <param name="filename">保存的名称</param>
        /// <param name="folder">保存位置枚举</param>
        /// <returns></returns>
        internal async static Task SaveImageFromUrl(string uri, string filename, StorageFolder folder)
        {

            var rass = RandomAccessStreamReference.CreateFromUri(new Uri(uri));
            IRandomAccessStream inputStream = await rass.OpenReadAsync();
            Stream input = WindowsRuntimeStreamExtensions.AsStreamForRead(inputStream.GetInputStreamAt(0));
            try
            {
                //获取图片扩展名的Guid
                StorageFile outputFile = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                using (IRandomAccessStream outputStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    Stream output = WindowsRuntimeStreamExtensions.AsStreamForWrite(outputStream.GetOutputStreamAt(0));
                    await input.CopyToAsync(output);
                    output.Dispose();
                    input.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// FileName转换为Stream，图片可为本地图片，也可为应用程序中图片
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        internal async static Task<Stream> ImageNameToStream(string filename)
        {
            try
            {
                ////本地图片库
                //StorageFolder folder = KnownFolders.PicturesLibrary;//本地图片库
                //StorageFile storagefile = await folder.GetFileAsync(filename);

                //应用程序Images文件夹图片
                Uri _baseUri = new Uri("ms-appx:///");
                Uri uri = new Uri(_baseUri, "../Images/" + filename);
                StorageFile storagefile = await StorageFile.GetFileFromApplicationUriAsync(uri);


                IRandomAccessStream irandom = await storagefile.OpenAsync(FileAccessMode.Read);
                Stream outPutstream = irandom.GetInputStreamAt(0).AsStreamForRead();
                return outPutstream;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 流转换成本地图片
        /// </summary>
        /// <param name="inputstream"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        internal async static Task StreamToFileName(Stream inputstream, string filename)
        {
            try
            {
                StorageFolder folder = KnownFolders.SavedPictures;
                StorageFile outputFile = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                using (IRandomAccessStream output = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    Stream outputstream = WindowsRuntimeStreamExtensions.AsStreamForWrite(output.GetOutputStreamAt(0));
                    await inputstream.CopyToAsync(outputstream);
                    outputstream.Dispose();
                    inputstream.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 网络图片Uri转换成流
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        internal async static Task<Stream> UriToStream(string uri)
        {
            var rass = RandomAccessStreamReference.CreateFromUri(new Uri(uri));
            IRandomAccessStream inputStream = await rass.OpenReadAsync();
            Stream input = WindowsRuntimeStreamExtensions.AsStreamForRead(inputStream.GetInputStreamAt(0));
            return input;
        }


        /// <summary>
        /// 用于保存数据库
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        internal static string ToJsonForDB(this string s)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {

                char c = s.ToCharArray()[i];

                switch (c)
                {

                    case '\"': sb.Append(""); break;

                    case '\\': sb.Append(""); break;

                    case '/': sb.Append(""); break;

                    case '\b': sb.Append(""); break;

                    case '\f': sb.Append(""); break;

                    case '\n': sb.Append(""); break;

                    case '\r': sb.Append(""); break;

                    case '\t': sb.Append(""); break;

                    default: sb.Append(c); break;

                }

            }

            return sb.ToString();

        }

        /**/
        ///   <summary>   
        ///   去除HTML标记   
        ///   </summary>   
        ///   <param   name="NoHTML">包括HTML的源码   </param>   
        ///   <param   name="PtoB">是否将P标签处，替换成[※]分割</param>  
        ///   <returns>已经去除后的文字</returns>   
        internal static string NoHTML(string Htmlstring)
        {
            //去掉后续特殊处理要用的特殊字符
            Htmlstring = Htmlstring.Replace("※", "");
            Htmlstring = Htmlstring.Replace("№", "");
            Htmlstring = Htmlstring.Replace("€", "");
            Htmlstring = Htmlstring.Replace("¤", "");



            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
 

            return Htmlstring;
        }



       


    }
}

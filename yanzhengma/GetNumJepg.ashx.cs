using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web;

namespace yanzhengma
{
    /// <summary>
    /// GetNumJepg 的摘要说明
    /// </summary>
    public class GetNumJepg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //准备画布
            Bitmap bitmap = new Bitmap(100, 50);
            //拿到画笔
            Graphics graphics = Graphics.FromImage(bitmap);

            //定义字符串
            string temp = "1234567890abcdefghijklmnopqrstuvwxyz";

            //定义验证码大小
            int len = 6;
            StringBuilder stringBuilder = new StringBuilder("");

            Random random = new Random();
            for (int i = 0; i < len; i++) {

                int index = random.Next(0, stringBuilder.Length);

                string str = temp[index].ToString();

                stringBuilder.Append(str);

            }
            graphics.DrawString(stringBuilder.ToString(), new Font("黑体", 20), new SolidBrush(Color.Yellow), 0, 0); ;
           
            bitmap.Save(context.Response.OutputStream,ImageFormat.Jpeg);


           
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
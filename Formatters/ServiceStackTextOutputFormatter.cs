using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using ServiceStack.Text;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceJsonFormatter.Formatters
{
    // add package ServiceStack.Text
    public class ServiceStackTextOutputFormatter : TextOutputFormatter
    {
        public ServiceStackTextOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true));
            SupportedEncodings.Add(new UnicodeEncoding(bigEndian: false, byteOrderMark: true, throwOnInvalidBytes: true));

        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            return Task.Run(()=>JsonSerializer.SerializeToStream(context.Object, context.ObjectType, context.HttpContext.Response.Body));
        }
    }
}

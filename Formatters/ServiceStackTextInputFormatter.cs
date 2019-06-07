using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using ServiceStack.Text;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceJsonFormatter.Formatters
{
    public class ServiceStackTextInputFormatter : TextInputFormatter
    {
        public ServiceStackTextInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true));
            SupportedEncodings.Add(new UnicodeEncoding(bigEndian: false, byteOrderMark: true, throwOnInvalidBytes: true));
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            try
            {
                var model = await JsonSerializer.DeserializeFromStreamAsync(context.ModelType, context.HttpContext.Request.Body);

                return await InputFormatterResult.SuccessAsync(model);
            }
            catch(Exception)
            {
                return await InputFormatterResult.FailureAsync();
            }
           

        }
    }
}

using Microsoft.AspNetCore.Http;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pine.Services
{
   public class FileService : IFileService
    {
        public byte[] ConvertToByte(IFormFile img)
        {
            byte[] result = new byte[0];
            if (img != null)
            {
                if (img.Length > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = img.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    result = p1;                
                }
            }
            return result;
        }
    }
}
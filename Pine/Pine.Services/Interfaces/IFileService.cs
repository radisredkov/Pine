using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Services.Interfaces
{
    public interface IFileService
    {
        public byte[] ConvertToByte(IFormFile img);
    }
}

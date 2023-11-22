using Microsoft.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLApps.Capstone.Encriptado.Transversal.Common.Constants
{
    public class AppRecyclabeMemoryStream
    {
        public static readonly RecyclableMemoryStreamManager Manager = new RecyclableMemoryStreamManager();
    }
}

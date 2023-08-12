using System;
using System.Collections.Generic;


namespace SystemInventory.Classes
{
    public class ResponseQuery
    {
        public bool StatusQuery { get; set; }
        public List<string> MessageQuery { get; set; } = new List<string>() { string.Empty};
        public Object Result { get; set; }
    }
}

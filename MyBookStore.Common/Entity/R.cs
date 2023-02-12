using System.Collections.Generic;
using MyBookStore.Common.constant;

namespace MyBookStore.Common.Entity
{
    /**
     * author: xiaotian li
     * standard result/response plain class
     */
    public class R : Dictionary<string, object>
    {
        // keys
        public const string MSG = "msg";
        public const string CODE = "code";
        public const string DATA = "data";

        public R()
        {
            // generate ok status code by default
            Put(CODE, ExceptionEnum.OK.GetStatusCode());
            Put(MSG, ExceptionEnum.OK.GetString());
        }

        public static R Error()
        {
            return Error(ExceptionEnum.SERVER_INTERNAL_ERROR.GetStatusCode(), ExceptionEnum.SERVER_INTERNAL_ERROR.GetString());
        }
        
        public static R Error(string msg)
        {
            return Error(ExceptionEnum.SERVER_INTERNAL_ERROR.GetStatusCode(), msg);
        }

        public static R Error(int code, string msg)
        {
            R r = new R();
            r.Put(CODE, code);
            r.Put(MSG, msg);
            return r;
        }

        public static R Ok()
        {
            return new R();
        }

        public static R Ok(string str)
        {
            R r = new R();
            r.Put(MSG, str);
            return r;
        }

        public int GetCode()
        {
            return (int)this[CODE];
        }

        public R SetData(object data)
        {
            Put(DATA, data);
            return this;
        }
        
        public R Put(string key, object value)
        {
            base.Add(key, value);
            return this;
        }
    }
}
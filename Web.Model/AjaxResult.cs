namespace Web.Model
{
    public class AjaxResult<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public T data { get; set; }
        public int? total { get; set; }

        private static AjaxResult<T> Message(int code, string message, int? total, T data)
        {
            return new() {code = code, message = message, total = total, data = data};
        }

        public static AjaxResult<T> Success()
        {
            return Message(200, "操作成功", null, default);
        }

        public static AjaxResult<T> Success(int total)
        {
            return Message(200, "操作成功", total, default);
        }

        public static AjaxResult<T> Success(T data)
        {
            return Message(200, "操作成功", 1, data);
        }

        public static AjaxResult<T> Success(int total, T data)
        {
            return Message(200, "操作成功", total, data);
        }
    }
}
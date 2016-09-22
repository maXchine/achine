namespace Achine.Common.Data.Entity
{
    /// <summary>
    /// 排序方式
    /// </summary>
    public enum OrderBy
    {

        /// <summary>
        ///     升序
        /// </summary>
        Acsending = 0,


        /// <summary>
        ///     降序
        /// </summary>
        Descending = 1
    }

    public static class OrderEx
    {
        public static bool IsAcsending(this OrderBy o)
        {
            return o == OrderBy.Acsending;
        }

        public static bool IsDescending(this OrderBy o)
        {
            return o == OrderBy.Descending;
        }
    }
}

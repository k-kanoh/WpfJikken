namespace WpfJikken6
{
    public static class Util
    {
        /// <summary>
        /// オブジェクトを比較しプロパティをシャローコピーします。(requiredはコピー対象外)
        /// </summary>
        public static void ShallowCopy(object sourceObj, object destObj)
        {
            var joinedProps = from source in sourceObj.GetType().GetProperties()
                              join dest in destObj.GetType().GetProperties()
                              on source.Name equals dest.Name
                              select new { source, dest };

            foreach (var pair in joinedProps)
                if (pair.dest.CanWrite && pair.source.CanRead && !pair.dest.IsRequired())
                    pair.dest.SetValue(destObj, pair.source.GetValue(sourceObj));
        }
    }
}

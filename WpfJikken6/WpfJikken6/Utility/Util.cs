using Csv;
using WpfJikken6.Utility;

namespace WpfJikken6
{
    public static class Util
    {
        /// <summary>
        /// オブジェクトを比較して同じ名前のプロパティの値をコピーします。
        /// Required修飾子が付与されたプロパティはコピー対象外です。
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

        /// <summary>
        /// Csv文字列をパースしてTのリストに変換します。
        /// </summary>
        public static List<T> CsvRead<T>(IEnumerable<string> lines, bool skipHeaderRow = false) where T : new()
        {
            var props = from p in typeof(T).GetProperties()
                        let attr = p.FirstCustomAttribute<CsvFieldAttribute>()
                        where attr != null
                        select new { prop = p, attr.FieldNo };

            var list = new List<T>();

            var options = new CsvOptions()
            {
                SkipRow = (row, idx) => row.Span.IsEmpty,
                TrimData = true,
                HeaderMode = skipHeaderRow ? HeaderMode.HeaderAbsent : HeaderMode.HeaderPresent
            };

            foreach (var line in CsvReader.ReadFromText(string.Join("\r\n", lines), options))
            {
                var instance = new T();

                foreach (var p in props)
                    p.prop.SetValue(instance, line[p.FieldNo]);

                list.Add(instance);
            }

            return list;
        }

        /// <summary>
        /// オブジェクトのリストをCsv文字列に変換します。
        /// </summary>
        public static string CsvWrite<T>(IEnumerable<T> data, bool skipHeaderRow = false) where T : notnull
        {
            var headers = from p in typeof(T).GetProperties()
                          let attr = p.FirstCustomAttribute<CsvFieldAttribute>()
                          where attr != null
                          orderby attr.FieldNo
                          select p.Name;

            var contents = data.Select(x => (from p in x.GetType().GetProperties()
                                             let attr = p.FirstCustomAttribute<CsvFieldAttribute>()
                                             where attr != null
                                             orderby attr.FieldNo
                                             select (string)(p.GetValue(x) ?? "")).ToArray());

            return CsvWriter.WriteToText(headers.ToArray(), contents, skipHeaderRow: skipHeaderRow);
        }
    }
}

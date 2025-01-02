using WpfJikken6.Poco;

namespace WpfJikken6.Model
{
    public class MonsterGridRowModel
    {
        public required MasterItem Monster { get; set; }

        public required ParamDefModels Defs { get; set; }
    }
}

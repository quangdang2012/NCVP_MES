using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class MasterMntCommonInVo : ValueObject
    {
        /// <summary>
        /// get and set TargetCbm
        /// </summary>
        public CbmController TargetCbm { get; set; }

        /// <summary>
        /// get and set TargetInVo
        /// </summary>
        public ValueObject TargetInVo { get; set; }

        /// <summary>
        /// get and set IsLogging
        /// </summary>
        public bool IsLogging { get; set; }
    }
}

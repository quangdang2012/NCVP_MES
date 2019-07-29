using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class PaletteVo : ValueObject
    {
        /// <summary>
        /// get and set PaletteId
        /// </summary>
        public int PaletteId { get; set; }

        /// <summary>
        /// get and set PaletteCode
        /// </summary>
        public string PaletteCode { get; set; }

        /// <summary>
        /// get and set PaletteName
        /// </summary>
        public string PaletteName { get; set; }

        /// <summary>
        /// get and set AreaId
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// get and set AreaName
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set FactoryCode
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set list PaletteVo
        /// </summary>
        public List<PaletteVo> PaletteListVo = new List<PaletteVo>();

    }
}

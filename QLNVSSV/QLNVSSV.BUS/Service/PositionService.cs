using QLNVSSV.BUS.Interfaces;
using QLNVSSV.DATA.Interfaces;
using QLNVSSV.DATA.Repository;
using QLNVSSV.Models.Modes;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNVSSV.BUS.Service
{
    public class PositionService : BaseService<Position>,IPositionService
    {
        protected IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository):base(positionRepository)
        {
            _positionRepository = positionRepository;
        }
    }
}

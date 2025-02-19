﻿using Contracts;

namespace ContractConfigurator.LRTR
{
    public class LRTRReturnHomeFactory : ParameterFactory
    {
        protected string landAtFacility;
        protected double maxSpeed;

        public override bool Load(ConfigNode configNode)
        {
            bool valid = base.Load(configNode);

            valid &= ConfigNodeUtil.ParseValue(configNode, "landAtFacility", x => landAtFacility = x, this, string.Empty);
            valid &= ConfigNodeUtil.ParseValue(configNode, "maxSpeed", x => maxSpeed = x, this, LRTRReturnHome.DefaultMaxSpeed);

            return valid;
        }

        public override ContractParameter Generate(Contract contract)
        {
            return new LRTRReturnHome(title, landAtFacility, maxSpeed);
        }
    }
}

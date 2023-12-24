using System.Collections.Generic;
using Model.ShipModel;
using Model.ShipModel.ShipData;
using NSubstitute;

namespace Tests.Presenter
{
    public static class ShipPresenterFixture
    {
        public static IShipDeteriorationConfiguration ShipDeteriorationConfiguration
        {
            get
            {
                var shipDeteriorationDefinitionHealthy = Substitute.For<IShipDeteriorationDefinition>();
                shipDeteriorationDefinitionHealthy.Health.Returns(100f);
                shipDeteriorationDefinitionHealthy.Deterioration.Returns(ShipDeterioration.Healthy);

                var shipDeteriorationDefinitionDamaged = Substitute.For<IShipDeteriorationDefinition>();
                shipDeteriorationDefinitionDamaged.Health.Returns(50);
                shipDeteriorationDefinitionDamaged.Deterioration.Returns(ShipDeterioration.Damaged);

                var shipDeteriorationDefinitionCritical = Substitute.For<IShipDeteriorationDefinition>();
                shipDeteriorationDefinitionCritical.Health.Returns(25f);
                shipDeteriorationDefinitionCritical.Deterioration.Returns(ShipDeterioration.Critical);

                var shipDeteriorationDefinitionDestroyed = Substitute.For<IShipDeteriorationDefinition>();
                shipDeteriorationDefinitionDestroyed.Health.Returns(0f);
                shipDeteriorationDefinitionDestroyed.Deterioration.Returns(ShipDeterioration.Destroyed);

                var deteriorationConfiguration = Substitute.For<IShipDeteriorationConfiguration>();

                deteriorationConfiguration.DeteriorationDefinitions.Returns(new List<IShipDeteriorationDefinition>
                {
                    shipDeteriorationDefinitionHealthy,
                    shipDeteriorationDefinitionDamaged,
                    shipDeteriorationDefinitionCritical,
                    shipDeteriorationDefinitionDestroyed
                });

                return deteriorationConfiguration;
            }
        }
    }
}
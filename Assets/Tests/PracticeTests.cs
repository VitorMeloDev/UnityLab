using System.Collections.Generic;
using NUnit.Framework;
using VMGames.Core.Practice;

namespace VMGames.Core.Tests
{
    [TestFixture]
    public class PracticeTests
    {
        private PlayerProfile _player;

        [SetUp]
        public void Setup()
        {
            _player = new PlayerProfile
            {
                PlayerName = "TestPlayer",
                Level = 10
            };
        }

        [Test]
        public void FindItem_WhenItemExists_ReturnsItem()
        {
            // Arrange (Preparação)
            var sword = new InventoryItem { Id = "iron_sword", Quantity = 1, Weight = 3.5f, IsEquipped = true };
            _player.Inventory.Add(sword);

            // Act (Ação)
            InventoryItem result = _player.FindItem("iron_sword");

            // Assert (Verificações variadas de tipos e existencia)
            Assert.IsNotNull(result, "O item deveria existir no inventário.");
            Assert.AreEqual("iron_sword", result.Id, "O ID recuperado deve ser idêntico ao cadastrado.");
            Assert.AreEqual(1, result.Quantity, "A quantidade do item deve ser do tipo int exato.");
            Assert.IsTrue(result.IsEquipped, "O item deveria estar marcado como equipado.");     

            // Asserção com float (usamos a margem de tolerância/delta por causa de arredondamentos de ponto flutuante)
            Assert.AreEqual(3.5f, result.Weight, 0.001f, "O peso deve ser validado com margem para precisão de float.");
        }

        [Test]
        public void FindItem_WhenItemDoesNotExist_ReturnsNull()
        {
            // Act
            InventoryItem result = _player.FindItem("non_existent_item");

            // Assert (Checando ausência / inexistência)
            Assert.IsNull(result, "Buscar um item inexistente deve retornar null explicitamente.");
        }

        [Test]
        public void HasSpaceFor_WhenCapacityExceeded_ReturnsFalse()
        {
            // Arrange
            _player.Inventory.Add(new InventoryItem { Id = "heavy_potion", Quantity = 5, Weight = 2.0f }); // Peso total = 10.0f
            float newContainerWeight = 1.0f;
            float maxCapacity = 10.5f;

            // Act
            bool canCarry = _player.HasSpaceFor(newContainerWeight, maxCapacity);

            // Assert
            Assert.IsFalse(canCarry, "Não deve permitir carregar itens que ultrapassem a capacidade máxima.");
        }

        [Test]
        public void InventoryCollection_WhenInitialized_IsNotNullAndEmpty()
        {
            // Assert (Checando coleções no estado inicial)
            Assert.IsNotNull(_player.Inventory, "A lista de inventário deve ser inicializada na memória.");
            Assert.IsEmpty(_player.Inventory, "O inventário de um novo perfil deve começar sem elementos.");
            Assert.AreEqual(0, _player.Inventory.Count, "O contador da lista deve ser exatamente 0.");
        }
    }
}
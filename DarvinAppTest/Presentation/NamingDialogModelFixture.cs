﻿using System;
using System.Resources;
using DarvinApp.Business.DataTypes;
using DarvinApp.Business.Repository;
using DarvinApp.Presentation;
using GalaSoft.MvvmLight.Messaging;
using NSubstitute;
using NUnit.Framework;

namespace DarvinAppTest.Presentation
{
    [TestFixture]
    public class NamingDialogModelFixture
    {
        [Test]
        public void AnimalSavingCommand_ExpectedICommand()
        {
            var victim = new NamingDialogModel(Substitute.For<IAnimalRepository>(), 42,
                                               Substitute.For<ResourceManager>(), Substitute.For<Messenger>());
            Assert.NotNull(victim.AnimalSavingCommand);
        }

        [Test]
        public void NamingDialog_OneOfParametersExceptTokenIsNull_ExpectedANE()
        {
            Assert.Throws<ArgumentNullException>(() => new NamingDialogModel(null, Arg.Any<object>(), null, null));

            Assert.Throws<ArgumentNullException>(
                () => new NamingDialogModel(Substitute.For<IAnimalRepository>(), Arg.Any<object>(), null, null));

            Assert.Throws<ArgumentNullException>(
                () => new NamingDialogModel(null, Arg.Any<object>(), Substitute.For<ResourceManager>(), null));
        }

        [TestCase(AnimalType.Emperors)]
        [TestCase(AnimalType.FlowerVaseBreakers)]
        public void NotificationGot_ValidTypeName_ExpectedRightAnimalType(AnimalType animalType)
        {
            //Arrange
            String animalTypeString = animalType.ToString();
            var animalNamingStub = Substitute.For<ResourceManager>();
            var victim = new NamingDialogModel(Substitute.For<IAnimalRepository>(), 42,
                                               animalNamingStub, Substitute.For<Messenger>());

            //Act
            Messenger.Default.Send(new NotificationMessage(animalTypeString), 42);

            //Assert
            Assert.AreEqual(animalNamingStub.GetString(animalTypeString), victim.AnimalTypeName);
        }

        [Test]
        public void SaveAnimal_SendsMessage()
        {
            var goodMessengerMock = Substitute.For<IMessenger>();
            var victim = new NamingDialogModel(Substitute.For<IAnimalRepository>(), 42,
                                               Substitute.For<ResourceManager>(), goodMessengerMock);

            var cmd = victim.AnimalSavingCommand;

            cmd.Execute(null);
            goodMessengerMock.Received(1).Send(Arg.Any<object>());
        }
    }
}
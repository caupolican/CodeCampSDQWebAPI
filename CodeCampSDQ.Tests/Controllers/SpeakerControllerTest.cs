using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeCampSDQ;
using CodeCampSDQ.Controllers;
using CodeCampSDQ.Models;

namespace CodeCampSDQ.Tests.Controllers
{
    [TestClass]
    public class SpeakerControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            SpeakerController controller = new SpeakerController();

            // Act
            IEnumerable<Speaker> result = controller.GetSpeakers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Caupolican Nunez", result.ElementAt(0).Name);
            Assert.AreEqual("cao", result.ElementAt(1).TwitterHandle);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            SpeakerController controller = new SpeakerController();

            // Act
            Speaker result = controller.GetSpeaker(1);

            // Assert
            Assert.AreEqual("value", result);
        }

        //[TestMethod]
        //public void Post()
        //{
        //    // Arrange
        //    SpeakerController controller = new SpeakerController();

        //    // Act
        //    controller.Post(new Speaker {
        //         Name = "Tolete McGuee",
        //          TwitterHandle = "Toletazo",
        //           Bio = "Born on mordor"
        //    });

        //    // Assert
        //}

        //[TestMethod]
        //public void Put()
        //{
        //    // Arrange
        //    SpeakerController controller = new SpeakerController();

        //    // Act
        //    controller.Put(5, "value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Delete()
        //{
        //    // Arrange
        //    SpeakerController controller = new SpeakerController();

        //    // Act
        //    controller.Delete(5);

        //    // Assert
        //}
    }
}

using System;
using NUnit.Framework;
using Newtonsoft.Json.Converters;

namespace Newtonsoft.Json.Tests.Converters
{
    public class VersionConverterTests : TestFixtureBase
    {
        public class VersionClass
        {
            public Version VersionValue { get; set; }
        }

        [Test]
        public void SerializeVersionClass_MajorMinorBuildRevision()
        {
            VersionClass versionClass = new VersionClass();
            versionClass.VersionValue = new Version(1, 2, 3, 4);

            string json = JsonConvert.SerializeObject(versionClass, Formatting.Indented, new VersionConverter());

            Assert.AreEqual(@"{
  ""VersionValue"": ""1.2.3.4""
}", json);
        }

        [Test]
        public void SerializeVersionClass_MajorMinorBuild()
        {
            VersionClass versionClass = new VersionClass();
            versionClass.VersionValue = new Version(1, 2, 3);

            string json = JsonConvert.SerializeObject(versionClass, Formatting.Indented, new VersionConverter());

            Assert.AreEqual(@"{
  ""VersionValue"": ""1.2.3""
}", json);
        }

        [Test]
        public void SerializeVersionClass_MajorMinor()
        {
            VersionClass versionClass = new VersionClass();
            versionClass.VersionValue = new Version(1, 2);

            string json = JsonConvert.SerializeObject(versionClass, Formatting.Indented, new VersionConverter());

            Assert.AreEqual(@"{
  ""VersionValue"": ""1.2""
}", json);
        }

        [Test]
        public void SerializeVersionClass_Null()
        {
            VersionClass versionClass = new VersionClass();
            versionClass.VersionValue = null;

            string json = JsonConvert.SerializeObject(versionClass, Formatting.Indented, new VersionConverter());

            Assert.AreEqual(@"{
  ""VersionValue"": null
}", json);
        }
    }
}
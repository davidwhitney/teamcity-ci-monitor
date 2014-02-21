﻿using System;
using NUnit.Framework;
using website.Application.Services.DataProtection;

namespace Website.Test.Unit.Application.Services.DataProtection
{
    [TestFixture]
    public class ProtectorTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void CanProtectValue()
        {
            var protector = new Protector();
            var protectedValue = protector.Protect("a value");
            Assert.NotNull(protectedValue);
            Assert.AreNotEqual("a value", protectedValue);
        }

        [Test]
        public void ProtectNullValueReturnsNull()
        {
            var protector = new Protector();
            Assert.IsNull(protector.Protect(null));
        }

        [Test]
        public void UnprotectNullValueReturnsNull()
        {
            var protector = new Protector();
            Assert.IsNull(protector.Unprotect(null));
        }
        
       [Test]
       public void CanUnprotectValue()
        {
            var protector = new Protector();
            var protectedValue = protector.Protect("a value");

            var unprotectedValue = protector.Unprotect(protectedValue);

            Assert.NotNull(protectedValue);
            Assert.That(unprotectedValue, Is.EqualTo("a value"));
        }


        [Test]
        public void CanGenerateKey()
        {
            var protector = new Protector();
            var key = protector.GenerateKey(1);
            Assert.NotNull(key);
        }

        [TestCase(-1, 0)]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(64, 64)]
        [TestCase(65, 64)]
        public void GenerateKeyCreatesKeyWithCorrectLength(int length, int expected)
        {
            var protector = new Protector();
            var key = protector.GenerateKey(length);
            Assert.That(key.Length, Is.EqualTo(expected));
            
        }
    }
}

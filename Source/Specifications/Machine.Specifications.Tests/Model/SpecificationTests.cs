﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Machine.Specifications.Factories;
using Machine.Testing;
using NUnit.Framework;

namespace Machine.Specifications.Model
{
  [TestFixture]
  public class SpecificationTests : With<SpecificationWithSingleRequirement>
  {
    public override void BeforeEachTest()
    {
      base.BeforeEachTest();
      var results = description.Verify();
    }

    [Test]
    public void ShouldCallWhen()
    {
      SpecificationWithSingleRequirement.WhenInvoked.ShouldBeTrue();
    }

    [Test]
    public void ShouldCallBeforeAll()
    {
      SpecificationWithSingleRequirement.BeforeAllInvoked.ShouldBeTrue();
    }

    [Test]
    public void ShouldCallBeforeEach()
    {
      SpecificationWithSingleRequirement.BeforeEachInvoked.ShouldBeTrue();
    }

    [Test]
    public void ShouldCallAfterEach()
    {
      SpecificationWithSingleRequirement.AfterEachInvoked.ShouldBeTrue();
    }

    [Test]
    public void ShouldCallAfterAll()
    {
      SpecificationWithSingleRequirement.AfterAllInvoked.ShouldBeTrue();
    }
  }

  public class With<T> : TestsFor<DescriptionFactory> where T : IFakeSpecification, new()
  {
    protected Description description;
    public override void BeforeEachTest()
    {
      IFakeSpecification fakeSpecification = new T();
      fakeSpecification.Reset();

      description = Target.CreateSpecificationFrom(fakeSpecification);
    }
  }
}
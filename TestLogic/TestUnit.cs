using System;
using Xunit;
using Logic;
using System.Collections.Generic;

namespace TestLogic
{
    public class TestUnit
    {
        [Fact]
        public void TestConstructor()
        {
            Unit u1 = new Unit();
        }

        [Fact]
        public void TestListModules()
        {
            Unit u1 = new Unit();
            //Liste des modules pas nulle
            Assert.NotNull(u1.ListModules());
            Assert.Empty(u1.ListModules());
        }

        [Fact]
        public void TestAddModules()
        {
            Unit u1 = new Unit();
            Module m1 = new Module();
            Module m2 = new Module();
            u1.Add(m1);
            u1.Add(m2);
            Assert.Equal(2 ,u1.ListModules().Length);
            Assert.Same(u1.ListModules()[0], m1);
        }

        [Fact]
        public void TestRemoveModule()
        {
            Unit u = new Unit();
            Module m1 = new Module();
            u.Add(m1);
            //list must be not empty
            Assert.NotEmpty(u.ListModules());
            u.Remove(m1);
            //list must be empty after removing
            Assert.Empty(u.ListModules());
        }

        [Fact]
        public void TestComputeAverages()
        {
            Unit u = new Unit();
            List<Exam> exams = new List<Exam>();

            //Unit contains no module
            Assert.Empty(u.ComputeAverages(exams.ToArray()));

            //Unit contains modules with no average
            Module m0 = new Module
            {
                Name = "m0"
            };
            Module m1 = new Module()
            {
                Name = "m1"
            };
            u.Add(m0);
            u.Add(m1);
            Assert.Empty(u.ComputeAverages(exams.ToArray()));

            //Unit contains one module with average and other with no average
            Module m2 = new Module()
            {
                Name = "m2"
            };
            Exam e1 = new Exam();
            e1.Score = 14;
            e1.Coef = 2;
            e1.Module = m2;
            exams.Add(e1);
            u.Add(m2);
            Assert.Null(u.ComputeAverages(exams.ToArray())[0]);
            Assert.Null(u.ComputeAverages(exams.ToArray())[1]);
            Assert.Equal(14f, u.ComputeAverages(exams.ToArray())[2].Average, 2);

            //Unit contains several modules with average
            Module m3 = new Module();
            Exam e2 = new Exam();
            e2.Score = 16;
            e2.Coef = 3;
            e2.Module = m3;
            exams.Add(e2);
            u.Add(m3);
            Assert.Equal(16f, u.ComputeAverages(exams.ToArray())[3].Average, 2);
        }

        [Fact]
        public void TestEquals()
        {
            Unit u1 = new Unit()
            {
                Name = "test",
                Coef = 3
            };
            u1.Add(new Module());
            Unit u2 = new Unit()
            {
                Name = "test",
                Coef = 3
            };
            u2.Add(new Module());
            Assert.Equal(u1, u2);
            Module m3 = new Module()
            {
                Coef = 3,
                Name = "maths"
            };
            u1.Add(m3);
            Assert.NotEqual(u1, u2);
        }
    }
}

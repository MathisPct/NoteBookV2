using System;
using System.Collections.Generic;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestNoteBook
    {
        [Fact]
        public void TestListUnits()
        {
            //Instantiation 
            NoteBook nB = new NoteBook();

            Assert.NotNull(nB.ListUnits());
            Assert.Empty(nB.ListUnits());
        }

        [Fact]
        public void AddUnit()
        {
            //test of add element
            NoteBook nb = new NoteBook();
            Unit u = new Unit();
            u.Coef = 2;
            u.Name = "Méthodes";
            nb.AddUnit(u);
            Assert.True(nb.ListUnits()[0] == u);

            //test of add an element which already exists in list of units
            Assert.Throws<Exception>(() => { nb.AddUnit(u); });
            Unit u2 = new Unit();
            u2.Name = "test";
            u2.Coef = 3;
            Unit u3 = new Unit();
            u3.Coef = 3;
            u3.Name = "test";
            nb.AddUnit(u2);
            Assert.Throws<Exception>(() => { nb.AddUnit(u3); });
        }

        [Fact]
        public void RemoveUnit()
        {
            NoteBook nb = new NoteBook();
            Unit u = new Unit();
            nb.AddUnit(u);
            nb.RemoveUnit(u);
            Assert.Empty(nb.ListUnits());
        }

        [Fact]
        public void ListModules()
        {
            NoteBook nb = new NoteBook();
            //create two different units 
            Unit u1 = new Unit();
            u1.Name = "u1";
            Unit u2 = new Unit();
            u2.Name = "u2";
            nb.AddUnit(u1);
            nb.AddUnit(u2);
            //add modules in each of units
            Module m1 = new Module();
            Module m2 = new Module();
            u1.Add(m1);
            u2.Add(m2);
            //list of modules which is except
            List<Module> modulesExcept = new List<Module>();
            modulesExcept.Add(m1);
            modulesExcept.Add(m2);
            
            Assert.NotNull(nb.ListModules());
            Assert.Equal(modulesExcept.ToArray(), nb.ListModules());
        }

        [Fact]
        public void AddExam()
        {
            NoteBook nb = new NoteBook();
            Exam exam1 = new Exam();
            Exam exam2 = new Exam()
            {
                Coef = 2,
                Teacher = "eeze"
            };
            nb.AddExam(exam1);
            Assert.Single(nb.ListExams());
            //test if exam has been added
            Assert.Same(nb.ListExams()[0], exam1);
            //test if second exam has been added
            nb.AddExam(exam2);
            Assert.Equal(2, nb.ListExams().Length);
            Assert.Same(nb.ListExams()[1], exam2);
            ////test add same exams
            //Assert.Throws<Exception>(() => { nb.AddExam(exam1); });
        }

        [Fact]
        public void ListExam()
        {
            NoteBook nb = new NoteBook();
            Assert.NotNull(nb.ListExams());
            Assert.Empty(nb.ListExams());


        }

        [Fact]
        public void RemoveExams()
        {
            NoteBook nb = new NoteBook();
            Module maths = new Module()
            {
                Coef = 3,
                Name = "maths"
            };
            Exam exam1 = new Exam()
            {
                Module = maths
            };
            //test with one exam
            nb.AddExam(exam1);
            Assert.Equal(1, nb.RemoveExams(maths));
            Assert.Empty(nb.ListExams());
            //test with two exams
            Exam exam2 = new Exam()
            {
                Module = maths
            };
            nb.AddExam(exam2);
            Exam exam3 = new Exam()
            {
                Module = maths
            };
            nb.AddExam(exam3);
            Assert.Equal(2, nb.RemoveExams(maths));
            Assert.Empty(nb.ListExams());
        }
        
        [Fact]
        public void RemoveExam()
        {
            NoteBook nb = new NoteBook();
            Exam e = new Exam();
            nb.AddExam(e);
            nb.RemoveExam(e);
            Assert.Empty(nb.ListUnits());

            //exam which not exist in list of exams
            Assert.Throws<Exception>(() => { nb.RemoveExam(e); });
        }

        [Fact]
        public void ComputeScores()
        {
            NoteBook nb = new NoteBook();
            //verify if global average has been not added
            Assert.NotNull(nb.ComputeScores());
            Assert.Empty(nb.ComputeScores());

            //test with no exams and 1 unit
            Unit sociologie = new Unit();
            sociologie.Name = "socio";
            sociologie.Coef = 3;
            nb.AddUnit(sociologie);
            Assert.Empty(nb.ComputeScores());

            //test with one unit and his module contains exams
            Exam e1 = new Exam
            {
                Coef = 2,
                Score = 20
            };
            Exam e2 = new Exam
            {
                Coef = 3,
                Score = 17
            };
            Module m1 = new Module
            {
                Coef = 2
            };
            e1.Module = m1;
            e2.Module = m1;
            nb.AddExam(e1);
            nb.AddExam(e2);
            sociologie.Add(m1);
            Assert.NotEmpty(nb.ComputeScores());
            Assert.Equal(18.2f, nb.ComputeScores()[1].Average, 2);

            //test with two units and their modules contains exams
            Exam e3 = new Exam();
            e3.Coef = 2;
            e3.Score = 18;
            nb.AddExam(e3);
            Module m2 = new Module();
            e3.Module = m2;
            m2.Coef = 3;
            Unit info = new Unit();
            info.Name = "Info";
            info.Coef = 1;
            info.Add(m2);
            nb.AddUnit(info);
            Assert.Equal(5, nb.ComputeScores().Length);
            Assert.Equal(18f, nb.ComputeScores()[3].Average, 2);

            //test global average
            Assert.Equal(18.15, nb.ComputeScores()[4].Average, 3);
        }
    }
}

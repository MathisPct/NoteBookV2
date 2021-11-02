using Logic;
using Storage;
using System;
using Xunit;

namespace TestStorage
{
    public class TestJsonStorage
    {
        [Fact]
        public void TestSaveLoad()
        {
            NoteBook nb = new NoteBook();
            Unit social = new Unit
            {
                Name = "Social",
                Coef = 13
            };
            nb.AddUnit(social);
            Module francais = new Module
            {
                Name = "Français",
                Coef = 5
            };
            Module anglais = new Module
            {
                Name = "Anglais",
                Coef = 2
            };
            social.Add(francais);
            social.Add(anglais);
            Unit science = new Unit
            {
                Name = "Science",
                Coef = 17
            };
            nb.AddUnit(science);
            Module math = new Module
            {
                Name = "Maths",
                Coef = 5
            };
            Module physique = new Module
            {
                Name = "Physique",
                Coef = 2
            };
            science.Add(math);
            science.Add(physique);
            Exam eAnglais = new Exam
            {
                Coef = 3,
                Score = 18,
                Module = anglais
            };
            nb.AddExam(eAnglais);
            Exam eMaths = new Exam
            {
                Coef = 1,
                Score = 14,
                Module = math
            };
            nb.AddExam(eMaths);
            Exam eFrancais = new Exam
            {
                Coef = 3,
                Score = 14,
                Module = francais
            };
            nb.AddExam(eFrancais);
            Exam ePhysique = new Exam
            {
                Coef = 1,
                Score = 20,
                Module = physique
            };
            nb.AddExam(ePhysique);
            IStorage storage = new JsonStorage("test");
            storage.Save(nb);
            NoteBook nb2 = storage.Load();
            //test if notebook that we save is the same with the notebook which we load
            Assert.Equal(nb.ListUnits(), nb2.ListUnits());
            Assert.Equal(nb.ListExams(), nb2.ListExams());
            Assert.Equal(nb, nb2);
        }
    }
}

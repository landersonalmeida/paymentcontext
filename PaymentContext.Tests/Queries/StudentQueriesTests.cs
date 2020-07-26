using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests {
    [TestClass]
    public class StudentQueriesTests {
        private IList<Student> _students;

        public StudentQueriesTests()  {
            this._students = new List<Student>();

            for(var i = 0; i < 10; i++) {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("1234567891112", EDocumentType.CPF),
                    new Email("email" +i.ToString() + "@dokky.io")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists() {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var students = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, students);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists() {
            var exp = StudentQueries.GetStudentInfo("1234567891112");
            var students = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, students);
        }
    }
}
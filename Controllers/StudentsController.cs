using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4;

namespace student.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<StudentDetails> _students = new List<StudentDetails>();
        public static List<Course> _course = new List<Course>();
       
        // GET: api/Student/5
        [HttpGet("api/CourseDetails")]
        public IActionResult GetCourse()
        {
            var courselist = from C in _course
                             join S in _students on C.Courses1 equals S.Course into sc
                             from doc in sc.DefaultIfEmpty()
                             group doc by C.Courses1 into q
                             select new { CourseName = q.Key, Student_Count = q.Count(x=>x!=null) };
            

            return Ok(courselist);
        }
        [HttpGet("api/studentDetails")]
        public IActionResult GetStudentDetails()
        {
            var entity = _students.Select(x => new { x.FirstName, x.LastName });
                    return Ok(entity);       
        }

        [HttpGet("api/student")]
        public IActionResult GetStudent()
        {
            return Ok(_students);
        }


        // POST: api/Couse
        [HttpPost("api/Course")]
        public IActionResult CreateCourse(Course cour)
        {
            var Courseadded = new Course
            {
                Courses1 = cour.Courses1
               
            };
            _course.Add(Courseadded);
            return Ok();
        }


        // POST: api/Student
        [HttpPost("api/StudentDetails")]
        public IActionResult CreateStud(StudentDetails stud)
        {
            var lastStudents = _students.OrderByDescending(x => x.Id).FirstOrDefault();

            int id = lastStudents == null ? 1 : lastStudents.Id + 1;
            var Studentadded = new StudentDetails
            {
                Id = id,
                FirstName = stud.FirstName,
                LastName = stud.LastName,
                Dob = stud.Dob,
                Address = stud.Address,
                Phone = stud.Phone,
                Eod = stud.Eod,
                Course = stud.Course
            };
                if (Convert.ToDateTime(stud.Dob) > DateTime.Now|| Convert.ToDateTime(stud.Eod) > DateTime.Now)
                    return Conflict("enter a valid date");


                foreach (var course in _course)
                {

                    if (string.Equals(course.Courses1, stud.Course))
                    {
                        _students.Add(Studentadded);
                        
                    }
                }
            return Ok(Studentadded);


            
        }
        // PUT: api/Student/5
        [HttpPut("api/Student")]
        public IActionResult GetStudentsValue(StudentDetails student)
        {
            //var NewStudent = _students.SingleOrDefault(x => x.Id == id);
            foreach (var ent in _students)

            {
                if (ent.Id == student.Id)
                {                                             
                    foreach (var course in _course)
                    {
                        
                        if (string.Equals(course.Courses1, student.Course))
                        {
                            ent.Id = student.Id;
                            ent.FirstName = student.FirstName;
                            ent.LastName = student.LastName;
                            ent.Dob = student.Dob;
                            ent.Address = student.Address;
                            ent.Phone = student.Phone;
                            ent.Eod = student.Eod;
                            ent.Course = student.Course;
                        }
                    }
                    return Ok() ;
                }

                return NotFound();
            }
            return Ok();
        }
        [HttpDelete("api/Student")]
        public IActionResult DeleteStudentsValue(int studentid)
        {
            //var NewStudent = _students.SingleOrDefault(x => x.Id == id);
            foreach (var ent in _students)

            {
                if (studentid ==ent.Id)
                {
                    _students.Remove(ent);
                    return Ok();

                }
            }
            return NotFound();
        }
                    
     }
}



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ObsProject.Models;
using ObsProject.ViewModel;
using System.Diagnostics;

namespace ObsProject.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetStudentList()
        {
            var list = _context.Students
                .Include(x => x.TeacherStudens)
                .ThenInclude(x => x.ClassTeachers)
                .Include(x => x.TeacherStudens)
                .ThenInclude(x => x.GuideTeachers)
                .Include(x => x.İlcelers)
                .ThenInclude(x => x.İller)
                .Include(x=>x.StudentHobbies)
                .ThenInclude(x=>x.Hobby)
                .ToList();
            return Json(list);
        }
        public JsonResult UpdateStudent(int id)
        {
            StudentVM student = new StudentVM();
            student.StudentModel= _context.Students
                .Include(x => x.TeacherStudens)
                .ThenInclude(x => x.ClassTeachers)
                .Include(x => x.TeacherStudens)
                .ThenInclude(x => x.GuideTeachers)
                .Include(x => x.İlcelers)
                .ThenInclude(x => x.İller)
                .Include(x => x.StudentHobbies)
                .ThenInclude(x => x.Hobby)
                .Where(x=>x.Id==id).Select(x=>new StudentModel
                {
                    Age=x.Age,
                    CityId=x.CityId,
                    Id=x.Id,
                    ClassTeacherId=x.TeacherStudens.FirstOrDefault().ClasssTeacherId,
                    Grup=x.Grup,
                    HobbyId=x.StudentHobbies.FirstOrDefault().HobbyId,
                    Name=x.Name,
                    GuideTeacherId=x.TeacherStudens.FirstOrDefault().GuideTeacherId,
                    Surname=x.Surname,
                    districtId=x.İlcelers.id
                }).FirstOrDefault();
            return Json(student);
        }
        public IActionResult Teachers()
        {
            return View();
        }
        public JsonResult GetTeacherList()
        {
            var result = _context.Teachers.ToList();
            return Json(result);
        }
        public JsonResult HobbyList()
        {
            var result = _context.Hobbies.ToList();
            return Json(result);
        }
        public JsonResult GetTeacherData(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);
            return Json(teacher);
        }
        [HttpPost]
        public JsonResult AddOrUpdateTeacher(TeacherVM teachers)
        {
            if (teachers.Id > 0)
            {
                var result = _context.Teachers.Where(x => x.Id == teachers.Id).FirstOrDefault();
                result.Name = teachers.Name;
                _context.SaveChanges();
            }
            else
            {
                Teachers ogretmen = new Teachers()
                {
                    Name = teachers.Name
                };
                _context.Teachers.Add(ogretmen);
                _context.SaveChanges();
            }
            return Json(1);
        }
        public JsonResult GetCityList()
        {
            var result = _context.İllers.ToList();
            return Json(result);
        }
        public JsonResult GetDisctrictList()
        {
            var result = _context.İlcelers.ToList();
            return Json(result);
        }
        public JsonResult GetDistrictByCity(int cityId)
        {
            var result = _context.İlcelers.Where(x => x.sehirid == cityId).ToList();
            return Json(result);
        }
        [HttpPost]
        public JsonResult AddOrUpdateStudent(StudentModel students)
        {
            if (students.Id > 0)
            {
                var getBy = _context.Students.FirstOrDefault(x => x.Id == students.Id);
                getBy.Age = students.Age;
                getBy.Grup = students.Grup;
                getBy.CityId = students.CityId;
                getBy.Name = students.Name;
                getBy.Surname = students.Surname;
                _context.SaveChanges();

                var teacherList = _context.TeacherStudens.Where(x => x.StudentId == students.Id).ToList();
                _context.TeacherStudens.RemoveRange(teacherList);
                _context.SaveChanges();

                TeacherStudens teacher = new TeacherStudens()
                {
                    ClasssTeacherId = students.ClassTeacherId,
                    GuideTeacherId = students.GuideTeacherId,
                    StudentId = getBy.Id
                };
                _context.TeacherStudens.Add(teacher);
                _context.SaveChanges();

                var hobbyList = _context.StudentHobbies.Where(x => x.StudentId == getBy.Id).ToList();
                _context.StudentHobbies.RemoveRange(hobbyList);
                _context.SaveChanges();

                StudentHobby studentHobby = new StudentHobby()
                {
                    HobbyId = students.HobbyId,
                    StudentId = getBy.Id
                };
                _context.StudentHobbies.Add(studentHobby);
                _context.SaveChanges();
            }
            else
            {
                Students studentss = new Students()
                {
                    Age = students.Age,
                    Grup = students.Grup,
                    CityId = students.CityId,
                    Name = students.Name,
                    Surname = students.Surname,
                };
                _context.Students.Add(studentss);
                _context.SaveChanges();
                TeacherStudens teacher = new TeacherStudens()
                {
                    ClasssTeacherId = students.ClassTeacherId,
                    GuideTeacherId = students.GuideTeacherId,
                    StudentId = studentss.Id
                };
                _context.TeacherStudens.Add(teacher);
                _context.SaveChanges();
                StudentHobby studentHobby = new StudentHobby()
                {
                    HobbyId = students.HobbyId,
                    StudentId = studentss.Id
                };
                _context.StudentHobbies.Add(studentHobby);
                _context.SaveChanges();
            }
            return Json(1);
        }
        public IActionResult Hobby()
        {
            return View();
        }
        public JsonResult GetAllHobby()
        {
            var result = _context.Hobbies.ToList();
            return Json(result);
        }
        public JsonResult GetHobbyData(int id)
        {
            var hobby = _context.Hobbies.FirstOrDefault(x => x.Id == id);
            return Json(hobby);
        }
        [HttpPost]
        public JsonResult AddOrUpdateHobby(Hobby hobby)
        {
            if (hobby.Id > 0)
            {
                var result = _context.Hobbies.Where(x => x.Id == hobby.Id).FirstOrDefault();
                result.Hobbys = hobby.Hobbys;
                _context.SaveChanges();
            }
            else
            {
                Models.Hobby hobbys = new Hobby()
                {
                    Hobbys = hobby.Hobbys,
                };
                _context.Hobbies.Add(hobby);
                _context.SaveChanges();
            }
            return Json(1);
        }
    }
}
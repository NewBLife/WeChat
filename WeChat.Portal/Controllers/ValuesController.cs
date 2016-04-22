using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Aurore.Framework.Core;
using Aurore.Framework.Utils;
using Aurore.Framework.Web.Mvc;
using ConsoleApplication1;
using WeChat.Data.Entitys;
using WeChat.Services.Interfaces;

namespace WeChat.Portal.Controllers
{
    public class ValuesController : ApiController
    {


        // GET api/values
        public object Get()
        {

            var grades = new List<Grade>();
            for (int j = 0; j < 10; j++)
            {
                var stus = new List<Student>();
                for (var i = 0; i < 10; i++)
                {
                    var stu = new Student
                    {
                        Id = i,
                        Name = "Name" + i.ToString("C2"),
                        GradeId = j,
                        Age = (new Random()).Next(10, 50),
                        Ints = new[] { 3, 5, 7 }
                    };
                    stus.Add(stu);
                }
                var grade = new Grade
                {
                    Id = j,
                    GradeName = "GradeName" + j.ToString("C2"),
                    Students = stus
                };
                grades.Add(grade);

            }
            var response = new ResponseEntity<List<Grade>>
            {
                Data = grades,
                ErrorCode = "S001",
                ErrorMsg = "Error is nothings."
            };
            //var xml = response.ToXml(false);
            return response.XmlResponse();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

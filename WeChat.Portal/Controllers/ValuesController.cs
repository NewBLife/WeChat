using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Aurore.Framework.Core;
using Aurore.Framework.Utils;
using Aurore.Framework.Web.Mvc;
using ConsoleApplication1;
using WeChat.Core.XmlModels.Request;
using WeChat.Core.XmlModels.Response;
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
        public HttpResponseMessage Get(int id)
        {
            var info = new RequestEvent(){ToUserName = "gh_1769d357444d",FromUserName = "opKrYwas6Lx4_qRK9s9-NHLV-izo",CreateTime = 1461496547 ,MsgType = "event" ,Event = "CLICK",EventKey = "aboutUs"};
            var msg = "你发送了文本【{0}】";
            var response = new ResponseText(info)
            {
                Content = string.Format(msg,"OK")
            };
            return response.XmlResponse();
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

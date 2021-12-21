using HW1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HW1.Controllers
{
    public class NewsController : ApiController
    {
        // GET api/<controller>
        public List<string> Get() // שיטתGet  ללא פרמטרים תחזיר List<string> של 
        {
            Article article = new Article();
            return article.ReadAllArticleNames();
        }

        // GET api/<controller>/5
        public List<Article> Get(string name)
        {
            Article article = new Article();
            return article.ReadByName(name);
        }

        // POST api/<controller>
        public int Post([FromBody]Article article)
        {
            article.Insert();
            return 1;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
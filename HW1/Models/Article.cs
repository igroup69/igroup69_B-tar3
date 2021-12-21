using HW1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Article
    {

        string id;
        string seriesName;
        string head;
        string body;
        string source;
        string publishDateTime;
        string image;
        string link;

        public Article() { }

        public Article(string id, string seriesName, string head, string body, string source, string publishDateTime, string image, string link)
        {
            this.id = id;
            this.seriesName = seriesName;
            this.head = head;
            this.body = body;
            this.source = source;
            this.publishDateTime = publishDateTime;
            this.image = image;
            this.link = link;
        }

        public string Id { get => id; set => id = value; }
        public string SeriesName { get => seriesName; set => seriesName = value; }
        public string Head { get => head; set => head = value; }
        public string Body { get => body; set => body = value; }
        public string Source { get => source; set => source = value; }
        public string PublishDateTime { get => publishDateTime; set => publishDateTime = value; }
        public string Image { get => image; set => image = value; }
        public string Link { get => link; set => link = value; }

        public int Insert()
        {
            DataServices ds = new DataServices();
            return ds.Insert(this);
        }

        public List<string> ReadAllArticleNames()
        {
            DataServices ds = new DataServices();
            return ds.ReadAllArticleNames();
        }

        public List<Article> ReadByName(string name)
        {
            DataServices ds = new DataServices();
            return ds.ReadByName(name);
        }

    }
}
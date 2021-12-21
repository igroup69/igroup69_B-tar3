using HW1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Review
    {
        string id;
        string criticName;
        string email;
        string reviewDateTime;
        int rating;
        string contents;

        public Review() { }

        public Review(string id, string criticName, string email, string reviewDateTime, int rating, string contents)
        {
            this.Id = id;
            this.CriticName = criticName;
            this.Email = email;
            this.ReviewDateTime = reviewDateTime;
            this.Rating = rating;
            this.Contents = contents;
        }

        public string Id { get => id; set => id = value; }
        public string CriticName { get => criticName; set => criticName = value; }
        public string Email { get => email; set => email = value; }
        public string ReviewDateTime { get => reviewDateTime; set => reviewDateTime = value; }
        public int Rating { get => rating; set => rating = value; }
        public string Contents { get => contents; set => contents = value; }

        public int Insert()
        {
            DataServices ds = new DataServices();
            return ds.Insert(this);
        }

        public List<Review> ReadReview()
        {
            DataServices ds = new DataServices();
            return ds.ReadReview();
        }

    }
}
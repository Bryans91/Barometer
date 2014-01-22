using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class SubjectQuestions
    {
        public int Id { get; set; }
        private string subject;
        private List<Question> questions;
        private bool enabled;

        public SubjectQuestions(string s, bool ena)
        {
            subject = s;
            enabled = ena;
            questions = new List<Question>();
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        
        public bool Enabled
	{
		get { return enabled;}
		set { enabled = value;}
	}
       

        public List<Question> Questions
        {
            get { return questions; }
            set { questions = value; }
        }
        
    }
}
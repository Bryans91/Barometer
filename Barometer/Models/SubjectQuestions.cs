using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class SubjectQuestions
    {
        public int _id { get; set; }
        private string _subject;
        private List<Question> _questions;
        private bool _enabled;

        public SubjectQuestions(string subject, bool enabled)
        {
            _subject = subject;
            _enabled = enabled;
            _questions = new List<Question>();
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        
        public bool Enabled
	{
		get { return _enabled;}
		set { _enabled = value;}
	}
       

        public List<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
        
    }
}